﻿using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraPowerService
    {
        public async void Blink(CameraEntity cameraEntity)
        {
            USBCameraDevice cameraDevice = Globals.CAMERAS_LIST.Find((camera) => camera.BadgeId == cameraEntity?.data?.badgeId);
            if (cameraDevice == null)
                return;

            int portNumber = Globals.Relay.findPortByBadgeId(cameraEntity?.data?.badgeId);

            if (portNumber == 0)
                return;


            Thread.Sleep(1000);
            Globals.Relay.turnOffAll();
            Thread.Sleep(3000);

            for (int i = 0; i <= 10; i++)
            {
                Globals.Relay.turnOffByPort(portNumber);
                Thread.Sleep(1000);
                Globals.Relay.turnOnByPort(portNumber);
            }

            Thread.Sleep(8000);
            Globals.ALLOW_FS_MOUNTING = true;
            Globals.Relay.turnOnAll();
        }
    }
}
