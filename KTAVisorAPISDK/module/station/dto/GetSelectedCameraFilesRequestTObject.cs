using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.dto
{

    public class GetSelectedCameraFilesRequestTObject
    { 
        public GetSelectedCameraFilesRequestTObject(string cameraId)
        {
            this.CameraId = cameraId;
        }         

        private string CameraId { get; set; }
    }
}
