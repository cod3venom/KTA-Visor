using Falcon_Protocol;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device.localSettings;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraFirmwareService
    {
        private readonly FalconProtocol _falconProtocol;
        private USBCameraDevice _currentCamera;
        private LocalSettingsTObject _settingsBackup;
        private string _firmwareDestPath = "";

        public CameraFirmwareService()
        {
            this._falconProtocol = new FalconProtocol();
        }

        public void Upgrade(CameraEntity.Camera camera, FileInfo firmware)
        {
            this._currentCamera = Globals.CAMERAS_LIST.GetByCustomID(camera.cameraCustomId);
            if (this._currentCamera == null) {
                Globals.ClientTunnel.Emit(new Request("command://cameras/firmware/upgrade/failed"));
                return;
            }

            this._currentCamera.Drive.RootDirectory.GetFiles().ToList().ForEach((FileInfo f) => 
            {
                if (f.Name != "LocalSettings.Json") {
                    f.Delete();
                }
            });
            this._currentCamera.Drive.RootDirectory.GetDirectories().ToList().ForEach((DirectoryInfo d) =>  d.Delete(true));
            
            this._firmwareDestPath = string.Format("{0}\\{1}", this._currentCamera.Drive.Name, firmware.Name);
            firmware.CopyTo(this._firmwareDestPath, true);

            Globals.ClientTunnel.Emit(new Request(
                 "command://cameras/firmware/upgrade/started"
            ));

            Globals.CAMERAS_LIST.OnCameraAddedInMemory += onCameraReconnected;

            Globals.ALLOW_FS_MOUNTING = false;
            this._falconProtocol.SetAPIMode(this._currentCamera.Drive.Name);
            Thread.Sleep(10000);
            Globals.ALLOW_FS_MOUNTING = true;

        }

        private void onCameraReconnected(object sender, types.device.events.CameraAddedToTheMemoryEvent e)
        {
            if (File.Exists(this._firmwareDestPath))
            {
                File.Delete(this._firmwareDestPath);
            }
        }
    }
}
