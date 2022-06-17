using KTALogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.client;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;
using TCPTunnel.module.server.dto;
using TCPTunnel.module.server.events;

namespace KTA_Visor_DSClient.module.tunnel
{
    public class Tunnel
    {
        public event EventHandler<TCPClientConnectedEvent> onClientConnected;
        public event EventHandler<TCPServerClientDisonnectedEvent> onClientDisconnected;
        public event EventHandler<TCPClientMessageReceivedEvent> onMessageReceived;

        private readonly ClientConfigTObject config;
        private readonly Client client;
        private readonly Logger logger;

        public Tunnel(ClientConfigTObject config)
        {
            this.config = config;
            this.client = new Client(config);
        }

        public void connect()
        {
            this.client.connect();
            this.client.onClientConnected += Client_onClientConnected;

            this.client.onReceivedMessage += Client_onReceivedMessage;
        }

        private void Client_onClientConnected(object sender, TCPClientConnectedEvent e)
        {
            this.onClientConnected?.Invoke(sender, e);
        }

        private void Client_onReceivedMessage(object sender, TCPTunnel.module.client.events.TCPClientMessageReceivedEvent e)
        {
           this.onMessageReceived?.Invoke(sender, e);
        }
    }
}
