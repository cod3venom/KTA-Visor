using Falcon_Protocol;
using KTA_Visor_DSClient.module.Management.module.Camera.types.device.events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device
{
    public class USBCameraDeviceList : List<USBCameraDevice>
    {
        public event EventHandler<CameraAddedToTheMemoryEvent> OnCameraAddedInMemory;
        public event EventHandler<CameraRemovedFromTheMemoryEvent> OnCameraRemovedFromMemory;


        private readonly FalconProtocol _falconProtocol;
        
        public USBCameraDeviceList(): base()
        {
            this._falconProtocol = new FalconProtocol();
        }

        public void Push(USBCameraDevice camera)
        {
            USBCameraDevice existedCamera = this.GetByDrive(camera.Drive.Name);
            if (existedCamera != null){
                this.Remove(existedCamera);
            }

            camera.Active = true;

            this.Add(camera);

            Thread addingThread = new Thread(() => this.OnCameraAddedInMemory?.Invoke(this, new CameraAddedToTheMemoryEvent(camera)));
            addingThread.IsBackground = true;
            addingThread.Start();
        }
        
        public void Delete(USBCameraDevice camera)
        {
            this.Remove(camera);
            camera.Active = false;

            Thread removingThread = new Thread(() => this.OnCameraRemovedFromMemory?.Invoke(this, new CameraRemovedFromTheMemoryEvent(camera)));
            removingThread.IsBackground = true;
            removingThread.Start();   
        }

        public USBCameraDevice GetByID (string id)
        {
            return this.Find((USBCameraDevice device) => device?.ID == id);
        }

        public USBCameraDevice GetByCardID(string cardId)
        {
            return this.Find((USBCameraDevice device) => device?.Name == cardId);
        }

        public USBCameraDevice GetByDrive(string driveName)
        {
            return this.Find((USBCameraDevice device) => device?.Name == driveName);
        }

        public USBCameraDevice GetByBadge(string badgeId)
        {
            return this.Find((USBCameraDevice device) => device?.BadgeId == badgeId);
        }

    }
}
