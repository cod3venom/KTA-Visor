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
using KTAVisorAPISDK.module.camera.entity;
using Falcon_Protocol.modules.detector.events;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService
{
    public class CameraDeviceWatcher : FalconProtocol
    {
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;
        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;

        private readonly Settings settings;
        private readonly KTALogger.Logger _logger;
        private readonly FalconProtocol falconProtocol;
        private readonly CameraService cameraService;
        private readonly CamerasGlobalMemoryHandler camerasGlobalMemoryHandler;
        private readonly CameraFilesTransferingHandler cameraFilesTransferHandler;

        public CameraDeviceWatcher(Settings settings, KTALogger.Logger logger)
        {
            this.settings = settings;
            this._logger = logger;
            this.falconProtocol = new FalconProtocol();
            this.cameraService = new CameraService();
            this.camerasGlobalMemoryHandler = new CamerasGlobalMemoryHandler(this.cameraService);
            this.cameraFilesTransferHandler = new CameraFilesTransferingHandler(this.settings.SettingsObj?.app?.fileSystem?.filesPath);
        }

        
        public void Start()
        {
            this.watch();
            this.falconProtocol.Detector.OnExceptionOccured += onExceptionOccured;
            this.falconProtocol.Detector.OnDeviceMounted += OnDeviceMounted;
            this.falconProtocol.Detector.OnDeviceRemoved += OnDeviceDisconnected;
            this.falconProtocol.Detector.LoadConnectedDevices();
            this.falconProtocol.Detector.Run();
        }

       
        private void watch()
        {
            Thread watchThread = new Thread((ThreadStart)delegate
            {
                while(true)
                {
                    if (!Globals.ALLOW_FS_MOUNTING){
                        continue;
                    }

                    this.Connect();
                    this.TryToMountDevice();
                }
            });

            watchThread.IsBackground = true;
            watchThread.Start();
        }


        private async void OnDeviceMounted(object sender, OnDeviceMountedEvent e)
        {
            
            if (!this.isValidCameraDevice(e.Drive.Name)){
                return;
            }

            USBCameraDevice camera = USBCameraDeviceFactory.create(e.Drive.Name, Globals.CAMERAS_LIST.Count);

            if (this.isCameraAlreadyAdded(camera)){
                return;
            }

            CameraEntity cameraEntity = await this.camerasGlobalMemoryHandler.Add(camera, Globals.ClientTunnel);

            this.cameraFilesTransferHandler.AssignValues(camera, cameraEntity);
            this.cameraFilesTransferHandler.Transfer();

            this._logger.success(String.Format("Camera with badge id {0} was inserted successfully", camera.BadgeId));
            this.OnCameraConnectedEvent?.Invoke(this, new CameraConnectedEvent(camera));
        }


        private void OnDeviceDisconnected(object sender, OnDeviceRemoved e)
        {
            try
            {
                USBCameraDevice camera = Globals.CAMERAS_LIST.Find((USBCameraDevice device) => device.Name == e.Drive?.Name);
                if (camera == null) {
                    return;
                }

                _ = this.camerasGlobalMemoryHandler.Remove(camera.BadgeId, Globals.ClientTunnel);
                this.OnCameraDisconnectedEvent?.Invoke(this, new CameraDisconnectedEvent(camera));

                this._logger.warn(String.Format("Camera with badge id {0} was removed successfully", camera.BadgeId));
            }
            catch (Exception ex)
            {
                this._logger.error(ex.Message, ex);
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

        private void onExceptionOccured(object sender, Exception exception)
        {
            this._logger.error(exception.Message, exception.ToString());
        }

    }
}
