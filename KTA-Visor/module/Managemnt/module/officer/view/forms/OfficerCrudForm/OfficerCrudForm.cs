using KTA_Visor.module.Managemnt.module.officer.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.officer.view.forms.OfficerCrudForm
{
    public partial class OfficerCrudForm : Form
    {
        public event EventHandler<OnSaveNewOfficerEvent> OnSave;
        public OfficerCrudForm()
        {
            InitializeComponent();
        }

       

        public OfficerCrudForm(string id, string firstName, string lastName, string cameraId, string cardId)
        {
            InitializeComponent();
            this.firstNameTxt.Text = firstName;
            this.lastNameTxt.Text = lastName;
            this.cameraIdsCombo.Items.Add(cameraId);
            this.cardIdsCombo.Items.Add(cardId);

            this.cameraIdsCombo.SelectedIndex = this.cameraIdsCombo.Items.IndexOf(cameraId);
            this.cardIdsCombo.SelectedIndex = this.cardIdsCombo.Items.IndexOf(cardId);
        }

        private void OfficerCrudForm_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            this.topBar1.onClose += onCloseCurrentForm;
            this.topBar1.MinimizeButton.Visible = false;
            this.topBar1.ResizeButton.Visible = false;
            this.saveBtn.OnClick += onSaveBtn;
        }

        private void onSaveBtn(object sender, EventArgs e)
        {
            this.OnSave?.Invoke(sender, new OnSaveNewOfficerEvent(
                this.firstNameTxt.Text,
                this.lastNameTxt.Text,
                this.cameraIdsCombo.SelectedItem.ToString(),
                this.cardIdsCombo.SelectedItem.ToString()
            ));
        }

        private void onCloseCurrentForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
