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

        public async Task<StationEntity> Initialize(bool isActive = true)
        {
            if (!isActive)
            {
                RemoveAllCamerasFromTheGlobalMemory.Execute();
            }
            
            Globals.STATION = await this.stationService.findByCustomId(
                settings.SettingsObj.app.station.stationId
            );

            if (Globals.STATION?.data?.id != null) {
                Globals.STATION = await this.update(Globals.STATION, true);
            }
            else {
                Globals.STATION = await this.create();
            }

          

            if (Globals.STATION.data == null || Globals.STATION.data?.id == null)
            {
                this.OnUnableToRegisterStation?.Invoke(this, new OnUnableToRegisterStation());
            }
            return Globals.STATION;
        }

        private async Task<StationEntity> create()
        {
            StationEntity entity = await this.stationService.create(new CreateStationRequestTObject(
                 settings.SettingsObj.app.station.stationId,
                 settings.SettingsObj.app.station.ipAddress,
                 settings.SettingsObj.app.rdp.userName,
                 settings.SettingsObj.app.rdp.password
             ));

            if (entity.data != null){
                this.OnStationCreated?.Invoke(this, new OnStationCreatedEvent(entity));
            }
            return entity;
        }

        private async Task<StationEntity> update(StationEntity entity, bool isActive = false)
        {
            entity = await this.stationService.edit(entity.data.id, new EditStationRequestTObject(
                    settings.SettingsObj.app.station.stationId,
                    settings.SettingsObj.app.station.ipAddress,
                    isActive
           ));

            if (entity.data != null && entity.data?.id != null)
            {
                this.OnStationUpdated?.Invoke(this, new OnStationUpdatedEvent(entity));
            }
            return entity;
        }
    }
}
