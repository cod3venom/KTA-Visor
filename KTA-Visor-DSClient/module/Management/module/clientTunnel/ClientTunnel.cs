using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Shared.Globals;
using TCPTunnel.module.client;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;
using TCPTunnel.module.shared.entity;
using System;
using System.Threading;
using KTA_Visor_DSClient.module.Shared;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.clientTunnel
{
    public class ClientTunnel
    {

        public event EventHandler<TCPClientMessageReceivedEvent> OnRequestReceivedInTunnelEvent;
        
        private readonly Settings settings;
        private readonly AuthData authData;
        private readonly GlobalController globalController;
        private  Client _client;

        public ClientTunnel()
        {
            this.settings = new Settings();
            this.authData = new AuthData();
            this.globalController = new GlobalController(this);
        }

        private void initialize()
        {
            this.authData.Identificator = Globals.STATION?.data?.stationId;
            authData.AdditionalData.Add("station", Globals.STATION);

            ClientConfigTObject tunnelConnectionSettings = new ClientConfigTObject(
                this.settings.SettingsObj.app.management.serverIp,
                this.settings.SettingsObj.app.management.serverPort,
                this.authData
            );

            this._client = new Client(tunnelConnectionSettings, Globals.Logger);
        }
        
        

        public void Connect()
        {
            if (this.authData.AdditionalData.Count == 0)
            {
                this.initialize();
            }

            this._client.onClientConnected += onClientconnected;
            this._client.onClientDisconnected += onClientDisconnected;
            this._client.onReceivedMessage += onMessageReceived;

            Globals.Logger.warn("Client trying to connect to the tunnel");
            this._client.connect();
            Globals.ClientTunnel = this;
        }

        public void Disconnect()
        {
            this._client.disconnect();

            this._client.onClientConnected -= onClientconnected;
            this._client.onClientDisconnected -= onClientDisconnected;
            this._client.onReceivedMessage -= onMessageReceived;
        }

        public void Emit(Request request)
        {
            this._client.send(request);
        }
        
        private void onClientconnected(object sender, TCPClientConnectedEvent e)
        {
            Globals.Logger.success("Client successfully connected to the tunnel");
        }

        private void onClientDisconnected(object sender, EventArgs e)
        {
            Globals.Logger.error("Client has been disconnected from the tunnel");
            Thread.Sleep(4000);
            this.Connect();
        }

        private void onMessageReceived(object sender, TCPClientMessageReceivedEvent e)
        {
            this.globalController.Watch(e.Request);
            this.OnRequestReceivedInTunnelEvent?.Invoke(this, e);
        }

    }
}
