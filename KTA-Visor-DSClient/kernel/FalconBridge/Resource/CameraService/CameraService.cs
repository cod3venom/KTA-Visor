using Falcon;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.factory;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.repository;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
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
using USBKitcs;
using USBKitcs.Main;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device
{
    public class CameraService
    {
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;

        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;

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
        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;


        /// <summary>
        /// 
        /// </summary>
        private readonly CameraServiceRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private readonly Logger logger;

        public CameraService(FalconSdk sdk)
        {
            this.sdk = sdk;
            this.repository = new CameraServiceRepository();
            this.deviceWatcher = new Hardware.Hardware().deviceWatcher();
            this.camerasList = new USBCameraDeviceList<USBCameraDevice>();
            this.logger = new Logger();
        }

        /// <summary>
        /// 
        /// </summary>
        public USBCameraDeviceList<USBCameraDevice> Cameras
        {
            get { return this.camerasList; }
        }

       
        /// <summary>
        /// 
        /// </summary>
        public async void listenForConnection()
        {
            await Task.Delay(5000);
            this.sdk.ConnectToDevice();
           
            new Thread(() => this.sdk.Mount()).Start();
            await Task.Delay(5000);

            this.camerasList.loadCameras();
           
            this.deviceWatcher.OnDeviceDetected += OnDeviceConnected;
            this.deviceWatcher.OnDeviceMounted += OnDeviceConnected;
            this.deviceWatcher.OnDeviceRemoved += OnDeviceDisconnected;
            this.deviceWatcher.startWatching();
        }

        private bool isValidCameraDevice(string cameraVolumeLabel)
        {
            if (cameraVolumeLabel.Length > 0) cameraVolumeLabel = cameraVolumeLabel[0].ToString();
            return File.Exists(cameraVolumeLabel + @":\\MISC\wifi.conf");
        }

        private bool isCameraAlreadyAdded(USBCameraDevice camera)
        {
            int index = this.camerasList.FindIndex(existedCamera => existedCamera.SerialNumber == camera.SerialNumber);
            return index >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detectedInformation"></param>
        /// <param name="changeEventType"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnDeviceConnected(DeviceDetectedInformation e, VolumeChangeEventType changeEventType)
        {
            if (!this.isValidCameraDevice(e.DriveLetter)) return;

            USBCameraDevice camera = USBCameraDeviceFactory.create(e.DriveLetter.ToString(), e.SerialNumber);

            if (this.isCameraAlreadyAdded(camera)) return;

            this.camerasList.Add(camera);

            this.OnCameraConnectedEvent?.Invoke(this, new CameraConnectedEvent(camera));
            this.logger.info("Connected: " + camera);
            Thread.SpinWait(5000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detectedInformation"></param>
        /// <param name="changeEventType"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnDeviceDisconnected(DeviceDetectedInformation e, VolumeChangeEventType changeEventType)
        {

            USBCameraDevice camera = USBCameraDeviceFactory.create(e.SerialNumber.ToString());

            if (!this.isCameraAlreadyAdded(camera)) return;

            int camIndex = this.camerasList.FindIndex(existedCamera => existedCamera.SerialNumber == camera.SerialNumber);
            this.camerasList.RemoveAt(camIndex);

            this.OnCameraDisconnectedEvent?.Invoke(this, new CameraDisconnectedEvent(camera));
            this.logger.warn("Disconnected: " + camera);
            Thread.SpinWait(5000);
        }


    }
}
