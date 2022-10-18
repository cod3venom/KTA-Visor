using KTA_Visor.kernel.module.ThreadPool;
using KTA_Visor.module.Managemnt.module.fileManager.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager.view;
using KTA_Visor.module.Managemnt.module.fileManager.view.form;
using KTAVisorAPISDK.module.fileManager.entity;
using KTAVisorAPISDK.module.fileManager.service;
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
            this.hookEvents();
            this.initializeUI();
            this.Load();
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


        private void hookEvents()
        {
            this._fileManager.Table.DataGridView.CellDoubleClick += onOpenSelectedRecord;
            this._fileManager.Table.OnRefreshData += onRefeshData;
        }

        private void onRefeshData(object sender, EventArgs e)
        {
            this.Load();
        }

        private void initializeUI()
        {
            this._fileManager.Table.AllowProgressBar = true;
        }

        private async Task<List<FileHistory>> allRecords()
        {
            FileItemEntity files = await this._fileManagerService.all();
            if (files.datas == null){
                return new List<FileHistory>();
            }

            return files.datas;
        }

        private void onOpenSelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            ThreadPoolManager.Run(this._fileManager, ((Action)async delegate {
                FileItemEntity selectedHistory = await this._fileManagerService.findbyid(this.ID);
                FileHistoryRecordForm _fileHistoryRecordForm = new FileHistoryRecordForm(selectedHistory.data);
                _fileHistoryRecordForm.OnClose += onFileHistoryRecordFormClosed;
                _fileHistoryRecordForm.ShowDialog();
            }));
        }

        private void onFileHistoryRecordFormClosed(object sender, EventArgs e)
        {
            this.Load();
        }

        private void cleanTable()
        {
            this._fileManager.Table.Invoke((MethodInvoker)delegate{
                this._fileManager.Table.DataGridView.Rows.Clear();
            });
        }

        private void addToTable(FileHistory file)
        {
            ThreadPoolManager.Run(this._fileManager, ((Action) delegate {
                this._fileManager.Table.Row.Add(
                    file.id,
                    file.fileDestPath,
                    file.fileSize.ToString(),
                    file.evidence ? "Tak" : "Nie",
                    file.removableEvidence ? "Tak" : "Nie",
                    file.cameraCustomId,
                    file.badgeId,
                    file.checkSum,
                    file.createdAt
                );
            }));
        }
        private string ID
        {
            get { return this._fileManager.Table.Row.SelectedRow.Cells["ID"].Value.ToString(); }
        }


    }
}
