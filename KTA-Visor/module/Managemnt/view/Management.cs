using KTA_RFID_Keyboard.module.RFIDKeyboardReader;
using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.module.fileManager.view.FileHistoryViewPanel;
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
using MetroFramework.Forms;
using KTA_Visor.module.Managemnt.view;
using KTAVisorAPISDK.module.auth.entity;
using System.Threading;
using KTAVisorAPISDK.module.user.abstraction;
using KTA_Visor.kernel.module.ThreadPool;
using System.Threading.Tasks;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : MetroForm
    {

        private Settings settings;
        private CardReader cardReader;
        private StationViewPanel stationPanel;
        private FileManagerViewPanel filesHistoryPanel;
        private UserDataAbstraction user;
        public Management(UserDataAbstraction user)
        {
            InitializeComponent();

            this.settings = new Settings();
            this.filesHistoryPanel = new FileManagerViewPanel();
            this.cardReader = new CardReader();
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.loggerView.ParentPanel = this.loggerPanel;
            this.stationPanel = new StationViewPanel();
            this.stationPanel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(this.stationPanel);
            this.user = user;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private async void StationsView_Load(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            this.initialize();
        }

        private void initialize()
        {
            this.hookEvents();
            this.renderData();
        }

 
        private void renderData()
        {
            this.userProfileCard.FirstAndLastName = String.Format("{0} {1}", this.user.data?.firstName, this.user.data?.lastName);
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
            this.profileMenuItem.Click += this.onProfileClick;
            this.securityMenuItem.Click += this.onAccountSecurityClick;
            this.logoutMenuItem.Click += this.onLogoutClick;
            this.logsMenuItem.Click += this.onLogsClick;
            this.versionMenuItem.Click += onVersionMenuItemClick;

            this.userProfileCard.OnProfileClick += onProfileClick;
            this.userProfileCard.OnAccountSecurityClick += onAccountSecurityClick;
            this.userProfileCard.OnStationsClick += onStationsClick;
            this.userProfileCard.OnFileHistoryClick += onFileHistoryClick;
            this.userProfileCard.OnTunnelClick += onTunneClick;
            this.userProfileCard.OnLogsClick += onLogsClick;
            this.userProfileCard.OnLogOutclick += onLogoutClick;
            this.userProfileCard.OnFileExplorerClick += onFileExplorerClick;
            this.userProfileCard.OnSettingsClick += onSettingsClick;
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
 

        private void onVersionMenuItemClick(object sender, EventArgs e)
        {
            new VersionWindow().ShowDialog();
        }

        private void onProfileClick(object sender, EventArgs e)
        {
            ThreadPoolManager.RenderForm(new UserProfileWindow());
        }

        private void onAccountSecurityClick(object sender, EventArgs e)
        {
        }

        private void onStationsClick(object sender, EventArgs e)
        {
            RestartAllStationsConnectionsCommand.Execute();
            this.stationPanel = new StationViewPanel();
            this.displayPanel(this.stationPanel);
        }

        private void onFileHistoryClick(object sender, EventArgs e)
        {
            this.filesHistoryPanel = new FileManagerViewPanel();
            this.displayPanel(this.filesHistoryPanel);
        }

        private void onTunneClick(object sender, EventArgs e)
        {
            ThreadPoolManager.RenderForm(new TunnelWindow());
        }

        private void onFileExplorerClick(object sender, EventArgs e)
        {
            new FileExplorerWindow(this.settings.SettingsObj.app?.fileSystem?.filesPath).ShowDialog();
        }

        private void onLogsClick(object sender, EventArgs e)
        {
            new LogsView().ShowDialog();
        }

        private void onSettingsClick(object sender, EventArgs e)
        {
            new SettingsEntryPoint().ShowDialog();
        }

        private void displayPanel(Control panel)
        {
            this.contentPanel.Controls.Clear();
            panel.Dock = DockStyle.Fill;
            this.contentPanel.Controls.Add(panel);
        }

        private void onKeyboardInputChanged(object sender, OnCardReadedEvent e)
        { 
            Globals.READED_CARD_INPUT = e.CardId;
            Globals.Logger.info(String.Format("Scanned CARD INPUT: {0}", Globals.READED_CARD_INPUT));
            
            BlinkCameraInstationBasedOnCardIdCommand.Execute(Globals.READED_CARD_INPUT);
        }

        private void onLogHasWritten(object sender, Logger.dto.LoggerEvent e)
        {
            ThreadPoolManager.Run(this, ((Action)delegate {
                this.loggerView.append(e.Log, e.Color);
            }));
        }

        private void onLogoutClick(object sender, EventArgs e)
        {
            Application.Restart();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Globals.ServerTunnelBackgroundWorker.Stop();
            Application.Exit();
        }

    }
}
