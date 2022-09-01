using Falcon;
using Falcon.Enums;
using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.Camera.consts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.module.Camera.form.CameraControlForm
{
    public partial class CameraItemForm : Form
    {

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public event EventHandler<EventArgs> OnCloseForm;

        private readonly FalconBridge falconBridge;
 
        private readonly USBCameraDevice camera;

        public CameraItemForm(USBCameraDevice camera, FalconBridge falconBridge)
        {
            InitializeComponent();
            this.falconBridge = falconBridge;
            this.camera = camera;
            this.topBar.Parent = this;
            this.topBar.MinimizeButton.Visible = false;
            this.topBar.ResizeButton.Visible = false;
            this.topBar.onClose += onClose;

            this.topBar.Title = String.Format("Kamera - {0}", camera.BadgeId);
            this.saveBtn.OnClick += onSaveBtnClicked;
        }

  
        private void CameraItemForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.falconBridge.Sdk.CloseDevice();
                Thread.Sleep(1000);
                this.falconBridge.Sdk.ConnectToDevice();

                FalconDeviceInformation deviceInfo = this.falconBridge.Sdk.GetDeviceInformation();
                this.badgeIdTxt.Text = camera.BadgeId;
                this.passwordTxt.Text = "******";
                this.dateTimeTxt.Text = deviceInfo.DeviceDateTime.ToString();


                this.recordingResolutionCombo.DataSource = Enum.GetValues(typeof(VideoResolutions));
                this.recordingResolutionCombo.SelectedIndex = 0;

                this.recordingLengthCombo.DataSource = Enum.GetValues(typeof(VideoSplitTimes));
                this.recordingLengthCombo.SelectedIndex = 0;

                this.recordingQualityCombo.DataSource = Enum.GetValues(typeof(Qualitys));
                this.recordingQualityCombo.SelectedIndex = 0;

                this.recordingCodecFormatCombo.DataSource = Enum.GetValues(typeof(CodecFormats));
                this.recordingCodecFormatCombo.SelectedIndex = 0;

                this.recordingVolumeCombo.DataSource = Enum.GetValues(typeof(Volumes));
                this.recordingVolumeCombo.SelectedIndex = 0;

                this.gpsChk.Checked = (bool)deviceInfo?.GpsStatus;
                this.recordWarningChk.Checked = (bool)deviceInfo?.RecordingWarning;
                this.loopRecordingChk.Checked = (bool)deviceInfo?.LoopRecord;
                this.preRecordingChk.Checked = (bool)deviceInfo?.PreRecord;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void onSaveBtnClicked(object sender, EventArgs e)
        {
            VideoResolutions resolution;
            VideoSplitTimes splitTime;
            Qualitys quality;
            CodecFormats codecFormat;
            Volumes volume;

            Enum.TryParse<VideoResolutions>(this.recordingResolutionCombo.SelectedValue.ToString(), out resolution);
            Enum.TryParse<VideoSplitTimes>(this.recordingLengthCombo.SelectedValue.ToString(), out splitTime);
            Enum.TryParse<Qualitys>(this.recordingQualityCombo.SelectedValue.ToString(), out quality);
            Enum.TryParse<CodecFormats>(this.recordingCodecFormatCombo.SelectedValue.ToString(), out codecFormat);
            Enum.TryParse<Volumes>(this.recordingVolumeCombo.SelectedValue.ToString(), out volume);

            this.falconBridge.Sdk.SetDeviceID(this.badgeIdTxt.Text);
            this.falconBridge.Sdk.SetResolution(resolution);
            this.falconBridge.Sdk.SetVideoSplitTime(splitTime);
            this.falconBridge.Sdk.SetVideoQuality(quality);
            this.falconBridge.Sdk.SetVideoCodecFormat(codecFormat);
            this.falconBridge.Sdk.SetSoundVolume(volume);
            this.falconBridge.Sdk.SetGPS(this.gpsChk.Checked);
            this.falconBridge.Sdk.SetRecordingWarning(this.recordWarningChk.Checked);
            this.falconBridge.Sdk.SetLoopRecord(this.loopRecordingChk.Checked);
            this.falconBridge.Sdk.SetPreRecord(this.preRecordingChk.Checked);

            this.onClose(sender, e);
        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
            this.OnCloseForm?.Invoke(sender, e);
        }

    }
}
