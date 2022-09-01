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
        private string id = "";
        
        public event EventHandler<OnOfficerCRUDEvent> OnCreateOfficer;
        public event EventHandler<OnOfficerCRUDEvent> OnEditOfficerEvent;

        private string mode = "create";

        public OfficerCrudForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="cameraId"></param>
        /// <param name="cardId"></param>
        public OfficerCrudForm(
            string id,
            string firstName,
            string lastName,
            string camerCustomId,
            string cardCustomId,
            string badgeId
        )
        {
            InitializeComponent();
            this.id = id;
            this.firstNameTxt.Text = firstName;
            this.lastNameTxt.Text = lastName;
            this.camCustomIdTxt.Text = camerCustomId;
            this.cardCustomIdTxt.Text = cardCustomId;
            this.badgeIdTxxt.Text = badgeId;
            this.mode = "edit";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfficerCrudForm_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            this.topBar1.onClose += onCloseCurrentForm;
            this.topBar1.MinimizeButton.Visible = false;
            this.topBar1.ResizeButton.Visible = false;
            this.saveBtn.OnClick += onSaveBtn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onSaveBtn(object sender, EventArgs e)
        {
           if (this.mode == "create")
            {
                this.OnCreateOfficer?.Invoke(this, new OnOfficerCRUDEvent(
                   this.firstNameTxt.Text,
                   this.lastNameTxt.Text,
                   this.camCustomIdTxt.Text,
                   this.cardCustomIdTxt.Text,
                   this.badgeIdTxxt.Text
                ));
            }
           else if(this.mode == "edit")
            {
                this.OnEditOfficerEvent?.Invoke(this, new OnOfficerCRUDEvent(
                   this.id,
                   this.firstNameTxt.Text,
                   this.lastNameTxt.Text,
                   this.camCustomIdTxt.Text,
                   this.cardCustomIdTxt.Text,
                   this.badgeIdTxxt.Text
                ));
            }
        }

        private void onCloseCurrentForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
