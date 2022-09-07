using TCPTunnel.module.server.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTA_Visor.module.Managemnt.command;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.workers.tunnel.controller;
using KTA_Visor.module.Management.tunnel;
using TCPTunnel.module.client.events;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.workers.tunnel
{
    public class TunnelBackgroundWorker
    {
        public event EventHandler<OnClientConnected> OnClientConnected;
        public event EventHandler<OnClientDisconnected> OnClientDisconnected;
        public event EventHandler<OnServerStartedEvent> OnServerStarted;
        public event EventHandler<OnServerStoppedEvent> OnServerStopped;

        private readonly TunnelController controller;
        private readonly Tunnel tunnel;
        public TunnelBackgroundWorker(Tunnel tunnel)
        {
            this.tunnel = tunnel;
            this.controller = new TunnelController();
        }

        public void Run()
        {
            this.tunnel.onServerStarted += onServerStart;
            this.tunnel.onServerStopped += onServerStopped;
            this.tunnel.onClientConnected += onClientConnected;
            this.tunnel.onClientDisconnected += onClientDisconnected;
            this.tunnel.onMessageReceived += onMessageReceived;

            this.controller.OnEndpointReceived += onReceivedRequest;
            this.tunnel.start();
        }

       
        private void onServerStart(object sender, EventArgs e)
        {
            Globals.IS_SERVER_ONLINE = true;
            this.OnServerStarted?.Invoke(sender, new OnServerStartedEvent());
        }

        private void onServerStopped(object sender, EventArgs e)
        {
            Globals.IS_SERVER_ONLINE = false;
            this.OnServerStopped?.Invoke(sender, new OnServerStoppedEvent());
        }

        private void onClientConnected(object sender,  TCPServerClientConnectedEvent e)
        {
            if (!AddClientToTheGlobalMemoryCommand.Execute(e.Client))
                return;

            this.OnClientConnected.Invoke(this, new OnClientConnected(e.Client));
        }

        private void onClientDisconnected(object sender, TCPServerClientDisonnectedEvent e)
        {
            if (!RemoveClientToTheGlobalMemoryCommand.Execute(e.Client))
                return;

            this.OnClientDisconnected.Invoke(this,new events.OnClientDisconnected(e.Client));
        }

        private void onMessageReceived(object sender, TCPServerClientMessageReceivedEvent e)
        {
            this.controller.Watch(e.Request);
        }

        private void onReceivedRequest(object sender, TCPEndpointReceivedEvent e)
        {
            switch (e.Request.Endpoint)
            {
                case "response://identify-your-self": this.inditifyYourSelf(e.Request); break;
                case "response://show-active-devices": this.inditifyYourSelf(e.Request); break;
            }
        }
        
        public void sendRequest(Request request, string ip)
        {
            TCPClientTObject client =  Globals.CLIENTS_LIST.ToList().Find((TCPClientTObject stationClient) => stationClient.IpAddress == ip);
            if (client == null)
                return;

            client.Send(request);
        }

        private void inditifyYourSelf(Request request)
        {
            Console.WriteLine("Manager: GOT Detected identified client");
        }

        private void showActiveDevices(Request request)
        {
            Console.WriteLine("Manager: GOT active devices");
        }
    }
}
