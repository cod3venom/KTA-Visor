using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
namespace KTA_Visor.module.Managemnt.module.camera.command
{
    public class BlinkCameraInstationBasedOnCardIdCommand
    {
        public static async void Execute(string cardId)
        {
            
            CameraEntity camera = await new CameraService().findByCardId(cardId);
            if (camera.data == null)
                return;


            StationEntity station = await new StationService().findByStationId(camera.data.stationId);

            if (station.data == null)
                return;

            TCPClientTObject stationClient = Globals.CLIENTS_LIST.Find((TCPClientTObject client) => client.getIpAddress() == station.data.stationIp);
            
            stationClient.Send(new Request(
                "command://station/cameras/card/blink",
                camera
            ));
        }
    }
}
