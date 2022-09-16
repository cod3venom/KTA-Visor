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
    public class Tunnel: Client
    {

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<TCPClientConnectedEvent> OnClientConnectedToTheTunnel;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnClientDisconnectedFromTheTunnel;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<TCPClientMessageReceivedEvent> OnMessageReceivedInTheTunnel;

        /// <summary>
        /// 
        /// </summary>
        private readonly ClientConfigTObject config;
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        public Tunnel(ClientConfigTObject config, KTALogger.Logger logger): base(config, logger)
        {
            this.config = config;
             
        }

        /// <summary>
        /// 
        /// </summary>
        public void Connect()
        {
            this.onClientConnected += (delegate(object sender, TCPClientConnectedEvent e)
            {
                this.OnClientConnectedToTheTunnel?.Invoke(sender, e);
            });
            this.onClientDisconnected += (delegate(object sender, EventArgs e)
            {
                this.OnClientDisconnectedFromTheTunnel?.Invoke(sender, e);
            });
            this.onReceivedMessage += (delegate(object sender, TCPClientMessageReceivedEvent e) {
                this.OnMessageReceivedInTheTunnel?.Invoke(sender, e);
            });

            this.connect();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Disconnect()
        {
            this.disconnect();
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsConnected
        {
            get { return this.isConnected(); }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public void Send(Request request)
        {
            this.send(request);
        }
    }
}
