using Falcon;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.helpers;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.repository;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.kernel.helper;
using Sdk.Core.DevicesDetection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using USBKitcs;
using USBKitcs.Main;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device
{
    public class CameraService
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly DeviceWatcher deviceWatcher;


        /// <summary>
        /// 
        /// </summary>
        private FalconSdk sdk;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CameraConnectedEvt> OnCameraConnectedEvt;

        
        /// <summary>
        /// 
        /// </summary>
        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;

        
        /// <summary>
        /// 
        /// </summary>
        private readonly CameraServiceRepository repository;

        public CameraService(FalconSdk sdk)
        {
            this.sdk = sdk;
            this.repository = new CameraServiceRepository();
            this.deviceWatcher = new Hardware.Hardware().deviceWatcher();
            this.camerasList = new USBCameraDeviceList<USBCameraDevice>();
        }

         

        public void listenForConnection()
        {
            this.sdk.Mount();
            this.camerasList.loadCameras();
           
            this.deviceWatcher.startWatching();
            this.deviceWatcher.OnDeviceDetected += DeviceWatcher_OnDeviceDetected; 
            this.deviceWatcher.OnDeviceRemoved += DeviceWatcher_OnDeviceRemoved;
            this.deviceWatcher.OnDeviceMounted += DeviceWatcher_OnDeviceMounted;
            
            while(true)
            {
                List<UsbRegistry> all = this.repository.allVisionDevices();
            }
        }

        
        private void DeviceWatcher_OnDeviceDetected(DeviceDetectedInformation detectedInformation, Sdk.Core.Enums.VolumeChangeEventType changeEventType)
        {
            Console.WriteLine("detected: " + detectedInformation.DriveLetter);
        }

        private void DeviceWatcher_OnDeviceRemoved(DeviceDetectedInformation detectedInformation, Sdk.Core.Enums.VolumeChangeEventType changeEventType)
        {
            Console.WriteLine("removed: " + detectedInformation.DriveLetter);
        }

        private void DeviceWatcher_OnDeviceMounted(DeviceDetectedInformation detectedInformation, Sdk.Core.Enums.VolumeChangeEventType changeEventType)
        {
            Console.WriteLine("mounted: " + detectedInformation.DriveLetter);
            this.loadCameras();
        }   

        private void loadCameras()
        { 
            IEnumerable<DriveInfo> allDevices = ((IEnumerable<DriveInfo>)DriveInfo.GetDrives()).Where<DriveInfo>((Func<DriveInfo, bool>)(d => d.DriveType == DriveType.Removable && d.IsReady));

            foreach (DriveInfo device in allDevices)
            {
                USBCameraDevice camera = CameraHelper.convertDeviceToFalconCamera(device);
                if (camera == null) continue;

                this.onCameraConnected(camera);
            }
        }

       

        private void onCameraConnected(USBCameraDevice camera)
        {
            if (this.camerasList.Any(existedCamera => existedCamera.getDriveInfo().VolumeLabel == camera.getDriveInfo().VolumeLabel))
                return;
            
            this.camerasList.Add(camera);
            this.OnCameraConnectedEvt?.Invoke(this, new CameraConnectedEvt(camera));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<USBCameraDevice> getAllCameras()
        {
            return this.camerasList;
        }

    }
}
