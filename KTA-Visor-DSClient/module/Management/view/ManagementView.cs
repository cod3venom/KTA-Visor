using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.module.Management.module.Camera.view.CamerasPanelView;
using KTA_Visor_DSClient.module.Management.module.PowerSupply.view.PowerSupplyPanelView;
using KTA_Visor_DSClient.module.Management.module.SettingsManager.view.SettingsPanelView;
using KTA_Visor_UI.component.custom.MessageWindow;
using Logger.dto;
using System;
using System.Threading;
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

        }

       
        private void ManagementView_Load(object sender, EventArgs e)
        {
            this.initializeLoggerSettings();
            this.initializeSideBar();
            Program.Relay.turnOnAll(0);
        }

        private void initializeSideBar()
        {

            this.camerasPanel.Dock = DockStyle.Fill;
            this.panelsContainer.Controls.Add(this.camerasPanel);

            this.camerasBtn.OnClick += (async delegate (object _sender, EventArgs evt)
            {
                this.camerasPanel = new CamerasPanelView(this.deviceWatcher);
                this.camerasPanel.Dock = DockStyle.Fill;
                this.panelsContainer.Controls.Clear();
                this.panelsContainer.Controls.Add(this.camerasPanel);
            });

            this.powerSupplyBtn.OnClick += (async delegate (object _sender, EventArgs evt)
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
        }

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
        private void OnClose(object sender, EventArgs e)
        {
            Program.Relay.turnOffAll(0);
            Application.Exit();
        }
    }
}