using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events
{
    public class OnCloseCameraItemFormEvent : EventArgs
    {
        public OnCloseCameraItemFormEvent(CameraItem cameraItem, CameraEntity.Camera camera)
        {
            this.CameraItem = cameraItem;
            this.Camera = camera;
        }

        public CameraItem CameraItem { get; set; }
        public CameraEntity.Camera Camera { get; set; }

    }
}
