﻿using KTAVisorAPISDK.module.camera.entity;
using System;


namespace KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events
{
    public class OnOpenCameraItemEvent: EventArgs
    {
        public OnOpenCameraItemEvent(CameraItem cameraItem, CameraEntity.Camera camera)
        {
            this.CameraItem = cameraItem;
            this.Camera = camera;
        }

        public CameraItem CameraItem { get; set; }
        public CameraEntity.Camera Camera { get; set; }

    }
}
