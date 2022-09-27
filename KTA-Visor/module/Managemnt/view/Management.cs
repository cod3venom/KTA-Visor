using KTA_RFID_Keyboard.module.RFIDKeyboardReader;
using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.module.fileHistory.view.FileHistoryViewPanel;
using System;
using System.Windows.Forms;
using KTA_Visor.module.Managemnt.module.logs.view;
using KTA_Visor.module.Managemnt.sub_window;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : Form
    {

        private  KeyboardReader keyboardReader;
        private  StationViewPanel stationPanel;
        private  FileHistoryViewPanel filesHistoryPanel;
        
        public Management()
        {
            InitializeComponent();
  
            this.loggerView.ParentPanel = this.loggerPanel;
            this.keyboardReader = new KeyboardReader();
            this.stationPanel = new StationViewPanel();
            this.filesHistoryPanel = new FileHistoryViewPanel();
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            Program.Logger.OnLogHasWritten += onLogHasWritten;
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
        }

        private void initializeTunnelBackgroundWoerker()
        {
            Globals.ServerTunnelBackgroundWorker.OnServerStarted += (delegate (object sender, OnServerStartedEvent e)
            {
                this.tunnelIndicator.running(true, "Uruchomiony");
            });

            Globals.ServerTunnelBackgroundWorker.OnServerStopped += (delegate (object sender, OnServerStoppedEvent e)
            {
                this.tunnelIndicator.running(false, "Wstrzymany");
            });

            Globals.ServerTunnelBackgroundWorker.Run();
        }

        private void initializeButtons()
        {

            this.startTunnelServerMenuItem.Click += (delegate (object sender, EventArgs e)
            {
                Globals.ServerTunnelBackgroundWorker.Run();
                this.tunnelIndicator.running(true, "Uruchomiony");
            });
            
            this.stopTunnelServerMenuItem.Click += (delegate (object sender, EventArgs e){
                Globals.ServerTunnelBackgroundWorker.Stop();
                this.tunnelIndicator.running(false, "Wstrzymany");
            });

            this.restartTunnelServerMenuItem.Click += (delegate (object sender, EventArgs e) {
                Globals.ServerTunnelBackgroundWorker.Restart();
                this.tunnelIndicator.running(false, "Uruchomiony");
            });

            this.logsMenuItem.Click += (delegate (object sender, EventArgs e) {
                new LogsView().ShowDialog();
            });

            this.versionMenuItem.Click += (delegate (object sender, EventArgs e) {
                new VersionWindow().ShowDialog();
            });

            this.stationBtn.OnClick += (delegate (object sender, EventArgs e){
                this.stationPanel = new StationViewPanel();
                this.contentPanel.Controls.Clear();
                this.stationPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(this.stationPanel);
            });

            this.filesHistoryBtn.OnClick += (delegate (object sender, EventArgs e) {
                this.filesHistoryPanel = new FileHistoryViewPanel();
                this.contentPanel.Controls.Clear();
                this.filesHistoryPanel.Dock = DockStyle.Fill;
                this.contentPanel.Controls.Add(this.filesHistoryPanel);
            });

            this.logoutbtn.Click += (delegate (object sender, EventArgs e) {
                Application.Restart();
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

        private void onCLose(object sender, EventArgs e)
        {
            Globals.ServerTunnelBackgroundWorker.Stop();
            Environment.Exit(-1);
        }

    }
}
