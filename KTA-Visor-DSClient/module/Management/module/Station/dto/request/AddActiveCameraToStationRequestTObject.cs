using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.dto.request
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
