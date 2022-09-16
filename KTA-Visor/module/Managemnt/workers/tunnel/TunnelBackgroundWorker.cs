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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tunnel"></param>
        public TunnelBackgroundWorker(Tunnel tunnel)
        {
            this.tunnel = tunnel;
            this.controller = new TunnelController();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            this.tunnel.onServerStarted += onServerStart;
            this.tunnel.onServerStopped += onServerStopped;
            this.tunnel.onClientConnected += onClientConnected;
            this.tunnel.onClientDisconnected += onClientDisconnected;
            this.tunnel.onMessageReceived += onMessageReceived;

            this.tunnel.start();
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onServerStart(object sender, EventArgs e)
        {
            Globals.IS_SERVER_ONLINE = true;
            this.OnServerStarted?.Invoke(sender, new OnServerStartedEvent());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onServerStopped(object sender, EventArgs e)
        {
            Globals.IS_SERVER_ONLINE = false;
            this.OnServerStopped?.Invoke(sender, new OnServerStoppedEvent());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClientConnected(object sender,  TCPServerClientConnectedEvent e)
        {
            if (!AddClientToTheGlobalMemoryCommand.Execute(e.Client))
                return;

            this.OnClientConnected.Invoke(this, new OnClientConnected(e.Client));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClientDisconnected(object sender, TCPServerClientDisonnectedEvent e)
        {
            if (!RemoveClientToTheGlobalMemoryCommand.Execute(e.Client))
                return;

            this.OnClientDisconnected.Invoke(this,new events.OnClientDisconnected(e.Client));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onMessageReceived(object sender, TCPServerClientMessageReceivedEvent e)
        {
            this.controller.Watch(e.Request);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="request"></param>
        public void sendRequest(string ip, Request request)
        {
            TCPClientTObject client =  Globals.CLIENTS_LIST.ToList().Find((TCPClientTObject stationClient) => stationClient.IpAddress == ip);
            if (client == null)
                return;

            Console.WriteLine(String.Format("Manager: Sending message to the {0} on endpoint {1}", client.getSocket().RemoteEndPoint, request.Endpoint));

            client.Send(request);
        }

        public void sendRequestToAll(Request request)
        {
            Globals.CLIENTS_LIST.ToList().ForEach((TCPClientTObject client) =>
            {
                client.Send(request);
            });
        }
    }
}
