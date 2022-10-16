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
using TCPTunnel.kernel.types;

namespace KTA_Visor_DSClient.module.Management.module.clientTunnel
{
    public class ClientTunnel
    {

        public event EventHandler<TCPClientMessageReceivedEvent> OnRequestReceivedInTunnelEvent;
        
        private readonly Settings settings;
        private readonly AuthData authData;
        private readonly GlobalController globalController;

        private ClientConfigTObject connectionConfig;
        private Client _client;

        public ClientTunnel(Settings settings)
        {
            this.settings = settings;
            this.authData = new AuthData();
            this.globalController = new GlobalController(this);
        }

        private void initialize()
        {
            this.authData.Identificator = Globals.STATION?.data?.stationId;
            authData.AdditionalData.Add("station", Globals.STATION);

            this.connectionConfig = new ClientConfigTObject(
                this.settings.SettingsObj.app.management.serverIp,
                this.settings.SettingsObj.app.management.serverPort,
                this.authData
            );

            this._client = new Client(this.connectionConfig, Globals.Logger);
        }
      
        public void Connect()
        {
            if (this.authData.AdditionalData.Count == 0)
            {
                this.initialize();
            }

            this._client.OnDataReceived += onDataReceived;
            this._client.OnConnectionWasTerminated += onConnectionWasTerminated;
            this._client.OnExceptionOccured += onExceptionOccured;
            this._client.Connect();
        }

       

        private void onAllowedtoReconnect(object sender, EventArgs e)
        {
            this.Connect();
        }

        public void Emit(Request request)
        {
            this._client.Send(request);
        }
 
        private void onConnectionWasTerminated(object sender, EventArgs e)
        {
            Globals.Logger.warn("Reconnecting when : ConnectionWasTerminnated");
            this._client.Reconnect();
        }

        private void onExceptionOccured(object sender, OnClientExceptionHappend e)
        {
            Globals.Logger.warn("Reconnecting when : ExceptionOccured");
            this._client.Reconnect();
        }

        private void onDataReceived(object sender, TCPClientMessageReceivedEvent e)
        {
            this.globalController.Watch(e.Request);
            this.OnRequestReceivedInTunnelEvent?.Invoke(this, e);
        }

    }
}
