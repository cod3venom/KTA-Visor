using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.module.Station.controller;
using KTA_Visor_DSClient.module.Management.module.Station.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;

namespace KTA_Visor_DSClient.module.Management.module.Station
{
    public class StationInitializer
    {
        public event EventHandler<OnStationAbstraction> OnStationCreated;
        public event EventHandler<OnStationAbstraction> OnStationUpdated;
        public event EventHandler<OnUnableToRegisterStation> OnUnableToRegisterStation;

        private readonly Settings settings;
        private readonly StationService stationService;
        private readonly StationController _stationController;
        public StationInitializer(Settings settings = null)
        {
            if (settings == null){
                settings = new Settings();
            }

            this.settings = settings;
            this.stationService = new StationService();
            this._stationController = new StationController();
        }

        public async void init(bool active = true)
        {
            StationEntity stationEntity = await this.stationService.init(new InitStationRequestTObject(
               settings.SettingsObj.app.station.stationId,
               settings.SettingsObj.app.station.ipAddress,
               settings.SettingsObj.app.rdp.userName,
               settings.SettingsObj.app.rdp.password,
               active
            ));

            Globals.STATION = stationEntity;
            Globals.ClientTunnel.OnRequestReceivedInTunnelEvent += onRequest;
        }

        private void onRequest(object sender, TCPTunnel.module.client.events.TCPClientMessageReceivedEvent e)
        {
            this._stationController.Watch(e.Request);
        }
    }
}
