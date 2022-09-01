using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.dto.request
{
    public class CreateStationRequestTObject
    {

        public CreateStationRequestTObject(string stationId, string stationIp)
        {
            this.stationId = stationId;
            this.stationIp = stationIp;
        }
        public string stationId { get; set; }
        public string stationIp { get; set; }
    }
}
