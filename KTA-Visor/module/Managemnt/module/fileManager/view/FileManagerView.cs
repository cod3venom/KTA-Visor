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
using KTA_Visor_UI.component.basic.table;
using KTA_Visor.module.Managemnt.module.fileManager.handlers;
using System.Collections.Generic;
using KTA_Visor.module.Managemnt.module.fileManager.interfaces;
using KTAVisorAPISDK.module.user.abstraction;
using KTA_Visor_UI.component.basic.table.enums;

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
            new ColumnTObject(7, "SUMA KONTROLNA"),
            new ColumnTObject(8, "DATA WGRYWANIA"),
        };

        private readonly List<IFileManagerUIHandler> _uiHandlers;
        private readonly FileManagerUIHandler _fileManagerUIHandler;
        private readonly FileManagerTableUIHandler _fileManagerTableUIHandler;
        private readonly FileManagerZipHandler _fileManagerZipHandler;
        public FileManagerView()
        {
            InitializeComponent();
        }

        public FileManagerView(UserDataAbstraction user)
        {
            InitializeComponent();
            
            this.User = user;
            this._fileManagerUIHandler = new FileManagerUIHandler(this);
            this._fileManagerTableUIHandler = new FileManagerTableUIHandler(this);
            this._fileManagerZipHandler = new FileManagerZipHandler(this);

            this._uiHandlers = new List<IFileManagerUIHandler>(){
                this._fileManagerUIHandler,
                this._fileManagerTableUIHandler,
                this._fileManagerZipHandler,
            };
           
        }


        private void FileManagerView_Load(object sender, EventArgs e)
        {
            this.table.Columns = this.Columns;
            this.hookEvents();
            this._uiHandlers.ForEach((IFileManagerUIHandler handler) => {
                handler.Handle();
            });
        }

        private void hookEvents()
        {
            this.Table.OnEditButton += onEditFileRecord;
            this.Table.OnDeleteButton += onDeleteFileRecord;
            this.Table.DataGridView.CellDoubleClick += onCellDoubleClick;
            this.Table.DataGridView.SelectionChanged += onRowSelectionChanged;
            this.Table.OnRefreshData += onRefeshData;
        }
 
        private void onEditFileRecord(object sender, EventArgs e)
        {
            this._fileManagerUIHandler.Edit(this.ID);
        }

        private void onDeleteFileRecord(object sender, EventArgs e)
        {
            if (this.table.IsMultipleRecordsAreSelected)
            {
                this._fileManagerUIHandler.Delete(this.IDS);
            } else
            {
                this._fileManagerUIHandler.Delete(this.ID);
            }
        }


        private void onCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this._fileManagerUIHandler.Edit(this.ID);
        }

        private void onRefeshData(object sender, EventArgs e)
        {
            this._fileManagerUIHandler.Load();
        }


        private void onRowSelectionChanged(object sender, EventArgs e)
        {
            if (this.table.IsMultipleRecordsAreSelected) {
                this.table.AllowEdit = false;
            } 
            else {
                this.table.AllowEdit = true;
            }
        }

        public void Watch(Request request)
        {
        }

        public UserDataAbstraction User { get; private set; }
        public Table Table
        {
            get { return this.table; }
        }
        public ContextMenuStrip RecordMenu
        {
            get { return this.contextMenu; }
        }
        public ToolStripMenuItem CopyToUSB
        {
            get { return this.copyFilesToUSBMenuItem; }
        }
        public List<string> SelectedFiles
        {
            get
            {
                List<string> files = new List<string>();

                foreach (DataGridViewRow row in this.table.DataGridView.SelectedRows)
                {
                    if (!files.Contains("LOKALIZACJA")){
                        continue;
                    }

                    files.Add(row.Cells["LOKALIZACJA"].Value.ToString());
                }
                return files;
            }
        }

        public string ID
        {
            get { return this.Table.Row.SelectedRow.Cells["ID"].Value.ToString(); }
        }

        public List<string> IDS
        {
            get 
            {
                List<string> ids = new List<string>();
                foreach(DataGridViewRow row in this.table.DataGridView.SelectedRows)
                {
                    ids.Add(row.Cells["ID"].Value.ToString());
                }
                return ids;
            }
        }

    }
}
