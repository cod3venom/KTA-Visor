using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.Camera.events
{
    public class CameraConnectedEvent : EventArgs
    {
        private readonly USBCameraDevice camera;

        public CameraConnectedEvent(USBCameraDevice camera)
        {
            this.camera = camera;
        }

        public USBCameraDevice Camera { get { return camera; } }

        public USBCameraDevice getCamera()
        {
            return camera;
        }
    }
}
