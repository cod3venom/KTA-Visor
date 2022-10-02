using KTA_RFID_Keyboard.module.RFIDKeyboardReader;
using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.module.fileHistory.view.FileHistoryViewPanel;
using System;
using System.Windows.Forms;
using KTA_Visor.module.Managemnt.module.logs.view;
using KTA_Visor.module.Managemnt.sub_window;
using System.ComponentModel;
using KTA_Visor.install.settings;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using KTA_Visor.module.Managemnt.module.card;
using KTA_Visor.module.Managemnt.module.card.events;
using KTA_Visor.module.Managemnt.module.camera.command;
using KTA_Visor.module.Managemnt.module.station.command;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : Form
    {

        private Settings settings;
        private CardReader cardReader;
        private StationViewPanel stationPanel;
        private FileHistoryViewPanel filesHistoryPanel;
        private UserEntity userEntity;
        public Management(UserEntity userEntity)
        {
            InitializeComponent();

            this.settings = new Settings();
            this.filesHistoryPanel = new FileHistoryViewPanel();
            this.cardReader = new CardReader();
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.loggerView.ParentPanel = this.loggerPanel;
            this.stationPanel = new StationViewPanel();
            this.stationPanel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(this.stationPanel);
            this.userEntity = userEntity;
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.initialize();
        }

        private void initialize()
        {
            this.renderData();
            this.hookEvents();
        }

 
        private void renderData()
        {
            this.userProfileCard.FirstAndLastName = String.Format("{0} {1}", this.userEntity.data?.firstName, this.userEntity.data?.lastName);
        }

        private void hookEvents()
        {


            Globals.Logger.OnLogHasWritten += onLogHasWritten;
            Globals.ServerTunnelBackgroundWorker.OnServerStarted += onServerStarted;
            Globals.ServerTunnelBackgroundWorker.OnServerStopped += onServerStopped;
            Globals.ServerTunnelBackgroundWorker.Run();

            this.startTunnelServerMenuItem.Click += onStartTunnelServerMenuItemClick;
            this.stopTunnelServerMenuItem.Click += onStopTunnelServerMenuItemClick;
            this.restartTunnelServerMenuItem.Click += onRestartTunnelServerMenuItemClick;
            this.logsMenuItem.Click += onLogsMenuItemClick;
            this.versionMenuItem.Click += onVersionMenuItemClick;

            this.userProfileCard.OnStationsClick += onStationsClick;
            this.userProfileCard.OnFileHistoryClick += onFileHistoryClick;
            this.userProfileCard.OnTunnelClick += onTunneClick;
            this.userProfileCard.OnLogsClick += onLogsClick;
            this.userProfileCard.OnLogOutclick += onLogoutClick;
            this.userProfileCard.OnFileExplorerClick += onFileExplorerClick;
            this.cardReader.OnCardReaded += onKeyboardInputChanged;
        }

       
        private void onServerStarted(object sender, OnServerStartedEvent e)
        {
            this.tunnelIndicator.running(true, "Uruchomiony");
        }


        private void onServerStopped(object sender, OnServerStoppedEvent e)
        {
            this.tunnelIndicator.running(false, "Wstrzymany");
        }


        private void onStartTunnelServerMenuItemClick(object sender, EventArgs e)
        {
            Globals.ServerTunnelBackgroundWorker.Run();
            this.tunnelIndicator.running(true, "Uruchomiony");
        }


        private void onStopTunnelServerMenuItemClick(object sender, EventArgs e)
        {
            Globals.ServerTunnelBackgroundWorker.Stop();
            this.tunnelIndicator.running(false, "Wstrzymany");
        }

        private void onRestartTunnelServerMenuItemClick(object sender, EventArgs e)
        {
            Globals.ServerTunnelBackgroundWorker.Restart();
            this.tunnelIndicator.running(false, "Uruchomiony");
        }

        private void onLogsMenuItemClick(object sender, EventArgs e)
        {
            new LogsView().ShowDialog();
        }


        private void onVersionMenuItemClick(object sender, EventArgs e)
        {
            new VersionWindow().ShowDialog();
        }

        private void onStationsClick(object sender, EventArgs e)
        {
            this.stationPanel = new StationViewPanel();
            this.contentPanel.Controls.Clear();
            this.stationPanel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(this.stationPanel);
            RestartAllStationsConnectionsCommand.Execute();
        }

        private void onFileHistoryClick(object sender, EventArgs e)
        {
            this.filesHistoryPanel = new FileHistoryViewPanel();
            this.contentPanel.Controls.Clear();
            this.filesHistoryPanel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(this.filesHistoryPanel);
        }

        private void onTunneClick(object sender, EventArgs e)
        {
            new TunnelWindow().ShowDialog();
            return;
        }

        private void onFileExplorerClick(object sender, EventArgs e)
        {
            new FileExplorerWindow(this.settings.SettingsObj.app?.fileSystem?.filesPath).ShowDialog();
        }

        private void onLogsClick(object sender, EventArgs e)
        {
            new LogsView().ShowDialog();
        }

        private void onLogoutClick(object sender, EventArgs e)
        {
            Application.Restart();
        }


        private void onKeyboardInputChanged(object sender, OnCardReadedEvent e)
        {
            
            
            
            Globals.READED_CARD_INPUT = e.CardId;
            Globals.Logger.info(String.Format("Scanned CARD INPUT: {0}", Globals.READED_CARD_INPUT));

            BlinkCameraInstationBasedOnCardIdCommand.Execute(e.CardId);
        }

        private void onLogHasWritten(object sender, Logger.dto.LoggerEvent e)
        {
            this.loggerView.append(e.Log, e.Color);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Globals.ServerTunnelBackgroundWorker.Stop();
            Application.Exit();
        }

    }
}
