using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.events;
using System;
using System.Windows.Forms;
using KTA_Visor.module.Managemnt.module.logs.view;
using KTA_Visor.module.Managemnt.sub_window;
using System.ComponentModel;
using KTA_Visor.install.settings;
using KTA_Visor.module.Managemnt.module.card;
using KTA_Visor.module.Managemnt.module.card.events;
using KTA_Visor.module.Managemnt.module.camera.command;
using KTA_Visor.module.Managemnt.module.station.command;
using MetroFramework.Forms;
using KTA_Visor.module.Managemnt.view;
using KTAVisorAPISDK.module.user.abstraction;
using KTA_Visor.kernel.module.ThreadPool;
using System.Threading.Tasks;
using KTA_Visor.kernel.sharedKernel.types;
using KTA_Visor.module.Managemnt.module.station;
using KTA_Visor.module.Managemnt.module.fileManager;
using KTA_Visor.module.Managemnt.module.logs;
using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.clientsManager;
using KTA_Visor_UI.component.custom.User.UserProfile;
using KTA_Visor.module.Managemnt.interfaces;
using System.Collections.Generic;
using KTA_Visor.module.Managemnt.uiHandler;
using KTA_Visor_UI.component.basic.StatusIndicator;
using KTA_Visor_UI.component.custom.LoggerView;
using System.Drawing;

namespace KTA_Visor.module.Management.view
{
    public partial class Management : MetroForm
    {

        private List<IUIHandlerInterface> UIHandlers;

        public Management(UserDataAbstraction user)
        {
            InitializeComponent();

            this.User = user;
            this.Settings = new Settings();
            this.ClientsManagerModule = new ClientsManagerModule();
            
            this.Modules = new ModulesManager()
            {
                this.ClientsManagerModule,
                new StationModule(),
                new FileManagerModule(),
                new LogsModule()
            };

            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.UIHandlers = new List<IUIHandlerInterface>() { 
                new DefaultViewUIHandler(this),
                new TopBarMenuUIHandler(this),
                new SideBarUIHandler(this),
                new ClientListUIHandler(this),
                new RequestsFlowUIHandler(this),
                new LogsUIHandler(this)
            };
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            // custom draw the top border
            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5; // MetroFramework source code
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private async void StationsView_Load(object sender, EventArgs e)
        {
            await Task.Delay(500);
            this.initialize();
        }

        private void initialize()
        {
            this.UIHandlers.ForEach((IUIHandlerInterface handler) => handler.Handle());
        }


        protected override void OnClosing(CancelEventArgs e)
        {
            Globals.Server.Stop();
            base.OnClosing(e);
        }

        public UserDataAbstraction User { get; set; }
        public Settings Settings { get; set; }
        public ModulesManager Modules { get; set; }
        public ClientsManagerModule ClientsManagerModule { get; set; }

        public UserProfileCard SideBar { get { return this.sideBar; } }
        public LoggerView LoggerView { get { return this.loggerView; } }
        public StatusIndicator TunnelIndicator { get { return this.tunnelIndicator; } }
        public Control Content { get { return this.contentPanel; } }
        public Control ClientsManagerPanel { get { return this.clientsManagerPanel; } }
        public Control LoggerPanel { get { return this.loggerPanel; } }
    }
}
