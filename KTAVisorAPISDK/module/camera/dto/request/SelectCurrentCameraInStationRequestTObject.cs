using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class SelectCurrentCameraInStationRequestTObject
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camCustomId"></param>
        /// <param name="stationCustomId"></param>
        public SelectCurrentCameraInStationRequestTObject(string camCustomId, string stationCustomId)
        {
            this.camCustomId = camCustomId;
            this.stationCustomId = stationCustomId;
        }

        public string camCustomId { get; set; }
        public string stationCustomId { get; set; }
    }
}
