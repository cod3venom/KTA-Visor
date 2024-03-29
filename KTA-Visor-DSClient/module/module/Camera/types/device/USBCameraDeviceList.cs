﻿using KTA_Visor_DSClient.module.Management.module.Camera.types.device.events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device
{
    public class USBCameraDeviceList : List<USBCameraDevice>
    {
        public event EventHandler<CameraAddedInListEvent> OnCameraAddedInList;
        public event EventHandler<CameraRemovedFromListEvent> OnCameraRemovedFromList;
        private int _index;

        public USBCameraDeviceList(): base()
        {
            this._index = -1;
        }

        public void Push(USBCameraDevice camera)
        {
            USBCameraDevice existedCamera = this.GetByDrive(camera.Drive.Name);
            if (existedCamera != null){
                return;
            }
            this._index++;
            camera.Index = this._index; 

            this.Add(camera);
            this.OnCameraAddedInList?.Invoke(this, new CameraAddedInListEvent(camera));
        }
        
        public void Delete(USBCameraDevice camera)
        {
            this.Remove(camera);
            this.OnCameraRemovedFromList?.Invoke(this, new CameraRemovedFromListEvent(camera));

        }

        public USBCameraDevice GetByDrive(string driveName)
        {
            return this.Find((USBCameraDevice device) => device.Name == driveName);
        }

        public USBCameraDevice GetByBadge(string badgeId)
        {
            return this.Find((USBCameraDevice device) => device.BadgeId == badgeId);
        }

    }
}
