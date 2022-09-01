using KTA_Visor.module.Managemnt.module.camera.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.camera.views.forms
{
    public partial class CameraCRUDForm : Form
    {
        public event EventHandler<OnCameraCRUDEvent> OnCreateCameraEvent;
        public event EventHandler<OnCameraCRUDEvent> OnEditCameraEvent;

        private string mode = "create";

        public CameraCRUDForm()
        {
            InitializeComponent();
        }

        public CameraCRUDForm(string camCustomId)
        {
            InitializeComponent();
            this.camCustomIdTxt.Text = camCustomId;
            this.mode = "edit";
        }

        private void CameraCRUDForm_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            this.topBar1.onClose += onCloseCurrentForm;
            this.topBar1.MinimizeButton.Visible = false;
            this.topBar1.ResizeButton.Visible = false;
            this.saveBtn.OnClick += onSaveBtn;
        }

        private void onSaveBtn(object sender, EventArgs e)
        {
            if (this.mode == "create")
            {
                this.OnCreateCameraEvent?.Invoke(this, new OnCameraCRUDEvent(this.camCustomIdTxt.Text));
            }
            else if (this.mode == "edit")
            {
                this.OnEditCameraEvent?.Invoke(this, new OnCameraCRUDEvent(this.camCustomIdTxt.Text));

            }
        }

        private void onCloseCurrentForm(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
