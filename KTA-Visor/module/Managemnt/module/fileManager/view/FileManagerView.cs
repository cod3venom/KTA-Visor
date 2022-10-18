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
        public FileManagerView()
        {
            InitializeComponent();
            this._uiHandlers = new List<IFileManagerUIHandler>(){
                new FileManagerUIHandler(this),
                new FileManagerZipHandler(this),
            };
           
        }

        private void FileHistoryViewPanel_Load(object sender, EventArgs e)
        {
            this.table.Column.addMultiple(this.Columns);
            this._uiHandlers.ForEach((IFileManagerUIHandler handler) => {
                handler.Handle();
            });
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
        }

        public List<string> SelectedFiles
        {

            get
            {
                List<string> files = new List<string>();

                foreach(DataGridViewRow row in this.table.DataGridView.SelectedRows)
                {
                    files.Add(row.Cells["LOKALIZACJA"].Value.ToString());
                }
                return files;
            }
        }
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
         
        public void Watch(Request request)
        {
        }
    }
}
