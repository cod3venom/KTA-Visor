using KTA_Visor.module.Managemnt.module.officer.view.forms.OfficerCrudForm;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTAVisorAPISDK.module.officer.dto.request;
using KTAVisorAPISDK.module.officer.entity;
using KTAVisorAPISDK.officer.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.officer.view.OfficersViewPanel
{
    public partial class OfficersPanelView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ColumnTObject[] Columns = new ColumnTObject[] { 
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IMIĘ"),
            new ColumnTObject(2, "NAZWISKO"),
            new ColumnTObject(3, "ID KAMERY"),
            new ColumnTObject(4, "ID KARTY"),
            new ColumnTObject(5, "NUMER ODZNAKI"),
        };

        /// <summary>
        /// 
        /// </summary>
        private readonly OfficerService officerService;

        /// <summary>
        /// 
        /// </summary>
        private OfficerCrudForm officerCrudForm;
        
        public OfficersPanelView()
        {
            InitializeComponent();
            this.officerService = new OfficerService();
            this.officerCrudForm = new OfficerCrudForm();
        }

        private void OfficersPanelView_Load(object sender, EventArgs e)
        {
            this.table.OnAddButton += onClickedAddNewOfficer;
            this.table.OnEditButton += onClickEditOfficer;
            this.table.OnDeleteButton += onClickDeleteOfficer;
                        this.table.bundle.column.addMultiple(this.Columns);
            this.fetchOfficers();
        }


        private void onClickedAddNewOfficer(object sender, EventArgs e)
        {
            this.officerCrudForm = new OfficerCrudForm();
            this.officerCrudForm.OnCreateOfficer += onSaveNewOfficer; ;
            this.officerCrudForm.ShowDialog();
        }

        private async void onClickEditOfficer(object sender, EventArgs e)
        {
            string officerId = this.getSelectedOfficerID();
            OfficerEntity officer = await this.officerService.findById(officerId);
            this.officerCrudForm = new OfficerCrudForm(
                officer.data.id,
                officer.data.firstName,
                officer.data.lastName,
                officer.data.camCustomId,
                officer.data.cardId,
                officer.data.badgeId
            );
            this.officerCrudForm.OnEditOfficerEvent += onEditOfficer;
            this.officerCrudForm.ShowDialog();
        }

        private void onClickDeleteOfficer(object sender, EventArgs e)
        {
            string officerId = this.getSelectedOfficerID();
            this.officerService.delet(officerId);
            this.fetchOfficers();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onSaveNewOfficer(object sender, events.OnOfficerCRUDEvent e)
        {
            await this.officerService.create(new CreateOfficerRequestTObject(
                e.firstName, e.lastName, e.camCustomId, e.cardCustomId, e.badgeId
            ));

            this.officerCrudForm.Close();
            this.fetchOfficers();
        }


        private async void onEditOfficer(object sender, events.OnOfficerCRUDEvent e)
        {
            await this.officerService.edit(e.id, new EditOfficerRequestTObject(
                e.firstName, e.lastName, e.camCustomId, e.cardCustomId, e.badgeId
            ));
        }


        /// <summary>
        /// 
        /// </summary>
        private async void fetchOfficers()
        {
            OfficerEntity officers = await this.officerService.all();
            this.table.DataGridView.Rows.Clear();

            foreach (var officer in officers.datas)
            {
                this.table.bundle.row.add(
                    officer.id,
                    officer.firstName,
                    officer.lastName,
                    officer.camCustomId,
                    officer.cardId,
                    officer.badgeId
                );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string getSelectedOfficerID()
        {
            return this.table.bundle.row.SelectedRow.Cells["ID"].Value.ToString();
        }

    }
}
