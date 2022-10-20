using Falcon_Protocol;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay.events;
using KTA_Visor_DSClient.module.Management.module.Camera;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraDeviceSettingsService
    {
        private readonly FalconProtocol _falconProtocol;
        private USBCameraDevice _selectedCameraDevice;
        private CameraEntity.Camera _cameraEntity;

        public CameraDeviceSettingsService()
        {
            this._falconProtocol = new FalconProtocol();
        }

        public void AssignValues(CameraEntity.Camera cameraEntity)
        {
            this._cameraEntity = cameraEntity;
        }
  

        public void SaveSettings()
        {

            this._selectedCameraDevice = Globals.CAMERAS_LIST.GetByDrive(this._cameraEntity.driveName);
            if (this._selectedCameraDevice == null){
                return;
            }

            this._falconProtocol.Disconnect();

            ZFY_INFO identifiers = this.configureIdentificators();
            
            Thread.Sleep(2500);

            MENU_CONFIG tweaks = this.configureTweaks();
            this.configureLocalIdentificators();
        }
        
        
        private ZFY_INFO configureIdentificators()
        {
            this._falconProtocol.Connect();
            ZFY_INFO zfyInfo = this._falconProtocol.GetDeviceInfo();

            byte[] camCustomIdCharArray = Encoding.ASCII.GetBytes(this._cameraEntity.cameraCustomId);
            byte[] badgeIdCharArray = Encoding.ASCII.GetBytes(this._cameraEntity.badgeId);

            Array.Copy(camCustomIdCharArray, zfyInfo.unitName, camCustomIdCharArray.Length);
            Array.Copy(badgeIdCharArray, zfyInfo.userName, badgeIdCharArray.Length);
            zfyInfo = this._falconProtocol.SetDeviceInfo(zfyInfo);

            this._falconProtocol.Disconnect();

            return zfyInfo;
        }

        private MENU_CONFIG configureTweaks()
        {
            this._falconProtocol.Connect();
            MENU_CONFIG menuStruct = this._falconProtocol.GetMenuConfig();
            menuStruct.video_res = Convert.ToByte(this._cameraEntity.settings.resolution);
            menuStruct.video_quality = Convert.ToByte(this._cameraEntity.settings.quality);
            menuStruct.video_format = Convert.ToByte(this._cameraEntity.settings.codecFormat);
            menuStruct.time_zone = Convert.ToByte(this._cameraEntity.settings.timeZone);
            menuStruct.wifi = Convert.ToByte(this._cameraEntity.settings.wifi);
            menuStruct.aes_crypto = Convert.ToByte(this._cameraEntity.settings.aesEncryption);
            menuStruct.gps = Convert.ToByte(this._cameraEntity.settings.gps);
            menuStruct.wifi = Convert.ToByte(this._cameraEntity.settings.wifi);
            menuStruct.vibrate = Convert.ToByte(this._cameraEntity.settings.silentMode);

            menuStruct = this._falconProtocol.SetMenuConfig(menuStruct);
            this._falconProtocol.Disconnect();
            return menuStruct;
        }

        private void configureLocalIdentificators()
        {
            this._selectedCameraDevice.Settings.ID = this._cameraEntity.cameraCustomId;
            this._selectedCameraDevice.Settings.BadgeId = this._cameraEntity.badgeId;
            this._selectedCameraDevice.SaveSettings();
        }
    }
}
