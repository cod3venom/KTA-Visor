using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.dto.request
{
    public class RemoveInactiveCameraToStationRequestTObject
    {
        public RemoveInactiveCameraToStationRequestTObject(List<string> inactiveCameras)
        {
            this.inactiveCameras = inactiveCameras;
        }
        public List<string> inactiveCameras { get; set; }
    }
}
