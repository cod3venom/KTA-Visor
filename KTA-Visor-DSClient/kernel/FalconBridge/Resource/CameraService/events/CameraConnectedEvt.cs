using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events
{
    public class CameraConnectedEvt : EventArgs
    {
        private readonly CameraUSBDeviceTObject camera;

        public CameraConnectedEvt(CameraUSBDeviceTObject camera)
        {
            this.camera = camera;
        }

        public CameraUSBDeviceTObject getCamera()
        {
            return camera;
        }
    }
}
