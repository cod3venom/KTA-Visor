using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class DeselectAllCamerasFromTheStationTObject
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationCustomId"></param>
        public DeselectAllCamerasFromTheStationTObject(string stationCustomId)
        {
            this.stationCustomId = stationCustomId;
        }

        public string stationCustomId { get; set; }
    }
}
