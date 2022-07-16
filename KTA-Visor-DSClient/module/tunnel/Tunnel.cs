﻿using KTALogger;
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

namespace KTA_Visor_DSClient.module.tunnel
{
    public class Tunnel
    {

        public event EventHandler<TCPClientConnectedEvent> onClientConnected;
        public event EventHandler<EventArgs> onClientDisconnected;
        public event EventHandler<TCPClientMessageReceivedEvent> onMessageReceived;

        private readonly ClientConfigTObject config;
        private readonly Client client;
        private readonly KTALogger.Logger logger;

        public Tunnel(ClientConfigTObject config)
        {
            this.config = config;
            this.logger = new KTALogger.Logger();
            this.client = new Client(config, this.logger);
        }

        public void connect()
        {
            this.client.onClientConnected += Client_onClientConnected;
            this.client.onClientDisconnected += Client_onClientDisconnected;
            this.client.onReceivedMessage += Client_onReceivedMessage;
            this.client.connect();
        }

        public void disconnect()
        {
            this.client.disconnect();
        }

        public void autoReconnect()
        {
            this.client.autoReconnect();
        }

        public void reConnect()
        {
            this.client.reConnect();
        }

        public bool isConnected()
        {
            return this.client.isConnected();
        }

        public void send(Request request)
        {
            this.client.send(request);
        }

        private void Client_onClientConnected(object sender, TCPClientConnectedEvent e)
        {
            this.onClientConnected?.Invoke(sender, e);
        }

        private void Client_onClientDisconnected(object sender, EventArgs e)
        {
            this.onClientDisconnected?.Invoke(sender, e);
        }

        private void Client_onReceivedMessage(object sender, TCPTunnel.module.client.events.TCPClientMessageReceivedEvent e)
        {
           this.onMessageReceived?.Invoke(sender, e);
            Thread.SpinWait(5000);
        }

        public KTALogger.Logger DebuggingPipe
        {
            get { return this.logger; }
        }

    }
}
