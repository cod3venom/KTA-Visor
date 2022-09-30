using Falcon_Protocol.enums;
using KTA_Visor.kernel.generator;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using static Falcon_Protocol.enums.Enums;

namespace KTA_Visor.module.Managemnt.module.camera.form
{
    public partial class CameraItemSettingsForm : Form
    {

        public event EventHandler<EventArgs> OnCloseForm;

        private int MIN_ID_LENGTH = 15;
        private  CameraEntity.Camera camera;
        private readonly StationEntity station;
        private readonly CameraSettingsService cameraSettingsService;
        private readonly CameraService cameraService;

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

        public CameraItemSettingsForm(CameraEntity.Camera camera, StationEntity station)
        {
            InitializeComponent();
            this.camera = camera;
            this.topBar.Parent = this;
            this.topBar.MinimizeButton.Visible = false;
            this.topBar.ResizeButton.Visible = false;
            this.topBar.onClose += onClose;

            this.topBar.Title = String.Format("Kamera - {0}", camera.badgeId);
            this.station = station;
            this.cameraSettingsService = new CameraSettingsService();
            this.cameraService = new CameraService();
        }

  
        private void CameraItemForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.genDeviceId.Click += (delegate (object _sender, EventArgs _e){
                    string generatedID = RandomData.RandomString(this.MIN_ID_LENGTH);
                    this.camera.cameraCustomId = generatedID;
                    this.camera.settings.cameraCustomId = generatedID;
                    this.deviceIdTxt.Text = generatedID;
                });
                this.deviceIdTxt.OnValueChanged += (delegate (object _sender, EventArgs _e) {
                    this.camera.cameraCustomId = this.deviceIdTxt.Text;
                    this.camera.settings.cameraCustomId = this.deviceIdTxt.Text;
                });

                this.genBadgeId.Click += (delegate (object _sender, EventArgs _e){
                    string generatedID = RandomData.RandomString(this.MIN_ID_LENGTH);
                    this.camera.badgeId = generatedID;
                    this.camera.settings.badgeId = generatedID;
                    this.badgeIdTxt.Text = generatedID;
                });

                this.genCardId.Click += (delegate (object _sender, EventArgs _e) {
                    string genCardId = RandomData.RandomString(this.MIN_ID_LENGTH);
                    this.camera.cardId= genCardId;
                    this.camera.settings.cardId = genCardId;
                    this.cardIdtxt.Text = genCardId;
                });

                this.badgeIdTxt.OnValueChanged += (delegate (object _sender, EventArgs _e) {
                    this.camera.badgeId = this.badgeIdTxt.Text;
                    this.camera.settings.badgeId = this.badgeIdTxt.Text;
                });

                this.cardIdtxt.OnValueChanged += (delegate (object _sender, EventArgs _e) {
                    this.camera.cardId= this.cardIdtxt.Text;
                    this.camera.settings.cardId = this.cardIdtxt.Text;
                });
                this.syncDateTIme.Click += (delegate(object _sender, EventArgs _e) {
                    this.dateTimeTxt.Text = DateTime.Now.ToString();
                });
                this.recordingResolutionCombo.SelectionChangeCommitted += (delegate (object _sender, EventArgs _e) {
                    this.camera.settings.resolution = (int)this.recordingResolutionCombo.SelectedIndex;
                });
                this.recordingQualityCombo.SelectionChangeCommitted += (delegate (object _sender, EventArgs _e) {
                    this.camera.settings.quality = (int)this.recordingQualityCombo.SelectedIndex;
                });
                this.recordingCodecFormatCombo.SelectionChangeCommitted += (delegate (object _sender, EventArgs _e) {
                    this.camera.settings.codecFormat = (int)this.recordingCodecFormatCombo.SelectedIndex;
                });
                this.preRecordingChk.CheckStateChanged += (delegate (object _sender, EventArgs _e) {
                    this.camera.settings.preRecording = this.preRecordingChk.Checked;
                });
                this.gpsChk.CheckStateChanged += (delegate (object _sender, EventArgs _e){
                    this.camera.settings.gps = this.gpsChk.Checked ? 1 : 0;
                });
                this.wifiChk.CheckStateChanged += (delegate (object _sender, EventArgs _e) {
                    this.camera.settings.wifi = this.wifiChk.Checked ? 1 : 0;
                });


                this.deviceIdTxt.Text = this.camera.cameraCustomId;
                this.badgeIdTxt.Text = this.camera.badgeId;
                this.cardId.Text = this.camera.cardId;
                this.dateTimeTxt.Text = DateTime.Now.ToString();

                
                this.recordingResolutionCombo.DataSource = new Enums().ResolutionValues();
                this.recordingResolutionCombo.SelectedIndex = this.camera.settings.resolution;

                this.recordingQualityCombo.DataSource = Enum.GetValues(typeof(Qualitys));
                this.recordingQualityCombo.SelectedIndex = this.camera.settings.quality;

                this.recordingCodecFormatCombo.DataSource = Enum.GetValues(typeof(CodecFormats));
                this.recordingCodecFormatCombo.SelectedIndex = this.camera.settings.codecFormat;

                this.preRecordingChk.Checked = this.camera.settings.preRecording;
                this.gpsChk.Checked = this.camera.settings.gps == 1;
                this.wifiChk.Checked = this.camera.settings.wifi == 1;

                this.saveBtn.OnClick += onSaveBtnClicked;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

 
 
        private async void onSaveBtnClicked(object sender, EventArgs e)
        {

            if (this.camera.cameraCustomId.Length < this.MIN_ID_LENGTH)
            {
                new AlertWindow(String.Format("ID Kamery nie może wynośić mniej niż {0} znaków", this.MIN_ID_LENGTH.ToString()));
                return;
            }

            if (this.camera.badgeId.Length < this.MIN_ID_LENGTH)
            {
                new AlertWindow(String.Format("Numer odznaki nie może wynośić mniej niż {0} znaków", this.MIN_ID_LENGTH.ToString()));
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
                this.camera.settings.aesEncryption
            ));

            this.camera = camEntity.data;

            Globals.ServerTunnelBackgroundWorker.sendRequest(this.station.data.stationIp, new Request(
               "command://cameras/settings/change",
               this.camera
           ));

            this.Close();
        }
 
        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
