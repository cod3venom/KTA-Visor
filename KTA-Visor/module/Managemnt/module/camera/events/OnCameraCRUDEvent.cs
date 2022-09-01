using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.events
{
    public class OnCameraCRUDEvent:EventArgs
    {
        public OnCameraCRUDEvent(string cameraCustomId)
        {
            this.CameraCustomId = cameraCustomId;
        }

        public string CameraCustomId { get; set; }
    }
}
