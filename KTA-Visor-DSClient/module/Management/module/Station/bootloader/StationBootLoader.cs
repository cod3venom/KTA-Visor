using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.module.Station.dto.request;
using KTA_Visor_DSClient.module.Management.module.Station.entity;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.bootloader
{
    public class StationBootLoader
    {
        public async void load()
        {
            Settings settings = new Settings();
            StationEntity entity = await Program.StationService.create(new CreateStationRequestTObject(
                 settings.SettingsObj.app.backend.stationCustomId,
                 "127.0.0.1"
             ));

            if (entity.data?.id == null)
            {
                Program.logger.warn("Unable to create station account");
            } else 
            {
                Program.logger.success("Currently using station with id="+entity.data.id);
                Globals.STATION = entity;
            }
            
        }
    }
}
