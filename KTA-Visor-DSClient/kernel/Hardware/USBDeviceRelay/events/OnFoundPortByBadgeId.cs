using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay.events
{
    public class OnFoundPortByBadgeId: EventArgs
    {
        public OnFoundPortByBadgeId(int portNumber, USBCameraDevice camera)
        {
            this.PortNumber = portNumber;
            this.Camera = camera;
        }

        public int PortNumber { get; set; }
        public USBCameraDevice Camera { get; set; }
    }
}
