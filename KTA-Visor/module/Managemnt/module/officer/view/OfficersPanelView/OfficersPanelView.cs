using KTA_Visor.module.Managemnt.module.officer.dto.request;
using KTA_Visor.module.Managemnt.module.officer.entity;
using KTA_Visor.module.Managemnt.module.officer.service;
using KTA_Visor.module.Managemnt.module.officer.view.forms.OfficerCrudForm;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
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
        private readonly ColumnTObject[] Columns = new ColumnTObject[] { 
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IMIĘ"),
            new ColumnTObject(2, "NAZWISKO"),
            new ColumnTObject(3, "ID KAMERY"),
            new ColumnTObject(4, "ID KARTY"),
        };

        private readonly OfficerService officerService;

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
            this.officerCrudForm.OnSave += onSaveNewOfficer; ;

            this.table.bundle.column.addMultiple(this.Columns);
            this.fetchOfficers();
        }

        private void onSaveNewOfficer(object sender, events.OnSaveNewOfficerEvent e)
        {
            this.officerService.create(new CreateOfficerRequestTObject(
                e.FirstName, e.LastName, e.CameraId, e.CardId
            ));

            this.fetchOfficers();
        }

        private void onClickedAddNewOfficer(object sender, EventArgs e)
        {
            this.officerCrudForm = new OfficerCrudForm();
            this.officerCrudForm.ShowDialog();
        }

        private void onClickEditOfficer(object sender, EventArgs e)
        {
            OfficerEntity officer = this.selectedRowToOfficer();
            this.officerCrudForm = new OfficerCrudForm(
                officer.data.id,
                officer.data.firstName,
                officer.data.lastName,
                officer.data.camId,
                officer.data.cardId
            );

            this.officerCrudForm.ShowDialog();
        }

        private void onClickDeleteOfficer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private OfficerEntity selectedRowToOfficer()
        {
            DataGridViewRow selectedRow = this.table.bundle.row.selectedRow;
            if (selectedRow == null)
                throw new Exception("Proszę wybrać dane");

            if (selectedRow.Cells.Count < 5)
                throw new Exception("Proszę wybrać poprawne dane");

            OfficerEntity officer = new OfficerEntity();
            officer.data = new OfficerEntity.Data();
            officer.data.id = selectedRow.Cells["ID"].Value.ToString();
            officer.data.firstName = selectedRow.Cells["IMIĘ"].Value.ToString();
            officer.data.lastName= selectedRow.Cells["NAZWISKO"].Value.ToString();
            officer.data.camId = selectedRow.Cells["ID KAMERY"].Value.ToString();
            officer.data.cardId= selectedRow.Cells["ID KARTY"].Value.ToString();
            return officer;
        }

        private async void fetchOfficers()
        {
            OfficersEntity officers = await this.officerService.all();
            this.table.bundle.row.clear();

            foreach (var officer in officers.data)
            {
                this.table.bundle.row.add(
                    officer.id,
                    officer.firstName,
                    officer.lastName,
                    officer.camera?.customId,
                    officer.cardId
                );
            }
        }

    }
}
