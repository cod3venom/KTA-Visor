using KTAVisorAPISDK.module.camera.entity;
using System;


namespace KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events
{
    public class ContextMenuCopyFilesToDiskClickEvent : EventArgs
    {
        public ContextMenuCopyFilesToDiskClickEvent(CameraItem cameraItem, CameraEntity.Camera camera)
        {
            this.CameraItem = cameraItem;
            this.Camera = camera;
        }

        public CameraItem CameraItem { get; set; }
        public CameraEntity.Camera Camera { get; set; }

    }
}
