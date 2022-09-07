using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.entity
{
    public class StationEntity : DTOHelperStruct
    {

        public class Station
        {
            public string id { get; set; }
            public string stationId { get; set; }
            public string stationIp { get; set; }
            public string rdpUserName{ get; set; }
            public string rdpPassword { get; set; }
            public bool active { get; set; }
            public List<CameraEntity.Camera> activeCameras { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
        }

        public Station data { get; set; }
        public List<Station> datas { get; set; }

    }
}
