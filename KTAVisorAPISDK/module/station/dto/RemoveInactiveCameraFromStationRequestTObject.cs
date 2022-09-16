using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.dto
{
    public class RemoveInactiveCameraFromStationRequestTObject
    {
        public RemoveInactiveCameraFromStationRequestTObject(List<string> inactiveCameras)
        {
            this.inactiveCameras = inactiveCameras;
        }
 
        public List<string> inactiveCameras { get; set; }
    }
}
