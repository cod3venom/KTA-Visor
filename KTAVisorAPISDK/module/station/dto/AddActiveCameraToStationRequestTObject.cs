using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.dto
{
    public class AddActiveCameraToStationRequestTObject
    {
        public AddActiveCameraToStationRequestTObject(List<string> activeCameras)
        {
            this.activeCameras = activeCameras;
        }
 
        public List<string> activeCameras { get; set; }
    }
}
