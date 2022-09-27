using static KTAVisorAPISDK.module.fileHistory.entity.FileHistoryEntity;
using KTAVisorAPISDK.module.fileHistory.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KTAVisorAPISDK.module.fileHistory.entity;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor.module.Managemnt.module.fileHistory.view.form;

namespace KTA_Visor.module.Managemnt.module.fileHistory.view.FileHistoryViewPanel
{
    public partial class FileHistoryViewPanel : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        private readonly FileHistoryService fileHistoryService;


        public FileHistoryViewPanel()
        {
            InitializeComponent();
            this.fileHistoryService = new FileHistoryService();
        }

        private void FileHistoryViewPanel_Load(object sender, EventArgs e)
        {
            this.table.Column.addMultiple(this.Columns);
            this.table.DataGridView.CellDoubleClick += onOpenSelectedRecord;
            this.fetch();
        }

        private async void onOpenSelectedRecord(object sender, DataGridViewCellEventArgs e)
        {
            FileHistoryEntity selectedHistory = await this.fileHistoryService.findbyid(this.ID);
            FileHistoryRecordForm fileHistoryRecordForm = new FileHistoryRecordForm(selectedHistory.data);
            fileHistoryRecordForm.OnClose += (delegate (object _sender, EventArgs _e)
            {
                this.fetch();
            });
            fileHistoryRecordForm.ShowDialog();
        }

        private async void fetch()
        {
            this.table.Row.clear();
            FileHistoryEntity files = await this.fileHistoryService.all();
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string ID
        {
            get { return this.table.Row.SelectedRow.Cells["ID"].Value.ToString(); }
        }

    }
}
