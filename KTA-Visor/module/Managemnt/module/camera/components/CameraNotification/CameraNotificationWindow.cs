using KTA_Visor.module.Managemnt.module.camera.components.CameraNotification.events;
using KTA_Visor.module.Managemnt.module.camera.components.CameraNotification.globals;
using KTA_Visor_UI.component.custom.Notification;
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

namespace KTA_Visor.module.Managemnt.module.camera.components.CameraNotification
{
    public partial class CameraNotificationWindow : Form
    {
        public event EventHandler<CameraNotificationOpenClickEvent> OnOpenCameraClicked;

        private readonly CameraEntity.Camera camera;
        private readonly NotificationWIndow notificationWindowHandler;
        public CameraNotificationWindow(CameraEntity.Camera camera)
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.topBar1.onClose += onClose;
            this.camera = camera;
            this.notificationWindowHandler = new NotificationWIndow(this);
        }

       

        private void CameraNotificationWindow_Load(object sender, EventArgs e)
        {
            this.badgeLbl.Text = this.camera.badgeId;
            this.StartPosition = FormStartPosition.Manual;
            this.Click += onOpenCameraSettings;
            this.openBtn.Click += onOpenCameraSettings;

        }

        private void onOpenCameraSettings(object sender, EventArgs e)
        {
            this.OnOpenCameraClicked?.Invoke(this, new CameraNotificationOpenClickEvent(this.camera));
        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
