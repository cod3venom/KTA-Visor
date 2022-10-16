using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Managemnt.module.cardReader.form;
using KTA_Visor.module.Managemnt.module.fileManager;
using KTA_Visor.module.Managemnt.module.logs;
using KTA_Visor.module.Managemnt.module.station;
using KTA_Visor.module.Managemnt.sub_window;
using KTA_Visor.module.Managemnt.view;
using KTA_Visor.module.Shared.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.uiHandler
{
    public class TopBarMenuUIHandler : IUIHandlerInterface
    {
        private readonly Management.view.Management managementForm;
        public TopBarMenuUIHandler(Management.view.Management managementForm)
        {
            this.managementForm = managementForm;
        }

        public void Handle()
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            Globals.Server.OnServerStarted += onServerStarted;
            Globals.Server.OnServerStopped += onServerStopped;

            this.managementForm.startTunnelServerMenuItem.Click += onStartTunnelServerMenuItemClick;
            this.managementForm.stopTunnelServerMenuItem.Click += onStopTunnelServerMenuItemClick;
            this.managementForm.restartTunnelServerMenuItem.Click += onRestartTunnelServerMenuItemClick;
            this.managementForm.cardModeMenuItem.Click += onCardModeClick;
            this.managementForm.versionMenuItem.Click += onVersionMenuItemClick;
        }
 
        private void onServerStarted(object sender, OnServerStartedEvent e)
        {
            this.managementForm.TunnelIndicator.running(true, "Uruchomiony");
        }

        private void onServerStopped(object sender, OnServerStoppedEvent e)
        {
            this.managementForm.TunnelIndicator.running(false, "Wstrzymany");
        }

        private void onStartTunnelServerMenuItemClick(object sender, EventArgs e)
        {
            Globals.Server.Start();
        }

        private void onStopTunnelServerMenuItemClick(object sender, EventArgs e)
        {
            Globals.Server.Stop();
        }

        private void onRestartTunnelServerMenuItemClick(object sender, EventArgs e)
        {
            Globals.Server.Restart();
        }


        private void onCardModeClick(object sender, EventArgs e)
        {
            new CardModeWindow().ShowDialog();
        }

        private void onVersionMenuItemClick(object sender, EventArgs e)
        {
            new VersionWindow().ShowDialog();
        }
    }
}
