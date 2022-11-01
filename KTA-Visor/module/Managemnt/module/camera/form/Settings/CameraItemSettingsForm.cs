using Falcon_Protocol.enums;
using KTA_Visor.kernel.generator;
using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.camera.form.Settings.handlers;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
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

        public int Resolution
        {
            get
            {
                if (this.resolutionFirstChk.Checked)
                {
                    return (int)Enums.VideoResolutions.Resolution1920x1080P30;
                }
                else if (this.resolutionSecondChk.Checked)
                {
                    return (int)Enums.VideoResolutions.Resolution1280x720P30;
                }
                else if (this.resolutionThirdChk.Checked)
                {
                    return (int)Enums.VideoResolutions.Resolution1920x1080P20;
                }

                return (int)Enums.VideoResolutions.Resolution1280x720P20;
            }
        }

        public int Quality { get; set; }
        public int Codec { get; set; }
        public int TimeZone { get; set; }

        public string ID
        {
            set { this.idTxt.Text = value; }
            get { return this.idTxt.Text; }
        }

        public string MarkerId
        {
            set { this.markerIdLbl.Text = value; }
            get { return this.markerIdLbl.Text; }
        }

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
        public bool LoopRecording
        {
            set { this.loopRecordingChk.Checked = value; }
            get { return this.loopRecordingChk.Checked; }
        }
        public bool AES
        {
            set { this.aes256chk.Checked = value; }
            get { return this.aes256chk.Checked; }
        }

        private void CameraItemForm_Load(object sender, EventArgs e)
        {
            this.assignDefaultValues();
            this.renderValues();
            this.hookEvents();
        }

        private void assignDefaultValues()
        {
            this.Quality = (int)Enums.Qualitys.Normal;
        }

        private void renderValues()
        {
            this.ID = this.camera.id.ToString();
            this.MarkerId = this.camera.markerId;
            this.CameraId = this.camera.cameraCustomId;
            this.BadgeId = this.camera.badgeId;
            this.CardId = this.camera.cardId;
            this.DateAndTime = DateTime.Now.ToString();
            this.aes256chk.Checked = true;

            this.recordingQualityCombo.DataSource = Enums.Qualities;
            this.recordingQualityCombo.SelectedIndex = 0;
           
            this.recordingCodecFormatCombo.DataSource = Enum.GetValues(typeof(CodecFormats));

            this.PreRecording = this.camera.settings.preRecording;
            this.GPS = this.camera.settings.gps == 1;
            this.WIFI = this.camera.settings.wifi == 1;
            this.SilentMode = this.camera.settings.silentMode == 1;
            this.LoopRecording = this.camera.settings.loopRecording == 1;

            switch(this.camera.settings.resolution)
            {
                case (int)Enums.VideoResolutions.Resolution1920x1080P30:
                    this.resolutionFirstChk.Checked = true;
                    break;

                case (int)Enums.VideoResolutions.Resolution1280x720P30:
                    this.resolutionSecondChk.Checked = true;
                    break;

                case (int)Enums.VideoResolutions.Resolution1920x1080P20:
                    this.resolutionThirdChk.Checked = true;
                    break;
                case (int)Enums.VideoResolutions.Resolution1280x720P20:
                    this.resolutionFourthChk.Checked = true;
                    break;
            }
        }

        private void hookEvents()
        {
            this.genDeviceId.Click += onGenerateDeviceId;
            this.resolutionFirstChk.CheckedChanged += onCheckedFirstResolution;
            this.resolutionSecondChk.CheckedChanged += onCheckedSecondResolution;
            this.resolutionThirdChk.CheckedChanged += onCheckedThirdResolution;
            this.resolutionFourthChk.CheckedChanged += onCheckedFourthResolution;

            this.recordingQualityCombo.SelectionChangeCommitted += onRecordingQualityChanged;
            this.recordingCodecFormatCombo.SelectionChangeCommitted += onCodecChanged;
            this.saveBtn.Click += onSaveBtnClicked;
        }

       
        private void onGenerateDeviceId(object sender, EventArgs e)
        {
            this.CameraId = RandomData.RandomString(this.MIN_ID_LENGTH);
        }

        private void onCheckedFirstResolution(object sender, EventArgs e)
        {
            this.resolutionSecondChk.Checked = false;
            this.resolutionThirdChk.Checked = false;
            this.resolutionFourthChk.Checked = false;
        }

        private void onCheckedSecondResolution(object sender, EventArgs e)
        {
            this.resolutionFirstChk.Checked = false;
            this.resolutionThirdChk.Checked = false;
            this.resolutionFourthChk.Checked = false;
        }

        private void onCheckedThirdResolution(object sender, EventArgs e)
        {
            this.resolutionFirstChk.Checked = false;
            this.resolutionSecondChk.Checked = false;
            this.resolutionFourthChk.Checked = false;
        }

        private void onCheckedFourthResolution(object sender, EventArgs e)
        {
            this.resolutionFirstChk.Checked = false;
            this.resolutionSecondChk.Checked = false;
            this.resolutionThirdChk.Checked = false;
        }

        private void onRecordingQualityChanged(object sender, EventArgs e)
        {
            int quality = (int)Enums.Qualitys.Normal; ;

            if (this.Resolution == (int)VideoResolutions.Resolution1280x720P20){
                quality = (int)Enums.Qualitys.Fine;
            }

            this.Quality = quality;
        }

        private void onCodecChanged(object sender, EventArgs e)
        {
            var selectedValue = this.recordingCodecFormatCombo.SelectedValue.ToString();
            this.Codec = (int)(CodecFormats)Enum.Parse(typeof(CodecFormats), selectedValue);
        }

        private void onSaveBtnClicked(object sender, EventArgs e)
        {
            // Calibrate quality if user didnt clicked
            this.onRecordingQualityChanged(sender, e);

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
