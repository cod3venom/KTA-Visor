
using KTA_Visor.module.Managemnt.module.camera.form.FWUpgrade;
using KTA_Visor.module.Managemnt.module.camera.form.settings;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.Camera.component.CameraItem
{
    public partial class CameraItem : UserControl
    {
        public event EventHandler<OnOpenCameraItemEvent> OnOpenCameraItem;
        public event EventHandler<OnCloseCameraItemFormEvent> OnCloseCameraItemForm;
        public event EventHandler<OnCloseCameraItemFormEvent> OnCopyToUSBClicked;
        public event EventHandler<OnCloseCameraItemFormEvent> OnCopyToDVDClicked;



        public readonly CameraItemSettingsForm _form;
        private readonly StationEntity _station;
        private CameraEntity.Camera _camera;

        public CameraItem()
        {
            InitializeComponent();
        }

        public CameraItem(CameraEntity.Camera camera, StationEntity station)
        {
            InitializeComponent();
            this._camera = camera;
            this._station = station;
            this._form = new CameraItemSettingsForm(camera, station);
        }

        private void CameraItem_Load(object sender, EventArgs e)
        {
            this.Padding = new Padding(10, 10, 10, 20);
            this.settingsBtn.Click += OpenSettings_Click;
            this.upgradeMenuItem.Click += onUpgradeClick;

            this.ID = this._camera.id.ToString();
            this.Badge = this._camera?.badgeId;
            this.CamCustomId = this._camera?.cameraCustomId;
            this.DriveName= this._camera?.driveName;
            this.Marker = this._camera?.markerId;
            this.handleStatus();
        }

        public CameraEntity.Camera Camera 
        {
            get { return this._camera; } 
        }

        public string ID
        {
            get { return this.idTxt.Text; }
            set { this.idTxt.Text = value.ToString(); }
        }

        public string Marker
        {
            get { return this.markerLbl.Text; }
            set { this.markerLbl.Text = value.ToString(); }
        }

        public string Badge
        {
            get { return this.badgeIdLbl.Text; }
            set { this.badgeIdLbl.Text = value; }
        }

        public string CamCustomId
        {
            get { return this.cameraIdLbl.Text; }
            set { this.cameraIdLbl.Text = value; }
        }

        public string DriveName
        {
            get { return this.driveNameLbl.Text; }
            set { this.driveNameLbl.Text = value.ToString(); }
        }

        private void handleStatus()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (this.Camera.active){
                    this.statusIcon.Image = Properties.Resources.green_circle;
                }
                else{
                    this.statusIcon.Image = Properties.Resources.red_circle;
                }
            });
        }

        private void OpenSettings_Click(object sender, EventArgs e)
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

        private void onCopyFilesToDVD(object sender, EventArgs e)
        {
            this.OnCopyToDVDClicked?.Invoke(this, new OnCloseCameraItemFormEvent(this, this.Camera));
        }

        private void onUpgradeClick(object sender, EventArgs e)
        {
            new FWUpgradeForm(this.Camera).ShowDialog();
        }
    }
}
