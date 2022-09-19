using Falcon;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.factory;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.repository;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher.events;
using KTA_Visor_DSClient.kernel.helper;
using KTALogger;
using Sdk.Core.DevicesDetection;
using Sdk.Core.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USBKitcs;
using USBKitcs.Main;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService
{
    public class CameraDeviceService
    {
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;

        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;

        public event EventHandler<EventArgs> OnCameraConnectedOrDisconnected;


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
        private Dictionary<string, USBCameraDevice> camerasList;


        /// <summary>
        /// 
        /// </summary>
        private readonly KTALogger.Logger logger;

        public CameraDeviceService(FalconSdk sdk, ref DeviceWatcher deviceWatcher, KTALogger.Logger logger)
        {
            this.sdk = sdk;
            this.deviceWatcher =  deviceWatcher;
            this.camerasList = new Dictionary<string, USBCameraDevice>();
            this.logger = logger;


            this.deviceWatcher.DriveInserted += OnDeviceConnected;
            this.deviceWatcher.DriveRemoved += OnDeviceDisconnected;
            this.deviceWatcher.DeviceInsertedOrRemoved += OnDeviceInsertedOrRemoved;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="detectedInformation"></param>
        /// <param name="changeEventType"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnDeviceConnected(object sender, DriveChangedEventArgs e)
        {
            this.TryToMountDevice();

            if (!this.isValidCameraDevice(e.Drive)) return;

            USBCameraDevice camera = USBCameraDeviceFactory.create(e.Drive.ToString(), camerasList.Count);


            if (this.isCameraAlreadyAdded(camera)) return;

            this.camerasList.Add(camera.BadgeId, camera);


            this.OnCameraConnectedEvent?.Invoke(this, new CameraConnectedEvent(camera));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detectedInformation"></param>
        /// <param name="changeEventType"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnDeviceDisconnected(object sender, DriveChangedEventArgs e)
        {
            try
            {
                this.TryToMountDevice();
                USBCameraDevice disconnectedCamera = null;

                foreach (KeyValuePair<string, USBCameraDevice> kvp in this.camerasList)
                {

                    if (kvp.Value.Drive.Name == e.Drive)
                    {
                        disconnectedCamera = kvp.Value;
                    }
                }

                if (disconnectedCamera == null)
                    return;

                this.camerasList.Remove(disconnectedCamera.BadgeId);
                this.OnCameraDisconnectedEvent?.Invoke(this, new CameraDisconnectedEvent(disconnectedCamera));
            }
            catch (Exception ex)
            {
                this.logger.error(ex.Message, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeviceInsertedOrRemoved(object sender, EventArgs e)
        {
           this.TryToMountDevice();
           this.OnCameraConnectedOrDisconnected?.Invoke(sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        public void TryToMountDevice()
        {
            this.sdk.ConnectToDevice();

            if (FalconGlobals.ALLOW_FS_MOUNTING)
            {
                new Thread(() => this.sdk.Mount()).Start();
                Thread.Sleep(2500);
            }
        }

        private bool isValidCameraDevice(string cameraVolumeLabel)
        {
            if (cameraVolumeLabel.Length > 0) cameraVolumeLabel = cameraVolumeLabel[0].ToString();
            return File.Exists(cameraVolumeLabel + @":\\ID.txt");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        private bool isCameraAlreadyAdded(USBCameraDevice camera)
        {
            foreach(KeyValuePair<string, USBCameraDevice> kvp in this.camerasList)
            {
                if (kvp.Key == camera.BadgeId)
                {
                    return true;
                }
                continue;
            }
            return false;
        }
    }
}
