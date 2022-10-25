using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.dto
{
    public class InitStationRequestTObject
    {
        public InitStationRequestTObject(string stationId, string stationIp, string rdpUserName, string rdpPassword)
        {
            this.stationId = stationId;
            this.stationIp = stationIp;
            this.rdpUserName = rdpUserName;
            this.rdpPassword = rdpPassword;
        }

        public string stationId { get; set; }
        public string stationIp { get; set; }
        public string rdpUserName { get; set; }
        public string rdpPassword { get; set; }
    }
}
