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
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
namespace KTA_Visor.module.Managemnt.module.camera.command
{
    public class BlinkCameraInstationBasedOnCardIdCommand
    {
        public static async void Execute(string cardId)
        {
            
            if (cardId.Length > 15)
            {
                MessageBox.Show("ID Karty nie moze wynosic wiecej niz 15 znaków");
                return;
            }


            CameraEntity camera = await new CameraService().findByCardId(cardId);
            if (camera.data == null)
            {
                MessageBox.Show("Nie znależiono kamery o takim ID");
                return;
            }


            StationEntity station = await new StationService().findByStationId(camera.data.stationId);

            if (station.data == null)
                return;

            TCPClientTObject stationClient = Globals.Server.Clients.Find((TCPClientTObject client) => client.IpAddress == station.data.stationIp);

            if (stationClient == null)
                return;

            stationClient.Send(new Request(
                "command://cameras/card/blink",
                camera,
                stationClient
            ));
        }
    }
}
