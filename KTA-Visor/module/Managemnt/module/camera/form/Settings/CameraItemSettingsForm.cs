using Falcon_Protocol.enums;
using KTA_Visor.kernel.generator;
using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.camera.form.Settings.handlers;
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

        private readonly SettingsHandler settingsHandler;
        public CameraItemSettingsForm(CameraEntity.Camera camera, StationEntity station)
        {
            InitializeComponent();

            this.settingsHandler = new SettingsHandler(this, camera, station);
            this.camera = camera;
            this.station = station;
        }

        public int Resolution { get; set; }
        public int Quality { get; set; }
        public int Codec { get; set; }
        public int TimeZone { get; set; }

        public string CameraId 
        {
            set { this.deviceIdTxt.Text = value;  }
            get { return this.deviceIdTxt.Text; }
        }

        public string BadgeId {
            set { this.badgeIdTxt.Text = value; }
            get { return this.badgeIdTxt.Text; }
        }
        public string CardId
        {
            set { this.cardIdtxt.Text = value; }
            get { return this.cardIdtxt.Text; }
        }

        public string DateAndTime
        {
            set { this.dateTimeTxt.Text = value; }
            get { return this.dateTimeTxt.Text; }
        }
       
        public bool PreRecording
        {
            set { this.preRecordingChk.Checked = value; }
            get { return this.preRecordingChk.Checked;}
        }
        public bool GPS
        {
            set { this.gpsChk.Checked = value; }
            get { return this.gpsChk.Checked; }
        }
        public bool WIFI
        {
            set { this.wifiChk.Checked = value; }
            get { return this.wifiChk.Checked; }
        }
        public bool SilentMode
        {
            set { this.silentModeChk.Checked = value; }
            get { return this.silentModeChk.Checked; }
        }
        public bool AES
        {
            set { this.aes256chk.Checked = value; }
            get { return this.aes256chk.Checked; }
        }

      
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void CameraItemForm_Load(object sender, EventArgs e)
        {
            this.renderValues();
            this.hookEvents();
        }

        private void renderValues()
        {
            this.CameraId = this.camera.cameraCustomId;
            this.BadgeId = this.camera.badgeId;
            this.CardId = this.camera.cardId;
            this.DateAndTime = DateTime.Now.ToString();
            this.aes256chk.Checked = true;

            this.recordingResolutionCombo.DataSource = new Enums().Resolutions;
            this.recordingResolutionCombo.SelectedIndex = this.camera.settings.resolution;

            this.recordingQualityCombo.DataSource = new Enums().Qualities;
            this.recordingQualityCombo.SelectedIndex = this.camera.settings.quality;

            this.recordingCodecFormatCombo.DataSource = Enum.GetValues(typeof(CodecFormats));
            this.recordingCodecFormatCombo.SelectedIndex = this.camera.settings.codecFormat;

            this.PreRecording = this.camera.settings.preRecording;
            this.GPS = this.camera.settings.gps == 1;
            this.WIFI = this.camera.settings.wifi == 1;
        }

        private void hookEvents()
        {
            this.genDeviceId.Click += onGenerateDeviceId;
            this.recordingResolutionCombo.SelectionChangeCommitted += onRecordingResolutionChanged;
            this.recordingQualityCombo.SelectionChangeCommitted += onRecordingQualityChanged;
            this.recordingCodecFormatCombo.SelectionChangeCommitted += onCodecChanged;
            this.saveBtn.Click += onSaveBtnClicked;
        }

        private void onGenerateDeviceId(object sender, EventArgs e)
        {
            this.CameraId = RandomData.RandomString(this.MIN_ID_LENGTH);
        }
 
        private void onRecordingResolutionChanged(object sender, EventArgs e)
        {
            string selectedValue = this.recordingResolutionCombo.SelectedValue.ToString();
            if (selectedValue == "Resolution1280X720P25"){
                selectedValue = "Resolution1280X720P20";
            }

            this.camera.settings.resolution = (int)(VideoResolutions)Enum.Parse(typeof(VideoResolutions), selectedValue);
        }

        private void onRecordingQualityChanged(object sender, EventArgs e)
        {
            string selectedValue = this.recordingQualityCombo.SelectedValue.ToString();

            if (selectedValue == "Najwyższa"){
                selectedValue = "Normal";
            }

            this.Quality = (int)(Qualitys)Enum.Parse(typeof(Qualitys), selectedValue);
        }


        private void onCodecChanged(object sender, EventArgs e)
        {
            var selectedValue = this.recordingCodecFormatCombo.SelectedValue.ToString();
            this.Codec = (int)(CodecFormats)Enum.Parse(typeof(CodecFormats), selectedValue);
        }

        private void onSaveBtnClicked(object sender, EventArgs e)
        {

            this.settingsHandler.Save();
        }

        public void Watch(Request request)
        {
        }


        public string GetModuleName()
        {
            return "";
        }
    }
}
