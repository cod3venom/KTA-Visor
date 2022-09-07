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

namespace KTA_Visor.module.Managemnt.module.camera.form
{
    public partial class CameraItemSettingsForm : Form
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

        private readonly USBCameraDevice camera;

        public CameraItemSettingsForm(USBCameraDevice camera)
        {
            InitializeComponent();
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
                
                this.badgeIdTxt.Text = camera.BadgeId;
                this.passwordTxt.Text = "******";
                this.dateTimeTxt.Text = DateTime.Now.ToString();


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

                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void onSaveBtnClicked(object sender, EventArgs e)
        {
            this.onClose(sender, e);
        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
            this.OnCloseForm?.Invoke(sender, e);
        }

    }
}
