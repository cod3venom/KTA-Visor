
using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.Camera.component.CameraItem
{
    public partial class CameraItem : UserControl
    {
        public event EventHandler<OnOpenCameraItemEvent> OnOpenCameraItem;
        public event EventHandler<OnCloseCameraItemFormEvent> OnCloseCameraItemForm;

        public readonly CameraItemSettingsForm form;

        public CameraItem()
        {
            InitializeComponent();
        }



        public CameraItem(CameraEntity.Camera camera)
        {
            InitializeComponent();
            this.Camera = camera;
            this.Drive = camera?.driveName;
            this.Badge = camera?.badgeId;
            this.form = new CameraItemSettingsForm(camera);
        }

        private void CameraItem_Load(object sender, EventArgs e)
        {
            this.Padding = new Padding(10, 10, 10, 20);
            this.openBtn.Click += OpenBtn_Click;
            this.form.OnCloseForm += onCloseForm;
        }

     

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            this.OnOpenCameraItem?.Invoke(sender, new OnOpenCameraItemEvent(this, this.Camera));
        }

        private void onCloseForm(object sender, EventArgs e)
        {
            this.OnCloseCameraItemForm?.Invoke(sender, new OnCloseCameraItemFormEvent(this, this.Camera));
        }

        private void CameraItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
        }

        private void CameraItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
        }

        public CameraEntity.Camera Camera { get; set; }

        public string Badge
        {
            get { return this.badgeLbl.Text; }
            set { this.badgeLbl.Text = value; }
        }

        public string Drive
        {
            get { return this.cameraDriveLbl.Text; }
            set { this.cameraDriveLbl.Text = value; }
        }

    }
}
