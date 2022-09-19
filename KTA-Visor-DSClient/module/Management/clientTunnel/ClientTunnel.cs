using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.clientTunnel.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.module.client;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;
using TCPTunnel.module.shared.entity;

namespace KTA_Visor_DSClient.module.Management.clientTunnel
{
    public class ClientTunnel
    {

        public event EventHandler<TCPClientMessageReceivedEvent> OnRequestReceivedInTunnelEvent;
        private Client _client;
        

        public ClientTunnel()
        {

            Settings settings = new Settings();
            AuthData authData = new AuthData();
            authData.Identificator = Globals.STATION?.data?.stationId;
            authData.AdditionalData.Add("station", Globals.STATION);

            ClientConfigTObject tunnelConnectionSettings = new ClientConfigTObject(
                settings.SettingsObj.app.management.serverIp,
                settings.SettingsObj.app.management.serverPort,
                authData
            );

            this._client = new Client(tunnelConnectionSettings, Globals.Logger);
        }

        
        public void Connect()
        {
            this._client.onClientConnected += onClientconnected;
            this._client.onClientDisconnected += onClientDisconnected;
            this._client.onReceivedMessage += onMessageReceived;

            Globals.Logger.warn("Client trying to connect to the tunnel");
            this._client.connect();
        }

        public void Disconnect()
        {
            this._client.disconnect();

            this._client.onClientConnected -= onClientconnected;
            this._client.onClientDisconnected -= onClientDisconnected;
            this._client.onReceivedMessage -= onMessageReceived;
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
            this.OnRequestReceivedInTunnelEvent?.Invoke(this, e);
        }

    }
}
