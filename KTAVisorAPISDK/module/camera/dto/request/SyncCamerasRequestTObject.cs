using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class SyncCamerasRequestTObject
    {
        public SyncCamerasRequestTObject(string stationId, List<string> activeCameras)
        {
            this.stationId = stationId;
            this.activeCameras = activeCameras;
        }

        public string stationId { get; set; }
        public List<string> activeCameras { get; set; }
    }
}
