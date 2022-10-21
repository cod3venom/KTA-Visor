using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Managemnt.module.cardReader;
using KTA_Visor.module.Managemnt.sub_window;
using KTA_Visor.module.Shared.Global;
using System;


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
            this.managementForm.aboutUsMenuItem.Click += onAboutUsMenuItemClick;
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
            if (!this.managementForm.CardReaderModule.IsHandleCreated || this.managementForm.CardReaderModule.IsDisposed)
            {
                this.managementForm.CardReaderModule = new CardReaderModule();
            }
            this.managementForm.CardReaderModule.ShowDialog();
        }

        private void onVersionMenuItemClick(object sender, EventArgs e)
        {
            new VersionWindow().ShowDialog();
        }

        private void onAboutUsMenuItemClick(object sender, EventArgs e)
        {
            new AboutUsWindow().ShowDialog();
        }
    }
}
