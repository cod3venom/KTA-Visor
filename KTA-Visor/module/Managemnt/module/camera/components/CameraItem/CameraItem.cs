
using KTA_Visor.module.Managemnt.module.camera.components.CameraItem.commands.filesystem;
using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
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
        public event EventHandler<OnCloseCameraItemFormEvent> OnCopyToUSBClicked;
        public event EventHandler<OnCloseCameraItemFormEvent> OnCopyToDVDClicked;



        private readonly StationEntity station;

        public readonly CameraItemSettingsForm form;

        public CameraItem()
        {
            InitializeComponent();
        }

        public CameraItem(CameraEntity.Camera camera, StationEntity station)
        {
            InitializeComponent();
            this.Camera = camera;
            this.Badge = camera?.badgeId;
            this.CamCustomId = camera?.cameraCustomId;
            this.StationCustomId = this.station?.data?.stationId;
            this.CameraIndex = camera?.index.ToString();
            this.station = station;
            this.form = new CameraItemSettingsForm(camera, station);
        }

        private void CameraItem_Load(object sender, EventArgs e)
        {
            this.Padding = new Padding(10, 10, 10, 20);
            this.settingsBtn.Click += OpenSettings_Click;
            this.form.OnCloseForm += onCloseForm;
            this.copyFilesToUSBMenuItem.Click += onCopyFilesToUSB;
            this.copyFilesToDVDMenuItem.Click += onCopyFilesToDVD;

            this.handleStatus();
        }

        

        public CameraEntity.Camera Camera { get; set; }

         

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

        public string StationCustomId
        {
            get { return this.stationIdLbl.Text; }
            set { this.stationIdLbl.Text = value; }
        }

        public string CameraIndex
        {
            get { return this.cameraIndexLbl.Text; }
            set { this.cameraIndexLbl.Text = value; }
        }

        private void handleStatus()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (this.Camera.active)
                {
                    this.statusIcon.Image = Properties.Resources.green_circle;
                }
                else
                {
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

        private void onCopyFilesToUSB(object sender, EventArgs e)
        {
            this.nasStorageFileDialog.ShowDialog();
            this.targetDriveDevicePathDialog.ShowDialog();


            CopyFilesToUSBCommand.Execute(
                this.targetDriveDevicePathDialog.SelectedPath,
                this.nasStorageFileDialog.FileNames
            );

            this.OnCopyToUSBClicked?.Invoke(this, new OnCloseCameraItemFormEvent(this, this.Camera));
        }

        private void onCopyFilesToDVD(object sender, EventArgs e)
        {
            this.OnCopyToDVDClicked?.Invoke(this, new OnCloseCameraItemFormEvent(this, this.Camera));
        }


    }
}
