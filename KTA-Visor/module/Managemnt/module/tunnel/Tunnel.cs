﻿
using KTALogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel;
using TCPTunnel.module.server;
using TCPTunnel.module.server.dto;
using TCPTunnel.module.server.events;

namespace KTA_Visor.module.Management.tunnel
{
    public class Tunnel
    {
        public event EventHandler<EventArgs> onServerStarted;
        public event EventHandler<EventArgs> onServerStopped;
        public event EventHandler<TCPServerClientConnectedEvent> onClientConnected;
        public event EventHandler<TCPServerClientDisonnectedEvent> onClientDisconnected;
        public event EventHandler<TCPServerClientMessageReceivedEvent> onMessageReceived;

        private readonly ServerConfigTObject config;
        private readonly Server server;
        private readonly KTALogger.Logger logger;
         
        public Tunnel()
        {
            this.logger = new KTALogger.Logger();
            this.config = new ServerConfigTObject("Server 1", "127.0.0.1", 1337);
            this.server = new TCPTunnel.TCPTunnel().createServer(config);
        }


        public void start()
        {
            try
            {
                this.server.onServerStarted += TcpServer_onServerStarted; ;
                this.server.onServerStopped += TcpServer_onServerStopped;
                this.server.onClientConnected += TcpServer_onClientConnected;
                this.server.onClientDisconnected += TcpServer_onClientDisconnected;
                this.server.onMessageReceived += Server_onMessageReceived;

                this.server.startServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TcpServer_onServerStarted(object sender, TCPServerStartedEvent e)
        {
            this.logger.info(String.Format("Started Server on {0}:{1}", e.Config.ipAddress, e.Config.port.ToString()));
        }

        private void TcpServer_onServerStopped(object sender, EventArgs e)
        {
           this.onServerStopped?.Invoke(this, e);
        }

        public void stop()
        {
            this.server?.stopServer();
        }

        private void TcpServer_onServerStarted(object sender, EventArgs e)
        {
            this.logger.info("Server: UP");
            this.onServerStarted?.Invoke(sender, e);
        }

        private void TcpServer_onClientConnected(object sender, TCPServerClientConnectedEvent e)
        {
            this.logger.success("Connected: " + e.getClient().getIpAddress());
            this.onClientConnected?.Invoke(sender, e);
        }
        private void TcpServer_onClientDisconnected(object sender, TCPServerClientDisonnectedEvent e)
        {
            this.logger.warn("Disconnected: " + e.getClient().getIpAddress());
            this.onClientDisconnected?.Invoke(sender, e);
        }

        private void Server_onMessageReceived(object sender, TCPServerClientMessageReceivedEvent e)
        {
            this.logger.success("Received: Request " + e.getRoute().Endpoint);
            this.logger.success("Received: Message " + e.getRoute().Body);
            
            this.onMessageReceived?.Invoke(sender, e);
        }

        public KTALogger.Logger DebuggingPipe
        {
            get { return this.logger; }
        }

    }
}