using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraPowerService
    {
        public async void Blink(CameraEntity cameraEntity)
        {
            Thread blinkThread = new Thread((ThreadStart) =>
            {
                USBCameraDevice cameraDevice = Globals.CAMERAS_LIST.Find(
                    (camera) => 
                    camera.ID == cameraEntity?.data?.cameraCustomId ||
                    camera.BadgeId == cameraEntity?.data?.badgeId ||
                    camera.Index == cameraEntity?.data.index
                );

                if (cameraDevice == null)
                {
                    Globals.ClientTunnel.Emit(new Request(
                        "response://camera/blink/card/device-not-found"
                    ));
                    Globals.Logger.warn(String.Format("Not found Camera device with badge id: {0}", cameraEntity?.data?.badgeId));
                    return;
                }

                int portNumber = Globals.Relay.FindPortByCameraCustomId(cameraEntity?.data?.cameraCustomId);

                if (portNumber == 0){
                    return;
                }


                Globals.Relay.turnOffAll(0);

                for (int i = 0; i <= 10; i++)
                {
                    Globals.Relay.turnOffByPort(portNumber, 100);
                    Thread.Sleep(10);
                    Globals.Relay.turnOnByPort(portNumber, 100);
                }

                Globals.ALLOW_FS_MOUNTING = true;
                Globals.Relay.turnOnAll();
            });

            blinkThread.IsBackground = true;
            blinkThread.Start();
        }

    }
}
