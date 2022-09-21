﻿using Falcon_Protocol;
using KTA_Visor_DSClient.module.Management.module.Camera;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
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
        private readonly FalconProtocol falconProtocol;
        public CameraDeviceSettingsService()
        {
            this.falconProtocol = new FalconProtocol();
        }

        public  void SelectDevice(string badgeId)
        {
            Globals.ALLOW_FS_MOUNTING = false;
         
            int portName = Globals.Relay.findPortByBadgeId(badgeId);

            Globals.Relay.turnOffAll();
            Thread.Sleep(4000);
            Globals.Relay.turnOnByPort(portName);
            Thread.Sleep(4000);
            this.falconProtocol.Connect();
           
        }

        public void DeSelectDevice()
        {
            Globals.ALLOW_FS_MOUNTING = true;

            Globals.Relay.turnOffAll();
            Thread.Sleep(4000);
            Globals.Relay.turnOnAll();
        }

        public MENU_CONFIG GetMenuConfig( int index = -1)
        {
            this.falconProtocol.SetIndex(index);
            return this.falconProtocol.GetMenuConfig();
        }

        public MENU_CONFIG SetMenuConfig(CameraEntity.Camera camera)
        {
            USBCameraDevice device = Globals.CAMERAS_LIST.ToList().Find((USBCameraDevice dev) => dev.Drive.Name.Contains(camera.driveName));
            
            this.SelectDevice(camera.badgeId);
            

            var menuStruct = this.falconProtocol.GetMenuConfig();
            menuStruct.video_res = Convert.ToByte(camera.settings.resolution);
            menuStruct.video_quality = Convert.ToByte(camera.settings.quality);
            menuStruct.video_format = Convert.ToByte(camera.settings.codecFormat);
            menuStruct.time_zone = Convert.ToByte(camera.settings.timeZone);
            menuStruct.wifi = Convert.ToByte(camera.settings.wifi);
            menuStruct.aes_crypto = Convert.ToByte(camera.settings.aesEncryption);
            menuStruct.gps = Convert.ToByte(camera.settings.gps);
            menuStruct.wifi = Convert.ToByte(camera.settings.wifi);



            device.Settings.ID = camera.cameraCustomId;
            device.Settings.BadgeId = camera.badgeId;
            device.SaveSettings();
            this.falconProtocol.SetMenuConfig(menuStruct);

            this.DeSelectDevice();
            return menuStruct;
        }


    }
}