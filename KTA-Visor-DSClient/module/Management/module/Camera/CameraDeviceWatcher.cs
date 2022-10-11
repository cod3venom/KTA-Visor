using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.camera.dto.request;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.Camera.events;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.factory;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher.events;
using KTA_Visor_DSClient.module.Management.module.Camera.command.memory;
using KTA_Visor_DSClient.module.Management.module.Camera.command.filesystem;
using static Falcon_Protocol.interop.FalconProtocolInteropService;
using Falcon_Protocol;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService
{
    public class CameraDeviceWatcher : FalconProtocol
    {
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;
        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;

        private readonly CameraService cameraService;
        private DeviceWatcher deviceWatcher;
        private ZFY_INFO currentDeviceInfo;
        public CameraDeviceWatcher()
        {     
            this.cameraService = new CameraService();
        }

        
        public void Start()
        {
            this.deviceWatcher = new DeviceWatcher();
            this.deviceWatcher.OnDeviceConnected += OnDeviceConnected;
            this.deviceWatcher.OnDeviceDisconnected += OnDeviceDisconnected;
            this.deviceWatcher.OnDeviceConnectedOrDisconnected += onDeviceConnectedOrDisconnected;
            this.Connect();
            this.TryToMountDevice();
            this.deviceWatcher.LoadConnectedDevices();
        }

        private void onDeviceConnectedOrDisconnected(object sender, EventArgs e)
        {
            this.Connect();
            this.currentDeviceInfo = this.GetDeviceInfo(Globals.CAMERAS_LIST.Count);

            this.TryToMountDevice();
            Globals.Logger.print("Device action detected");
        }

        private void OnDeviceConnected(object sender, DriveChangedEventArgs e)
        {

            if (!this.isValidCameraDevice(e.Drive)) return;

            this.Connect();
            this.TryToMountDevice();

            this.currentDeviceInfo = this.GetDeviceInfo(Globals.CAMERAS_LIST.Count);
            USBCameraDevice camera = USBCameraDeviceFactory.create(e.Drive, Globals.USB_CAMERA_DEVICES_LIST.Count);


            if (this.isCameraAlreadyAdded(camera)) return;

            AddCamerasToTheGlobalMemory.Execute(camera, Globals.ClientTunnel);
            CopyCameraFilesToNetworkStorageCommand.Execute(
                Globals.STATION?.data?.stationId,
                camera.ID,
                camera.BadgeId,
                camera.getFilesAsDict(),
                Globals.settings.SettingsObj?.app?.fileSystem?.filesPath
            );

            Globals.Logger.success(String.Format("Camera with badge id {0} was inserted successfully", camera.BadgeId));
            this.OnCameraConnectedEvent?.Invoke(this, new CameraConnectedEvent(camera));
        }


        private void OnDeviceDisconnected(object sender, DriveChangedEventArgs e)
        {
            try
            {
                this.Disconnect();
                this.TryToMountDevice();

                USBCameraDevice camera = Globals.CAMERAS_LIST.Find((USBCameraDevice device) => device.Name == e.Drive);

          
                if (camera == null)
                    return;

                RemoveCamerasFromTheGlobalMemory.Execute(camera.BadgeId, Globals.ClientTunnel);
                Globals.Logger.warn(String.Format("Camera with badge id {0} was removed successfully", camera.BadgeId));

                this.OnCameraDisconnectedEvent?.Invoke(this, new CameraDisconnectedEvent(camera));
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
            foreach(KeyValuePair<string, USBCameraDevice> kvp in Globals.USB_CAMERA_DEVICES_LIST)
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
