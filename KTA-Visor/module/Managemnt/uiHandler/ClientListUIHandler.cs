using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
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
    public class ClientListUIHandler : IUIHandlerInterface
    {
        private readonly Management.view.Management managementForm;
        public ClientListUIHandler(Management.view.Management managementForm)
        {
            this.managementForm = managementForm;
        }

        public void Handle()
        {
            this.initializeUI();
            this.hookEvents();
        }

        private void initializeUI()
        {
            this.managementForm.ClientsManagerModule.Title = "Połączenia";
            this.managementForm.ClientsManagerModule.TotalConnectionsText = "Wszystkie połączenia: ";
            this.managementForm.ClientsManagerModule.Dock = DockStyle.Fill;
            this.managementForm.ClientsManagerPanel.Controls.Add(this.managementForm.ClientsManagerModule);
        }
        private void hookEvents()
        {
            Globals.Server.OnClientConnected += onClientConnected;
            Globals.Server.OnClientDisconnected += onClientDisconnected;
        }

        private void onClientConnected(object sender, OnClientConnected e)
        {
            this.managementForm.ClientsManagerModule.Add(e.Client.Socket);
        }

        private void onClientDisconnected(object sender, OnClientDisconnected e)
        {
            this.managementForm.ClientsManagerModule.Remove(e.Client.Socket);
        }
    }
}
