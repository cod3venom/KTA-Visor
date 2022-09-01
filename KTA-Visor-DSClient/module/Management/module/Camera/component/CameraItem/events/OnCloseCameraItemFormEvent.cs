using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem.events
{
    public class OnCloseCameraItemFormEvent : EventArgs
    {
        public OnCloseCameraItemFormEvent(CameraItem cameraItem, USBCameraDevice camera)
        {
            this.CameraItem = cameraItem;
            this.Camera = camera;
        }

        public CameraItem CameraItem { get; set; }
        public USBCameraDevice Camera { get; set; }

    }
}
