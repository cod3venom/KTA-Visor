using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.events
{
    public abstract class OnStationAbstraction: EventArgs
    {
        public OnStationAbstraction(StationEntity station, string action)
        {
            this.Station = station;
            this.Action = action;
        }

        public string Action { get; set; }
        public StationEntity Station
        {
            get; set;
        }
    }
}
