using KTA_Visor.install;
using KTA_Visor.install.settings;
using KTA_Visor.module.Managemnt.module.auth.view.SignInView;
using KTA_Visor.module.Managemnt.server;
using KTA_Visor.module.Managemnt.workers.tunnel;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.kernel.module.HttpClientHelper;
using KTAVisorAPISDK.kernel.sharedKernel.util;
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
using TCPTunnel.module.server.dto;

namespace KTA_Visor.module.Managemnt.view
{
    public partial class KernelLoader : Form
    {
        private readonly Installer installer;
        private readonly Settings settings;

        public KernelLoader()
        {
            InitializeComponent();
            this.installer = new Installer();
            this.settings = new Settings();
        }

        private async void KernelLoader_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
            this.improvedProgressBar1.OnProgressEnd += onProgressEnd;

            await Task.Delay(1000);

            this.improvedProgressBar1.Start();
            this.installer.FullInstall();
            await this.initializeKTAVISORAPISDK();
            await this.initializeServerTunnel();
        }

        

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
        }
 

        private async void onProgressEnd(object sender, EventArgs e)
        {
            this.Hide();

            if (!this.settings.SettingsObj.app.configured)
            {
                new SettingsEntryPoint().ShowDialog();
            }
            else
            {
                new SignInView().ShowDialog();
            }
        }

 
        private async Task<HttpClientHelper> initializeKTAVISORAPISDK()
        {
            HttpClientUtil.initializeHttpClient(this.settings.SettingsObj?.app?.api?.url);
            HttpClientUtil.initializeSecuredClient(this.settings.SettingsObj?.app?.api?.url); ;
            return HttpClientUtil.httpClient;
        }

        private async Task<ServerTunnel> initializeServerTunnel()
        {
            Globals.Server = new ServerTunnel(new ServerConfigTObject(
                    "Management",
                     settings.SettingsObj?.app?.tunnel?.serverIp,
                     settings.SettingsObj.app.tunnel.serverPort
                ),
                Globals.Logger
            );

            return Globals.Server;
        }
    }
}
