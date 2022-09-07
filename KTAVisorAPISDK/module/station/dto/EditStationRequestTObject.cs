using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.dto
{
    public class EditStationRequestTObject
    {
        public EditStationRequestTObject(string stationId, string stationIp, bool active = true)
        {
            this.stationId = stationId;
            this.stationIp = stationIp;
            this.active = active;
        }

        public string stationId { get; set; }
        public string stationIp { get; set; }
        public bool active { get; set; }
    }
}
