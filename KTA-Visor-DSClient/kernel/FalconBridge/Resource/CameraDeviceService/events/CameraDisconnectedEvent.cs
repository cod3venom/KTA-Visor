using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events
{
    public class CameraDisconnectedEvent : EventArgs
    {
        private readonly USBCameraDevice camera;

        public CameraDisconnectedEvent(USBCameraDevice camera)
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
