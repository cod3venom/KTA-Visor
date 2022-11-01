using KTA_Visor.kernel.helper;
using KTA_Visor.kernel.module.ThreadPool;
using KTA_Visor.module.Managemnt.module.fileManager.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager.view;
using KTA_Visor.module.Managemnt.module.fileManager.view.form;
using KTAVisorAPISDK.module.fileManager.entity;
using KTAVisorAPISDK.module.fileManager.service;
using KTAVisorAPISDK.module.user.abstraction;
using KTAVisorAPISDK.module.user.consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KTAVisorAPISDK.module.fileManager.entity.FileItemEntity;

namespace KTA_Visor.module.Managemnt.module.fileManager.handlers
{
    public class FileManagerUIHandler : IFileManagerUIHandler
    {
        public static string HandlerName = "FileManagerUIHandler";
        private readonly FileManagerView _fileManager;
        private readonly FileManagerService _fileManagerService;

        public FileManagerUIHandler(FileManagerView _fileManager)
        {
            this._fileManager = _fileManager;
            this._fileManagerService = new FileManagerService();
        }

        public string GetName()
        {
            return FileManagerUIHandler.HandlerName;
        }

        public void Handle()
        {
            this.initializeUI();
            this.Load();
        }

        private void initializeUI()
        {
            this._fileManager.Table.AllowProgressBar = true;
        }

        public void Load()
        {
            Thread loadingThread = new Thread(async () =>
            {
                List<FileHistory> files = await this.allRecords();

                this.cleanTable();

                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
                Parallel.ForEach(files, options, file =>{
                    this.addToTable(file);
                });
            });

            loadingThread.IsBackground = true;
            loadingThread.Start();
        }

        public void Edit(string id)
        {
            ThreadPoolManager.Run(this._fileManager, ((Action) async delegate {
                bool canEdit = 
                    this._fileManager.User.data.roles[0] == UserRole.ROLE_ADMIN ||
                    this._fileManager.User.data.roles[0] == UserRole.ROLE_SUPER_ADMIN ?
                    true : false;

                FileItemEntity selectedHistory = await this._fileManagerService.findbyid(id);
                FileHistoryRecordForm _fileHistoryRecordForm = new FileHistoryRecordForm(
                    selectedHistory.data,
                    canEdit
                );

                _fileHistoryRecordForm.OnClose += (delegate(object sender, EventArgs e) {
                    this.Load();
                });

                _fileHistoryRecordForm.ShowDialog();
            }));
        }

        public void Delete(List<string> ids)
        {
            ids.ForEach((id) => this.Delete(id));
        }

        public void Delete(string id)
        {
            ThreadPoolManager.Run(this._fileManager, ((Action) delegate {
                DialogResult result = MessageBox.Show(this._fileManager, "Czy na pewno chcesz skasować wybraną pozycje?", "Nagrania", MessageBoxButtons.YesNo);
                if (result == DialogResult.No){
                    return;
                }
                _ = this._fileManagerService.delete(id);
                this.Load();
            }));
        }

        private void cleanTable()
        {
            this._fileManager.Table.Invoke((MethodInvoker)delegate{
                this._fileManager.Table.DataTable.Rows.Clear();
            });
        }
        private void addToTable(FileHistory file)
        {
            ThreadPoolManager.Run(this._fileManager, ((Action) delegate {
                this._fileManager.Table.Row.Add(
                    file.id,
                    "Archiwum",
                    FileHelper.GetSizeFromPath(file.fileDestPath.ToString()),
                    file.evidence ? "Tak" : "Nie",
                    file.removableEvidence ? "Tak" : "Nie",
                    file.cameraCustomId,
                    file.badgeId,
                    file.checkSum,
                    file.createdAt
                );
            }));
        }
        private async Task<List<FileHistory>> allRecords()
        {
            FileItemEntity files = await this._fileManagerService.all();
            if (files.datas == null){
                return new List<FileHistory>();
            }

            return files.datas;
        }
    }
}
