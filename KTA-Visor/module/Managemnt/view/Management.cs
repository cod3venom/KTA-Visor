using KTA_Visor.module.Shared.Global;
using System;
using System.Windows.Forms;
using KTA_Visor.install.settings;
using MetroFramework.Forms;
using KTAVisorAPISDK.module.user.abstraction;
using System.Threading.Tasks;
using KTA_Visor.kernel.sharedKernel.types;
using KTA_Visor.module.Managemnt.module.station;
using KTA_Visor.module.Managemnt.module.fileManager;
using KTA_Visor.module.Managemnt.module.logs;
using KTA_Visor.module.Managemnt.module.clientsManager;
using KTA_Visor.module.Managemnt.interfaces;
using System.Collections.Generic;
using KTA_Visor.module.Managemnt.uiHandler;
using KTA_Visor_UI.component.basic.StatusIndicator;
using KTA_Visor_UI.component.custom.LoggerView;
using System.Drawing;
using KTA_Visor.module.Managemnt.module.cardReader;
using KTA_Visor.module.Managemnt.module.users;
using KTA_Visor.module.Managemnt.module.users.component.UserSidebarCard;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : MetroForm
    {
        public event EventHandler<EventArgs> OnClose;

        private List<IUIHandlerInterface> UIHandlers;
 
        public Management(UserDataAbstraction user)
        {
            InitializeComponent();

            this.User = user;
            this.Settings = new Settings();
            this.ClientsManagerModule = new ClientsManagerModule();

            this.StationModule = new StationModule(this);
            this.UsersModule = new UsersModule();
            this.FileManagerModule = new FileManagerModule(user);
            this.LogsModule = new LogsModule();
            this.CardReaderModule = new CardReaderModule();
            this.Modules = new ModulesManager()
            {
                this.ClientsManagerModule,
                this.StationModule,
                this.UsersModule,
                this.FileManagerModule,
                this.LogsModule,
                this.CardReaderModule
            };

            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.UIHandlers = new List<IUIHandlerInterface>() { 
                new TopBarMenuUIHandler(this),
                new SideBarUIHandler(this),
                new ClientListUIHandler(this),
                new LogsUIHandler(this),
                new RequestsFlowUIHandler(this),
                new DefaultViewUIHandler(this),
            };
        }

        private async void StationsView_Load(object sender, EventArgs e)
        {
            await Task.Delay(500);
            this.hookEvents();
            this.initializeUI();
            this.initialize();
        }

        private void hookEvents()
        {
            this.FormClosing += onClosing;
        }

        private void initializeUI()
        {
            this.SideBar = new UserSidebarCard(this.User.data.roles[0]);
            this.SideBar.Dock = DockStyle.Fill;
            this.sidebarPanel.Controls.Add(SideBar);
        }

        private void initialize()
        {
            this.UIHandlers.ForEach((IUIHandlerInterface handler) => handler.Handle());
        }
  
        public UserDataAbstraction User { get; set; }
        public Settings Settings { get; set; }
        public ModulesManager Modules { get; set; }


        public StationModule StationModule { get; set; }
        public UsersModule UsersModule { get; set; }
        public FileManagerModule FileManagerModule { get; set; }
        public LogsModule LogsModule { get; set; }
        public CardReaderModule CardReaderModule { get; set; }
        public ClientsManagerModule ClientsManagerModule { get; set; }

        public UserSidebarCard SideBar { get; set; }
        public LoggerView LoggerView { get { return this.loggerView; } }
        public StatusIndicator TunnelIndicator { get { return this.tunnelIndicator; } }
        public Control Content { get { return this.contentPanel; } }
        public Control ClientsManagerPanel { get { return this.clientsManagerPanel; } }
        public Control LoggerPanel { get { return this.loggerPanel; } }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);
            Globals.Server.Stop();
            this.OnClose?.Invoke(this, e);
        }

    }
}
