using KTA_Visor_DSClient.module.Management.workers.Tunnel.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        /// <summary>
        /// 
        /// </summary>
        public void Run() => this.Start();

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            if (this.tunnel.IsConnected)
                return;

            this.tunnel.OnClientConnectedToTheTunnel += onClientConnected;
            this.tunnel.OnClientDisconnectedFromTheTunnel+= onClientDisconnected;
            this.tunnel.OnMessageReceivedInTheTunnel += onMessageReceived;
            this.tunnel.IsAutoReconnectEnabled = true;


            Thread thr = new Thread(() => this.tunnel.Connect());
            thr.IsBackground = true;
            thr.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            if (!this.tunnel.IsConnected)
                return;

            this.tunnel.OnClientConnectedToTheTunnel -= onClientConnected;
            this.tunnel.OnClientDisconnectedFromTheTunnel -= onClientDisconnected;
            this.tunnel.OnMessageReceivedInTheTunnel -= onMessageReceived;
            this.tunnel.Disconnect();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Restart()
        {
            this.Stop();
            this.Start();
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClientConnected(object sender, TCPClientConnectedEvent e)
        {
           Program.logger.success(string.Format("Successfull connected trought : {0}", e.Client.getIpAddress()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClientDisconnected(object sender, EventArgs e)
        {
            Program.logger.warn("Disconnected from the tunnel");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onMessageReceived(object sender, TCPClientMessageReceivedEvent e)
        {
            this.controller.Watch(e.getRoute());
        }
         
    }
}
