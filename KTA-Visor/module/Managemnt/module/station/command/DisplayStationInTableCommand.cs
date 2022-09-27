using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Shared.Global;
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

namespace KTA_Visor.module.Managemnt.module.station.command
{
    public class DisplayStationInTableCommand
    {

        public static async void Execute(DataGridView table, OnClientConnected e)
        {

            StationEntity station  = await new StationService().findByCustomId(e.Client.AuthData.Identificator);

            if (station?.data == null)
                return;
            if (Globals.STATIONS_LIST.Contains(station.data))
                return;

            Globals.STATIONS_LIST.Add(station.data);

            table.Invoke((MethodInvoker)delegate
            {
                table.Rows.Add(
                   station?.data?.stationId,
                   e.Client?.IpAddress,
                   station?.data?.stationIp,
                   station.data.active ? "Tak" : "Nie",
                   station?.data?.updatedAt,
                   station?.data?.createdAt
               );


                for(int i = 0; i < 100; i++)
                {
                    StationEntity fakeStation = new StationEntity();
                    fakeStation.data = station.data;
                    fakeStation.data.id = i.ToString();
                    fakeStation.data.stationId = "station_" + i.ToString();
                    fakeStation.data.active = true;

                    string fakeIp = "127.0.0.1." + i.ToString();
                    table.Rows.Add(
                          fakeStation?.data?.stationId,
                          fakeIp,
                          fakeStation?.data?.stationIp,
                          fakeStation.data.active ? "Tak" : "Nie",
                          fakeStation?.data?.updatedAt,
                          fakeStation?.data?.createdAt
                      );
                }
            });
        }
    }
}
