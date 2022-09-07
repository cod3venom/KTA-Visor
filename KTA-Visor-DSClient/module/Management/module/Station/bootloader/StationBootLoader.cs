using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.bootloader
{
    public class StationBootLoader
    {
        public static async Task<StationEntity> load()
        {
            Settings settings = new Settings();
            if (settings.SettingsObj.app.station.stationId == null || settings.SettingsObj.app.station.stationId == "")
                return new StationEntity();

            StationEntity entity = await Program.StationService.findByCustomId(settings.SettingsObj.app.station.stationId);

            if (entity?.data?.id != null)
            {
                entity = await Program.StationService.edit(entity.data.id, new EditStationRequestTObject(
                     settings.SettingsObj.app.station.stationId,
                     entity.data.stationIp,
                     true
                ));
            }
            else if (entity?.data?.id == null)
            {
                entity = await Program.StationService.create(new CreateStationRequestTObject(
                 settings.SettingsObj.app.station.stationId,
                 "127.0.0.1",
                 settings.SettingsObj.app.rdp.userName,
                 settings.SettingsObj.app.rdp.password
             ));
            }

            if (entity.data?.id == null)
            {
                Program.logger.warn("Unable to create station account");
            } else 
            {
                Program.logger.success("Currently using station with id="+entity.data.id);
                Globals.STATION = entity;
            }

            return entity;
        }
    }
}
