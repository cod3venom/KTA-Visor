using Falcon;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.helpers;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device.dto;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        private readonly FalconSdk sdk;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CameraConnectedEvt> OnCameraConnectedEvt;

        
        /// <summary>
        /// 
        /// </summary>
        private readonly List<CameraUSBDeviceTObject> cameras;

        /// <summary>
        /// 
        /// </summary>
        private bool allowListeningForConnection;

        public CameraService(FalconSdk sdk)
        {
            this.sdk = sdk;
            this.deviceWatcher = new Hardware.Hardware().deviceWatcher();
            this.cameras = new List<CameraUSBDeviceTObject>();
            this.allowListeningForConnection = true;

            this.hookUsbPorts();
        }


        private void hookUsbPorts()
        {
            this.deviceWatcher.startWatching();
        }



        public bool isActive(string deviceId)
        {
            foreach (CameraUSBDeviceTObject camera in this.getAllCameras())
            {
                if (!camera.getDriveInfo().Name.Equals(deviceId)) continue;
                return true;
            }
            return false;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CameraUSBDeviceTObject> getAllCameras()
        {   
            return this.cameras;
        }


        public void listenForConnection()
        {
            this.deviceWatcher.OnDeviceInsert += DeviceWatcher_OnDeviceInsert;
            this.deviceWatcher.OnDeviceRemoved += DeviceWatcher_OnDeviceRemoved;
            
            
            while (this.allowListeningForConnection)
            {
                if (!this.allowListeningForConnection) break;

                IEnumerable<DriveInfo> allDevices = ((IEnumerable<DriveInfo>)DriveInfo.GetDrives())
                    .Where<DriveInfo>((Func<DriveInfo, bool>)
                    (d => d.DriveType == DriveType.Removable && d.IsReady));

                foreach (DriveInfo device in allDevices)
                {
                    CameraUSBDeviceTObject camera = CameraHelper.convertDeviceToFalconCamera(device);
                    if (camera == null) continue;

                    this.onCameraConnected(camera);
                }
            }
        }

        private void DeviceWatcher_OnDeviceRemoved(object sender, EventArgs e)
        {
            this.cameras.Clear();
        }

        private void DeviceWatcher_OnDeviceInsert(object sender, EventArgs e)
        {
            this.sdk.Mount();
        }

        private void onCameraConnected(CameraUSBDeviceTObject camera)
        {
            if (this.cameras.Any(existedCamera => existedCamera.getDriveInfo().VolumeLabel == camera.getDriveInfo().VolumeLabel)) return;
            
            this.cameras.Add(camera);
            this.OnCameraConnectedEvt?.Invoke(this, new CameraConnectedEvt(camera));
        }
    }
}
