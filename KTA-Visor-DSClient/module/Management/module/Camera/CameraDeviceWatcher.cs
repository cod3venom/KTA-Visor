using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.camera.dto.request;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.Camera.events;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.factory;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using KTA_Visor_DSClient.module.Management.module.Camera.command.memory;
using KTA_Visor_DSClient.module.Management.module.Camera.command.filesystem;
using static Falcon_Protocol.interop.FalconProtocolInteropService;
using Falcon_Protocol;
using Sdk.Core.DevicesDetection;
using Sdk.Core.Enums;
using KTA_Visor_DSClient.module.Management.module.Camera.handler;
using KTA_Visor_DSClient.install.settings;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService
{
    public class CameraDeviceWatcher : FalconProtocol
    {
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;
        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;

        private readonly Settings settings;
        private readonly FalconProtocol falconProtocol;
        private readonly CameraService cameraService;
        private readonly CamerasGlobalMemoryHandler camerasGlobalMemoryHandler;
        private readonly CameraFilesTransferingHandler cameraFilesTransferHandler;

        public CameraDeviceWatcher(Settings settings)
        {
            this.settings = settings;
            this.falconProtocol = new FalconProtocol();
            this.cameraService = new CameraService();
            this.camerasGlobalMemoryHandler = new CamerasGlobalMemoryHandler(this.cameraService);
            this.cameraFilesTransferHandler = new CameraFilesTransferingHandler(this.settings.SettingsObj?.app?.fileSystem?.filesPath);
        }

        
        public void Start()
        {
            this.falconProtocol.Detector.OnDeviceDetected += onDeviceConnectedOrDisconnected;
            this.falconProtocol.Detector.OnDeviceMounted += OnDeviceMounted;
            this.falconProtocol.Detector.OnDeviceRemoved += OnDeviceDisconnected;
            this.falconProtocol.Detector.Run();
            this.watch();
            this.falconProtocol.Detector.LoadConnectedDevices();
        }


        private void watch()
        {
            Thread watchThread = new Thread((ThreadStart)delegate
            {
                while(Globals.ALLOW_FS_MOUNTING)
                {
                    this.Connect();
                    this.TryToMountDevice();
                }
            });

            watchThread.IsBackground = true;
            watchThread.Start();
        }

        private void onDeviceConnectedOrDisconnected(DeviceDetectedInformation detectedInformation, VolumeChangeEventType changeEventType)
        {
            this.Connect();
            this.TryToMountDevice();
            this.falconProtocol.Detector.LoadConnectedDevices();

            Globals.Logger.print("Device action detected");
        }


        private void OnDeviceMounted(DeviceDetectedInformation e, VolumeChangeEventType changeEventType)
        {
            
            if (!this.isValidCameraDevice(e.DriveLetter)){
                return;
            }

            USBCameraDevice camera = USBCameraDeviceFactory.create(e.DriveLetter, Globals.USB_CAMERA_DEVICES_LIST.Count);

            if (this.isCameraAlreadyAdded(camera)){
                return;
            }

            this.cameraFilesTransferHandler.Transfer(camera.Files, camera.Drive.Name);
            this.camerasGlobalMemoryHandler.Add(camera, Globals.ClientTunnel);

            Globals.Logger.success(String.Format("Camera with badge id {0} was inserted successfully", camera.BadgeId));
            this.OnCameraConnectedEvent?.Invoke(this, new CameraConnectedEvent(camera));
        }


        private void OnDeviceDisconnected(DeviceDetectedInformation e, VolumeChangeEventType changeEventType)
        {
            try
            {
                USBCameraDevice camera = Globals.CAMERAS_LIST.Find((USBCameraDevice device) => device.Name == e.DriveLetter);
                if (camera == null) {
                    return;
                }

                this.camerasGlobalMemoryHandler.Remove(camera.BadgeId, Globals.ClientTunnel);
                this.OnCameraDisconnectedEvent?.Invoke(this, new CameraDisconnectedEvent(camera));

                Globals.Logger.warn(String.Format("Camera with badge id {0} was removed successfully", camera.BadgeId));
            }
            catch (Exception ex)
            {
                Globals.Logger.error(ex.Message, ex);
            }
        }

        public void TryToMountDevice()
        {
            if (Globals.ALLOW_FS_MOUNTING)
            {
                new Thread(() => this.Mount()).Start();
                Thread.Sleep(2500);
            }
        }

        private bool isValidCameraDevice(string cameraVolumeLabel)
        {
            if (cameraVolumeLabel.Length > 0) cameraVolumeLabel = cameraVolumeLabel[0].ToString();
            return File.Exists(cameraVolumeLabel + @":\\ID.txt");
        }

        private bool isCameraAlreadyAdded(USBCameraDevice camera)
        {
            return Globals.CAMERAS_LIST.Find((USBCameraDevice device) => device.Drive == camera.Drive) != null;
        }
    }
}
