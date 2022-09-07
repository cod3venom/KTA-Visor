using KTALogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.client;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;
using TCPTunnel.module.server.dto;
using TCPTunnel.module.server.events;

namespace KTA_Visor_DSClient.module.Management.module.Tunnel
{
    public class Tunnel:Client
    {

        public event EventHandler<TCPClientConnectedEvent> OnClientConnected;
        public event EventHandler<EventArgs> OnClientDisconnected;
        public event EventHandler<TCPClientMessageReceivedEvent> onMessageReceived;

        private readonly ClientConfigTObject config;
     
        public Tunnel(ClientConfigTObject config, KTALogger.Logger logger): base(config, logger)
        {
            this.config = config;
             
        }

        public void Connect()
        {
            this.onClientConnected += Client_onClientConnected;
            this.onClientDisconnected += Client_onClientDisconnected;
            this.onReceivedMessage += Client_onReceivedMessage;
            this.connect();
        }

        public void Disconnect()
        {
            this.disconnect();
        }

        public new void AutoReconnect()
        {
            this.autoReconnect();
        }

        public void ReConnect()
        {
            this.reConnect();
        }

        public bool IsConnected()
        {
            return this.isConnected();
        }

        public void Send(Request request)
        {
            this.send(request);
        }

        private void Client_onClientConnected(object sender, TCPClientConnectedEvent e)
        {
            this.OnClientConnected?.Invoke(sender, e);
        }

        private void Client_onClientDisconnected(object sender, EventArgs e)
        {
            this.OnClientDisconnected?.Invoke(sender, e);
        }

        private void Client_onReceivedMessage(object sender, TCPTunnel.module.client.events.TCPClientMessageReceivedEvent e)
        {
           this.onMessageReceived?.Invoke(sender, e);
            Thread.SpinWait(5000);
        }
    }
}
