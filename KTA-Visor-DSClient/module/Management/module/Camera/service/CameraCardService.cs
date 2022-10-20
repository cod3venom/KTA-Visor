using Falcon_Protocol;
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
    public class CameraCardService
    {
        private readonly FalconProtocol _falconProtocol;

        public CameraCardService()
        {
            this._falconProtocol = new FalconProtocol();
        }

        public async void Blink(CameraEntity cameraEntity)
        {
            USBCameraDevice camera = Globals.CAMERAS_LIST.Find(
                   (device) =>
                   device.ID == cameraEntity?.data?.cameraCustomId ||
                   device.BadgeId == cameraEntity?.data?.badgeId ||
                   device.Index == cameraEntity?.data.index
               );

            if (camera == null)
            {
                Globals.ClientTunnel.Emit(new Request(
                    "response://camera/blink/card/device-not-found"
                ));
                Globals.Logger.warn(String.Format("Not found Camera device with badge id: {0}", cameraEntity?.data?.badgeId));
                return;
            }

            this._falconProtocol.Blink(camera.Index, 100);
        }
    }
}
