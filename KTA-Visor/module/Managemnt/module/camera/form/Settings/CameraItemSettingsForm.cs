using Falcon_Protocol.enums;
using KTA_Visor.kernel.generator;
using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using static Falcon_Protocol.enums.Enums;

namespace KTA_Visor.module.Managemnt.module.camera.form.settings
{
    public partial class CameraItemSettingsForm : MetroForm, ISharedKernelInterface
    {
        private string moduleName = "CameraItemSettingsForm";

        private int MIN_ID_LENGTH = 15;
        private CameraEntity.Camera camera;
        private readonly StationEntity station;
        private readonly CameraSettingsService cameraSettingsService;
        private readonly CameraService cameraService;

        public CameraItemSettingsForm(CameraEntity.Camera camera, StationEntity station)
        {
            InitializeComponent();
            this.camera = camera;
            this.station = station;
            this.cameraSettingsService = new CameraSettingsService();
            this.cameraService = new CameraService();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // custom draw the top border
            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5; // MetroFramework source code
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        public void Watch(Request request)
        {
         
        }

        private void CameraItemForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.loadValues();
                this.hookEvents();
 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    
        private void loadValues()
        {
            this.deviceIdTxt.Text = this.camera.cameraCustomId;
            this.badgeIdTxt.Text = this.camera.badgeId;
            this.cardIdtxt.Text = this.camera.cardId;
            this.dateTimeTxt.Text = DateTime.Now.ToString();
            this.camera.settings.aesEncryption = this.aes256chk.Checked ? 1 : 0;

            this.recordingResolutionCombo.DataSource = new Enums().Resolutions;
            this.recordingResolutionCombo.SelectedIndex = this.camera.settings.resolution;

            this.recordingQualityCombo.DataSource = new Enums().Qualities;
            this.recordingQualityCombo.SelectedIndex = this.camera.settings.quality;

            this.recordingCodecFormatCombo.DataSource = Enum.GetValues(typeof(CodecFormats));
            this.recordingCodecFormatCombo.SelectedIndex = this.camera.settings.codecFormat;

            this.preRecordingChk.Checked = this.camera.settings.preRecording;
            this.gpsChk.Checked = this.camera.settings.gps == 1;
            this.wifiChk.Checked = this.camera.settings.wifi == 1;
        }
 
        private void hookEvents()
        {

            this.genDeviceId.Click += onGenerateDeviceId;
            this.deviceIdTxt.OnValueChanged += onDeviceIdChanged;
            this.badgeIdTxt.OnValueChanged += onBadgeIdChanged;
            this.cardIdtxt.OnValueChanged += onCardIdChanged;
            this.syncDateTIme.Click += onSyncTimeClick;
            this.recordingResolutionCombo.SelectionChangeCommitted += onRecordingResolutionChanged;
            this.recordingQualityCombo.SelectionChangeCommitted += onRecordingQualityChanged;
            this.recordingCodecFormatCombo.SelectionChangeCommitted += onRecordingCodecChanged;
            this.preRecordingChk.CheckStateChanged += onPreRecordingChanged;
            this.gpsChk.CheckStateChanged += onGpsChanged;
            this.wifiChk.CheckStateChanged += onWifiChanged;
            this.silentModeChk.CheckStateChanged += onSilentModeChanged;
            this.saveBtn.Click += onSaveBtnClicked;
        }

        private void onGenerateDeviceId(object sender, EventArgs e)
        {
            string generatedID = RandomData.RandomString(this.MIN_ID_LENGTH);
            this.camera.cameraCustomId = generatedID;
            this.camera.settings.cameraCustomId = generatedID;
            this.deviceIdTxt.Text = generatedID;
        }

        private void onDeviceIdChanged(object sender, EventArgs e)
        {
            this.camera.cameraCustomId = this.deviceIdTxt.Text;
            this.camera.settings.cameraCustomId = this.deviceIdTxt.Text;
        }

        private void onBadgeIdChanged(object sender, EventArgs e)
        {
            this.camera.badgeId = this.badgeIdTxt.Text;
            this.camera.settings.badgeId = this.badgeIdTxt.Text;
        }

        private void onCardIdChanged(object sender, EventArgs e)
        {
            this.camera.cardId = this.cardIdtxt.Text;
            this.camera.settings.cardId = this.cardIdtxt.Text;
        }

        private void onSyncTimeClick(object sender, EventArgs e)
        {
            this.dateTimeTxt.Text = DateTime.Now.ToString();
        }

        private void onRecordingResolutionChanged(object sender, EventArgs e)
        {
            string selectedValue = this.recordingResolutionCombo.SelectedValue.ToString();

            if (selectedValue == "1280X720P25")
            {
                selectedValue = "1280X720P20";
            }
            this.camera.settings.resolution = (int)(VideoResolutions)System.Enum.Parse(typeof(VideoResolutions), selectedValue);
        }

        private void onRecordingQualityChanged(object sender, EventArgs e)
        {
            string selectedValue = this.recordingQualityCombo.SelectedValue.ToString();

            if (selectedValue == "Najwyższa")
            {
                selectedValue = "Normal";
            }
            this.camera.settings.quality = (int)(VideoResolutions)System.Enum.Parse(typeof(Qualitys), selectedValue);
        }

        private void onRecordingCodecChanged(object sender, EventArgs e)
        {
            this.camera.settings.codecFormat = (int)this.recordingCodecFormatCombo.SelectedIndex;
        }

        private void onPreRecordingChanged(object sender, EventArgs e)
        {
            this.camera.settings.preRecording = this.preRecordingChk.Checked;
        }

        private void onGpsChanged(object sender, EventArgs e)
        {
            this.camera.settings.gps = this.gpsChk.Checked ? 1 : 0;
        }

        private void onWifiChanged(object sender, EventArgs e)
        {
            this.camera.settings.wifi = this.wifiChk.Checked ? 1 : 0;
        }

        private void onSilentModeChanged(object sender, EventArgs e)
        {
            this.camera.settings.silentMode = this.silentModeChk.Checked ? 1 : 0;
        }

        private async void onSaveBtnClicked(object sender, EventArgs e)
        {

            if (this.camera.cameraCustomId.Length < this.MIN_ID_LENGTH)
            {
                MetroMessageBox.Show(this,String.Format("ID Kamery nie może wynośić mniej niż {0} znaków", this.MIN_ID_LENGTH.ToString()), "Błąd");
                return;
            }

            if (this.camera.badgeId.Length < this.MIN_ID_LENGTH)
            {
                MetroMessageBox.Show(this, String.Format("Numer odznaki nie może wynośić mniej niż {0} znaków", this.MIN_ID_LENGTH.ToString()), "Błąd");

                return;
            }

            CameraEntity camEntity = await this.cameraService.selectCurrentCameraInStation(new SelectCurrentCameraInStationRequestTObject(
                this.camera.cameraCustomId, this.camera.stationId
            ));

            camEntity = await this.cameraService.edit(this.camera.id, new EditCameraRequestTObject(
               this.camera.index,
               this.camera.cameraCustomId,
               this.camera.badgeId,
               this.camera.cardId,
               this.camera.stationId,
               this.camera.driveName,
               this.camera.active
            ));
                         
            _ = this.cameraSettingsService.edit(camEntity.data.id, new EditCameraSettingsTObject(
                camEntity.data.cameraCustomId,
                camEntity.data.badgeId,
                this.camera.settings.cardId,
                this.camera.settings.resolution,
                this.camera.settings.quality,
                this.camera.settings.codecFormat,
                this.camera.settings.preRecording ? 1 : 0,
                this.camera.settings.timeZone,
                this.camera.settings.gps,
                this.camera.settings.wifi,
                this.camera.settings.silentMode,
                this.camera.settings.aesEncryption
            ));

            this.camera = camEntity.data;

            TCPClientTObject client = Globals.Server.Clients.Find((TCPClientTObject obj) => obj.IpAddress == this.station.data.stationIp);
            client.Send(new Request(
               "command://cameras/settings/change",
               this.camera,
               client
            ));

            this.Close();
        }

        public string GetModuleName()
        {
            throw new NotImplementedException();
        }
    }
}
