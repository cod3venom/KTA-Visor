using TCPTunnel.module.server.events;
using System;
using System.Linq;
using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Shared.Global;
using KTA_Visor.module.Managemnt.workers.tunnel.controller;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using TCPTunnel.module.server;
using TCPTunnel.module.server.dto;
using System.Windows.Forms;
using System.Threading;

namespace KTA_Visor.module.Managemnt.server
{
    public class ServerTunnel
    {
        public event EventHandler<OnClientConnected> OnClientConnected;
        public event EventHandler<OnClientDisconnected> OnClientDisconnected;
        public event EventHandler<OnServerStartedEvent> OnServerStarted;
        public event EventHandler<OnServerStoppedEvent> OnServerStopped;
        public event EventHandler<OnMessageReceivedFromClient> OnMessageReceivedFromClient;

        private readonly ServerTunnelController controller;
        private readonly Server _server;

        public ServerTunnel(ServerConfigTObject config, KTALogger.Logger logger)
        {
            this._server = new Server(config, logger);
            this.controller = new ServerTunnelController();
        }

        public TCPClientList Clients
        {
            get { return this._server.Clients; }
        }

        public void Start()
        {
            this._server.onServerStarted += onServerStart;
            this._server.onServerStopped += onServerStopped;
            this._server.onClientConnected += onClientConnected;
            this._server.onClientDisconnected += onClientDisconnected;
            this._server.onMessageReceived += onMessageReceived;

            this._server.StartServer();
        }

        public void Stop()
        {
            this._server.StopServer();
        }

        public void Restart()
        {
            this.Stop();
            this.Start();
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

        private void onClientConnected(object sender, TCPServerClientConnectedEvent e)
        {
            Globals.Logger.info(String.Format("New client has been connected: {0}", e.Client.IpAddress));
            this.OnClientConnected.Invoke(this, new OnClientConnected(e.Client));
        }


        private void onClientDisconnected(object sender, TCPServerClientDisonnectedEvent e)
        {
            Globals.Logger.warn(String.Format("Existed client has been disconnected: {0}", e.Client.IpAddress));
            this.OnClientDisconnected.Invoke(this, new events.OnClientDisconnected(e.Client));
        }

        private void onMessageReceived(object sender, TCPServerClientMessageReceivedEvent e)
        {
            this.controller.Watch(e.Request);

            Globals.Logger.info(String.Format("Received request: {0}", e.Request.toJson()));
            this.OnMessageReceivedFromClient?.Invoke(sender, new OnMessageReceivedFromClient(e.Request));
        }


        public void sendRequest(string ip, Request request)
        {
            TCPClientTObject client = Globals.Server.Clients.Find((TCPClientTObject stationClient) => stationClient.IpAddress == ip);
            if (client == null)
            {
                MessageBox.Show("Nie udało się znaleść stacje o takim adresie IP");
                return;
            }


            new Thread(() => client.Send(request)).Start();
            Globals.Logger.info(String.Format("Sent request request to {0} with params \n{1}", request.Endpoint, request.toJson()));

        }

        public void sendRequestToAll(Request request)
        {
            Globals.Server.Clients.ForEach((TCPClientTObject client) => client.Send(request));
        }
    }
}
