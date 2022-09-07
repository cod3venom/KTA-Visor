using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.module.Management.module.Camera.view.CamerasPanelView;
using KTA_Visor_DSClient.module.Management.module.PowerSupply.view.PowerSupplyPanelView;
using KTA_Visor_DSClient.module.Management.module.SettingsManager.view.SettingsPanelView;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.station.dto;
using System;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.view
{
    public partial class ManagementView : Form
    {

        private readonly Settings settings;
        private readonly KTALogger.Logger logger;

        /// <summary>
        /// 
        /// </summary>
        private PowerSupplyPanelView powerSupplyPanel;

        /// <summary>
        /// 
        /// </summary>
        private CamerasPanelView camerasPanel;


        /// <summary>
        /// 
        /// </summary>
        private SettingsPanelView settingsPanel;


        /// <summary>
        /// 
        /// </summary>
        private readonly DeviceWatcher deviceWatcher;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public ManagementView(KTALogger.Logger logger)
        {
            InitializeComponent();

            this.logger = logger;
            this.deviceWatcher = new DeviceWatcher();
            this.settings = new Settings();

            this.topBar.Parent = this;
            this.topBar.Title = this.settings.SettingsObj.app.title;
            this.topBar.onClose += OnClose;
            this.loggerView.ParentPanel = this.loggerViewPanel;

            this.powerSupplyPanel = new PowerSupplyPanelView();
            this.camerasPanel = new CamerasPanelView(this.deviceWatcher);
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;

            Application.ApplicationExit += onApplicationExit;
        }

        private void ManagementView_Load(object sender, EventArgs e)
        {
            this.initializeLoggerSettings();
            this.initializeControls();
            Program.Relay.turnOnAll(0);
        }

        private void initializeControls()
        {

            this.camerasPanel.Dock = DockStyle.Fill;
            this.panelsContainer.Controls.Add(this.camerasPanel);

            this.camerasBtn.OnClick += ( delegate (object _sender, EventArgs evt)
            {
                this.camerasPanel = new CamerasPanelView(this.deviceWatcher);
                this.camerasPanel.Dock = DockStyle.Fill;
                this.panelsContainer.Controls.Clear();
                this.panelsContainer.Controls.Add(this.camerasPanel);
            });

            this.powerSupplyBtn.OnClick += ( delegate (object _sender, EventArgs evt)
            {
                this.powerSupplyPanel= new PowerSupplyPanelView();
                this.powerSupplyPanel.Dock = DockStyle.Fill;
                this.panelsContainer.Controls.Clear();
                this.panelsContainer.Controls.Add(this.powerSupplyPanel);
            });

            this.settingsBtn.Click += (delegate (object _sender, EventArgs evt)
            {
                this.settingsPanel = new SettingsPanelView();
                this.settingsPanel.Dock = DockStyle.Fill;
                this.panelsContainer.Controls.Clear();
                this.panelsContainer.Controls.Add(this.settingsPanel);
            });

            this.connectToTunelMenuItem.Click += (delegate (object _sender, EventArgs evt) {
                Program.TunnelBackgroundWrorker.Run();
            });
            this.restartTunelMenuItem.Click += (delegate (object _sender, EventArgs evt) {
                Program.TunnelBackgroundWrorker.Restart();
            });
            this.disconnectFromTunelMenuItem.Click += (delegate (object _sender, EventArgs evt) {
                Program.TunnelBackgroundWrorker.Stop();
            });

            this.backendRegisterMenuItem.Click += (async delegate (object _sender, EventArgs evt) {
                await Program.StationService.create(new CreateStationRequestTObject(
                    this.settings.SettingsObj.app.station.stationId,
                    this.settings.SettingsObj.app.station.ipAddress,
                    this.settings.SettingsObj.app.rdp.userName,
                    this.settings.SettingsObj.app.rdp.password
                ));
            });

            this.backendUpdateMenuItem.Click += (async delegate (object _sender, EventArgs evt) {
                await Program.StationService.edit(Globals.STATION?.data?.id, new EditStationRequestTObject(
                    this.settings.SettingsObj.app.station.stationId,
                    this.settings.SettingsObj.app.station.ipAddress,
                    true
                ));
            });

        }

        /// <summary>
        /// 
        /// </summary>
        private void initializeLoggerSettings()
        {
            Program.logger.OnLogHasWritten += (delegate (object sender, Logger.dto.LoggerEvent e) {
                this.loggerView.append(e.Log);
            });
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private async void onApplicationExit(object sender, EventArgs e)
        {
            EditStationRequestTObject request = new EditStationRequestTObject(
                Globals.STATION.data.stationId,
                Globals.STATION.data.stationIp,
                false
            );
            await Program.StationService.edit(Globals.STATION.data.id, request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, EventArgs e)
        {
            Program.Relay.turnOffAll(0);
            Application.Exit();
        }
    }
}