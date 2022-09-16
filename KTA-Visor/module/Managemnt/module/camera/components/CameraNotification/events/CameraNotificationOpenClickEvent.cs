using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.components.CameraNotification.events
{
    public class CameraNotificationOpenClickEvent : EventArgs
    {

        public CameraNotificationOpenClickEvent(CameraEntity.Camera camera)
        {
            this.Camera = camera;
        }

        public CameraEntity.Camera Camera { get; set; }
    }
}
