using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events
{
    public class CameraConnectedEvent : EventArgs
    {
        private readonly USBCameraDevice camera;

        public CameraConnectedEvent(USBCameraDevice camera)
        {
            this.camera = camera;
        }

        public USBCameraDevice getCamera()
        {
            return camera;
        }
    }
}
