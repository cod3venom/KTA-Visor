using static KTAVisorAPISDK.module.fileManager.entity.FileItemEntity;
using KTAVisorAPISDK.module.fileManager.service;
using System;
using System.Windows.Forms;
using KTAVisorAPISDK.module.fileManager.entity;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor.module.Managemnt.module.fileManager.view.form;
using KTA_Visor.kernel.module.ThreadPool;
using TCPTunnel.kernel.extensions.router.dto;
using KTA_Visor.kernel.sharedKernel.interfaces;

namespace KTA_Visor.module.Managemnt.module.fileManager.view
{
    public partial class FileManagerView : UserControl, IControllerInterface
    {
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "LOKALIZACJA"),
            new ColumnTObject(2, "ROZMIAR"),
            new ColumnTObject(3, "DOWÓD"),
            new ColumnTObject(4, "ZEZWOLENIE NA USUWANIE"),
            new ColumnTObject(5, "ID KAMERY"),
            new ColumnTObject(6, "NUMER ODZNAKI"),
            new ColumnTObject(7, "DATA WGRYWANIA"),
        };


        private readonly FileManagerService fileManagerService;


        public FileManagerView()
        {
            InitializeComponent();
            this.fileManagerService = new FileManagerService();
        }

        public void Watch(Request request)
        {
        }

        private void FileHistoryViewPanel_Load(object sender, EventArgs e)
        {
            this.table.Column.addMultiple(this.Columns);
            this.table.AllowProgressBar = false;
            this.table.DataGridView.CellDoubleClick += onOpenSelectedRecord;
            this.fetch();
        }

        private async void onOpenSelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            ThreadPoolManager.Run(this, ((Action) async delegate {
                FileItemEntity selectedHistory = await this.fileManagerService.findbyid(this.ID);
                FileHistoryRecordForm fileHistoryRecordForm = new FileHistoryRecordForm(selectedHistory.data);
                fileHistoryRecordForm.OnClose += (delegate (object _sender, EventArgs _e)
                {
                    this.fetch();
                });
                fileHistoryRecordForm.ShowDialog();
            }));
        }

        private void fetch()
        {
            ThreadPoolManager.Run(this, ((Action)async delegate {
                this.table.Row.clear();
                FileItemEntity files = await this.fileManagerService.all();
                foreach (FileHistory file in files.datas)
                {
                    this.table.Row.Add(
                        file.id,
                        file.fileDestPath,
                        file.fileSize.ToString(),
                        file.evidence ? "Tak" : "Nie",
                        file.removableEvidence ? "Tak" : "Nie",
                        file.cameraCustomId,
                        file.badgeId,
                        file.createdAt
                    );
                }
            }));
        }

        private string ID
        {
            get { return this.table.Row.SelectedRow.Cells["ID"].Value.ToString(); }
        }


    }
}
