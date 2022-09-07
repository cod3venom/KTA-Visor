using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor.module.Managemnt.workers.tunnel;
using System;
using System.Windows.Forms;
using KTA_RFID_Keyboard.module.RFIDKeyboardReader;
using KTA_Visor.module.Managemnt.module.officer.view.OfficersViewPanel;
using KTA_Visor.module.Managemnt.module.camera.views.CameraViewPanel;
using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Managemnt.module.tunnel.view.TunnelSettingsPanelView;
using TCPTunnel.module.server.events;
using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.events;
using TCPTunnel.kernel.extensions.router.dto;
using KTA_Visor.module.Managemnt.module.fileHistory.view.FileHistoryViewPanel;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly KeyboardReader keyboardReader;


        /// <summary>
        /// 
        /// </summary>
        private readonly StationViewPanel stationPanel;

        /// <summary>
        /// 
        /// </summary>
        private readonly CamerasViewPanel camerasPanel;

        /// <summary>
        /// 
        /// </summary>
        private readonly OfficersPanelView officersPanel;

        /// <summary>
        /// 
        /// </summary>
        private readonly FileHistoryViewPanel filesHistoryPanel;

        /// <summary>
        /// 
        /// </summary>
        /// 
        private readonly TunnelSettingsViewPanel tunnelSettingsPanel;
        public Management()
        {
            InitializeComponent();
            this.topBar.Parent = this;
            this.loggerView.ParentPanel = this.loggerPanel;
            this.keyboardReader = new KeyboardReader();
            this.stationPanel = new StationViewPanel();
            this.camerasPanel = new CamerasViewPanel();
            this.officersPanel = new OfficersPanelView();
            this.filesHistoryPanel = new FileHistoryViewPanel();
            this.tunnelSettingsPanel = new TunnelSettingsViewPanel();
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.renderDefaultPanel();
            this.initialize();
        }

        private void renderDefaultPanel()
        {
            this.stationPanel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(this.stationPanel);
        }

        private void initialize()
        {
            this.initializeButtons();
            this.initializeRFIDReader();
            this.initializeTunnelBackgroundWoerker();

            Program.Logger.OnLogHasWritten += onLogHasWritten;
        }

        private void initializeTunnelBackgroundWoerker()
        {
            Program.TunnelBackgroundWorker.OnServerStarted += (delegate (object sender, OnServerStartedEvent e)
            {
                this.tunnelIndicator.running(true, "Uruchomiony");
            });

            Program.TunnelBackgroundWorker.OnServerStopped += (delegate (object sender, OnServerStoppedEvent e)
            {
                this.tunnelIndicator.running(false, "Wstrzymany");
            });


            Program.TunnelBackgroundWorker.OnClientConnected += (delegate (object sender, OnClientConnected e)
            {
               
            });

            Program.TunnelBackgroundWorker.OnClientDisconnected += (delegate (object sender, OnClientDisconnected e)
            {
                
            });

            Program.TunnelBackgroundWorker.Run();
        }

        private void initializeButtons()
        {

            this.startTunnelServerMenuItem.Click += (delegate (object sender, EventArgs e)
            {
                Program.Tunnel.start();
                this.tunnelIndicator.running(true, "Uruchomiony");
            });
            this.stopTunnelServerMenuItem.Click += (delegate (object sender, EventArgs e){
                Program.Tunnel.stop();
                this.tunnelIndicator.running(false, "Wstrzymany");
            });

            this.tunnelSettingsBtn.OnClick += (delegate(object sender, EventArgs e) {
                this.contentPanel.Controls.Clear();
                tunnelSettingsPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(tunnelSettingsPanel);
            });

            this.officersBtn.OnClick += (delegate (object sender, EventArgs e) {
                this.contentPanel.Controls.Clear();
                this.officersPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(this.officersPanel);
            });

            this.cameraBtn.OnClick += (delegate (object sender, EventArgs e) {
                this.contentPanel.Controls.Clear();
                this.camerasPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(this.camerasPanel);
            });

            this.stationBtn.OnClick += (delegate (object sender, EventArgs e){
                this.contentPanel.Controls.Clear();
                this.stationPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(this.stationPanel);
            });

            this.filesHistoryBtn.OnClick += (delegate (object sender, EventArgs e) {
                this.contentPanel.Controls.Clear();
                this.filesHistoryPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(this.filesHistoryPanel);
            });

        }

        private void initializeRFIDReader()
        {
            this.keyboardReader.Subscribe();
            this.keyboardReader.OnKeyboardInputChanged += (delegate(object sender, KTA_RFID_Keyboard.module.reader.events.OnKeyboardReaderDataChanagedEvent e)
            {
                Globals.READED_CARD_INPUT = e.Input;
                Program.Logger.info(String.Format("Scanned CARD INPUT: {0}", Globals.READED_CARD_INPUT));
            });
        }
       
        private void onLogHasWritten(object sender, Logger.dto.LoggerEvent e)
        {
           this.loggerView.append(e.Log);
        }

        private void StationsView_OnClose(object sender, EventArgs e)
        {
            Program.Tunnel.stop();
            Environment.Exit(-1);
        }

    }
}
