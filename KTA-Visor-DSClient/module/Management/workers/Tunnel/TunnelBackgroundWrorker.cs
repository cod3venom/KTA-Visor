using KTA_Visor_DSClient.module.Management.workers.Tunnel.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;

namespace KTA_Visor_DSClient.module.Management.workers.Tunnel
{
    public class TunnelBackgroundWrorker
    {
        private readonly KTA_Visor_DSClient.module.Management.module.Tunnel.Tunnel tunnel;
        private readonly TunnelController controller;

        public TunnelBackgroundWrorker(ClientConfigTObject config, KTALogger.Logger logger)
        {
            this.tunnel = new module.Tunnel.Tunnel(config, logger);
            this.controller = new TunnelController();
        }

        public void Run() => this.Start();
        public void Start()
        {
            this.tunnel.OnClientConnected += onClientConnected;
            this.tunnel.onClientDisconnected += onClientDisconnected;
            this.tunnel.onMessageReceived += onMessageReceived;
            this.controller.OnEndpointReceived += onReceivedRequest;
            this.tunnel.AutoReconnect();
        }

        public void Stop()
        {
            this.tunnel.OnClientConnected -= onClientConnected;
            this.tunnel.onClientDisconnected -= onClientDisconnected;
            this.tunnel.onMessageReceived -= onMessageReceived;
            this.controller.OnEndpointReceived -= onReceivedRequest;
            this.tunnel.Disconnect();
        }

        public void Restart()
        {
            this.Stop();
            this.Start();
        }


        private void onClientConnected(object sender, TCPClientConnectedEvent e)
        {
           Program.logger.success(string.Format("Successfull connected trought : {0}", e.Client.getIpAddress()));
        }

        private void onClientDisconnected(object sender, EventArgs e)
        {
            Program.logger.warn("Disconnected from the tunnel");
        }

        private void onMessageReceived(object sender, TCPClientMessageReceivedEvent e)
        {
            this.controller.Watch(e.getRoute());
        }


        private void onReceivedRequest(object sender, TCPEndpointReceivedEvent e)
        {
            switch(e.Request.Endpoint)
            {
                case "command://identify-your-self":  this.inditifyYourSelf(e.Request); break;
                case "command://show-active-devices":  this.showActiveDevices(e.Request); break;
            }
        }

        private void inditifyYourSelf(Request request)
        {
            Console.WriteLine("Detected inditifyYourSelf");
        }

        private void showActiveDevices(Request request)
        {
            Console.WriteLine("Detected showActiveDevices");
        }
    }
}
