using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.module.Management.module.Camera.command.memory;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraDevicesWatcher
    {

        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;
        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;
        public event EventHandler<EventArgs> OnCameraConnectedOrDisconnected;

        private readonly FalconBridge falconBridge;
        private readonly KTALogger.Logger logger;
        private readonly CameraService cameraService;
        private readonly DeviceWatcher deviceWatcher;
       
        public CameraDevicesWatcher()
        {
            this.deviceWatcher = new DeviceWatcher();
            this.falconBridge= new FalconBridge(deviceWatcher, logger);
            this.cameraService = new CameraService();
        }

        

        public void Start()
        {
            this.falconBridge.CameraDeviceService.OnCameraConnectedEvent += onCameraConnectedEvt;
            this.falconBridge.CameraDeviceService.OnCameraDisconnectedEvent += onCameraDisconnectedEvent;
            this.falconBridge.CameraDeviceService.OnCameraConnectedOrDisconnected += onCameraConnectedOrDisconnected;
            this.falconBridge.DeviceWatcher.LoadConnectedDevices();
        }

        public void LoadConnectedDevices()
        {
            this.deviceWatcher.LoadConnectedDevices();
        }

        private async void onCameraConnectedEvt(object sender, CameraConnectedEvent e)
        {
            if (!AddCamerasToTheGlobalMemory.Execute(e.Camera))
                return;

            await  this.cameraService.create(new CreateCameraRequestTObject(e.Camera.Index, e.Camera.ID, Globals.STATION.data.stationId, e.Camera.BadgeId));
            this.OnCameraConnectedEvent?.Invoke(sender, new CameraConnectedEvent(e.Camera));
        }


        private void onCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            if (!RemoveCamerasFromTheGlobalMemory.Execute(e.Camera.BadgeId)) 
                return;

            this.OnCameraDisconnectedEvent?.Invoke(sender, new CameraDisconnectedEvent(e.Camera));

        }

        private void onCameraConnectedOrDisconnected(object sender, EventArgs e)
        {
           this.OnCameraConnectedOrDisconnected?.Invoke(sender, e);
        }

        public async void TryToMountDevice()
        {
            await Task.Run(this.falconBridge.CameraDeviceService.TryToMountDevice);
        }


        public Dictionary<string, FileInfo> FilesFromDrive(string driveName)
        {
            Dictionary<string, FileInfo> files = new Dictionary<string, FileInfo>();

            foreach (USBCameraDevice camera in Globals.CAMERAS_LIST)
            {
                if (camera.Drive.Name != driveName) continue;

                foreach (FileInfo file in camera.Files)
                {
                   if (!files.ContainsKey(file.Name))
                    {
                        files.Add(file.Name, file);
                    }
                }
            }
            return files;
        }
    }
}
