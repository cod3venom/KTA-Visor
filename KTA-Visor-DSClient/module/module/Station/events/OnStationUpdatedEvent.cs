using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.events
{
    public class OnStationUpdatedEvent: OnStationAbstraction
    {
        public OnStationUpdatedEvent(StationEntity station): base(station, "update")
        {
        }
         
    }
}
