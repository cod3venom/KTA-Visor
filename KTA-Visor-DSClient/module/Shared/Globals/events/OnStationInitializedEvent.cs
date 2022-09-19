using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Shared.Globals.events
{
    public class OnStationInitializedEvent : EventArgs
    {
        public OnStationInitializedEvent(StationEntity station)
        {
            this.Station = station;
        }

        public StationEntity Station { get; set; }  
    }
}
