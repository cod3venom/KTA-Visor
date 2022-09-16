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
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CamerasService
    {

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<EventArgs> OnCameraConnectedOrDisconnected;

        
        /// <summary>
        /// 
        /// </summary>
        private readonly KTALogger.Logger logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly CameraService cameraService;
       
        public CamerasService(DeviceWatcher deviceWatcher, KTALogger.Logger logger)
        {
            this.logger = logger;
            this.DeviceWatcher = deviceWatcher;
            this.FalconBridge= new FalconBridge(deviceWatcher, logger);
            this.cameraService = new CameraService();
        }

        public DeviceWatcher DeviceWatcher { get; set; }

        public FalconBridge FalconBridge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            this.FalconBridge.CameraDeviceService.OnCameraConnectedEvent += onCameraConnectedEvt;
            this.FalconBridge.CameraDeviceService.OnCameraDisconnectedEvent += onCameraDisconnectedEvent;
            this.FalconBridge.CameraDeviceService.OnCameraConnectedOrDisconnected += onCameraConnectedOrDisconnected;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onCameraConnectedEvt(object sender, CameraConnectedEvent e)
        {
            if (!AddCamerasToTheGlobalMemory.Execute(e.Camera))
                return;

            await  this.cameraService.create(new CreateCameraRequestTObject(e.Camera.Index, e.Camera.ID, Globals.STATION.data.stationId, e.Camera.BadgeId));
            this.OnCameraConnectedEvent?.Invoke(sender, new CameraConnectedEvent(e.Camera));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            await Task.Run(this.FalconBridge.CameraDeviceService.TryToMountDevice);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="driveName"></param>
        /// <returns></returns>
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
