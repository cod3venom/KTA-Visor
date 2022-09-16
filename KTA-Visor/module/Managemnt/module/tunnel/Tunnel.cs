
using KTALogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
         
        public Tunnel(KTALogger.Logger logger)
        {
            this.logger = logger;
            this.config = new ServerConfigTObject("Server 1", "127.0.0.1", 1337);
            this.server = new TCPTunnel.TCPTunnel().createServer(config);
        }

        /// <summary>
        /// 
        /// </summary>
        public void start()
        {
            try
            {
                this.server.onServerStarted += TcpServer_onServerStarted;
                this.server.onServerStopped += TcpServer_onServerStopped;
                this.server.onClientConnected += TcpServer_onClientConnected;
                this.server.onClientDisconnected += TcpServer_onClientDisconnected;
                this.server.onMessageReceived += Server_onMessageReceived;
                this.server.onAuthCommandSent += Server_onAuthCommandSent;
                this.server.onAuthResponseDataReceived += Server_onAuthResponseDataReceived;
                this.server.onAuthIsOk += Server_onAuthIsOk;
                this.server.startServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

 


        /// <summary>
        /// 
        /// </summary>
        public void stop()
        {

            this.server.onServerStarted -= TcpServer_onServerStarted;
            this.server.onServerStopped -= TcpServer_onServerStopped;
            this.server.onClientConnected -= TcpServer_onClientConnected;
            this.server.onClientDisconnected -= TcpServer_onClientDisconnected;
            this.server.onMessageReceived -= Server_onMessageReceived;
            this.server.onAuthCommandSent -= Server_onAuthCommandSent;
            this.server.onAuthResponseDataReceived -= Server_onAuthResponseDataReceived;
            this.server.onAuthIsOk -= Server_onAuthIsOk;

            this.server?.stopServer();
        }
      
        /// <summary>
        /// 
        /// </summary>
        public void restart()
        {
            this.stop();
            Thread.Sleep(1000);
            this.start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_onServerStarted(object sender, TCPServerStartedEvent e)
        {
            this.logger.info(String.Format("Started Server on {0}:{1}", e.Config.ipAddress, e.Config.port.ToString()));
            this.onServerStarted?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_onServerStopped(object sender, EventArgs e)
        {
            this.logger.info(String.Format("Stopped Server"));
            this.onServerStopped?.Invoke(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_onClientConnected(object sender, TCPServerClientConnectedEvent e)
        {
            this.logger.success("Connected new client from: " + e.getClient().getIpAddress());
            this.onClientConnected?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_onClientDisconnected(object sender, TCPServerClientDisonnectedEvent e)
        {
            this.logger.warn("Disconnected: " + e.getClient().getIpAddress());
            this.onClientDisconnected?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_onMessageReceived(object sender, TCPServerClientMessageReceivedEvent e)
        {
            this.logger.success("Received: Request " + e.Request.Endpoint);
            this.logger.success("Received: Message " + e.Request.Body);
            
            this.onMessageReceived?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_onAuthCommandSent(object sender, TCPTunnel.module.shared.events.OnAuthCommandSent e)
        {
            this.logger.success(String.Format("AUTH required for the client {0}", e.Client.getIpAddress()));

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_onAuthResponseDataReceived(object sender, TCPTunnel.module.shared.events.OnAuthResponseDataReceived e)
        {
            this.logger.success(String.Format("AUTH request received from the client {0}", e.Client.getIpAddress()));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_onAuthIsOk(object sender, TCPTunnel.module.shared.events.OnAuthIsOK e)
        {
            this.logger.success(String.Format("Successfully authenticated client {0}", e.Client.getIpAddress()));
        }

        /// <summary>
        /// 
        /// </summary>
        public KTALogger.Logger DebuggingPipe
        {
            get { return this.logger; }
        }

    }
}
