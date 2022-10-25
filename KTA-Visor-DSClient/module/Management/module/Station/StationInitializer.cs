using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.module.Camera.command.memory;
using KTA_Visor_DSClient.module.Management.module.Station.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station
{
    public class StationInitializer
    {
        public event EventHandler<OnStationAbstraction> OnStationCreated;
        public event EventHandler<OnStationAbstraction> OnStationUpdated;
        public event EventHandler<OnUnableToRegisterStation> OnUnableToRegisterStation;

        private readonly Settings settings;
        private readonly StationService stationService;
        public StationInitializer(Settings settings = null)
        {
            if (settings == null){
                settings = new Settings();
            }

            this.settings = settings;
            this.stationService = new StationService();
        }

        public async void init(bool isActive = true)
        {
            StationEntity entity = await this.stationService.init(new InitStationRequestTObject(
               settings.SettingsObj.app.station.stationId,
               settings.SettingsObj.app.station.ipAddress,
               settings.SettingsObj.app.rdp.userName,
               settings.SettingsObj.app.rdp.password
            ));

            if (entity.data == null){
                Globals.Logger.error("Unable to initialize station");
                throw new Exception("Unable to initialize station");
            }

            Globals.STATION = entity;
        }
 
    }
}
