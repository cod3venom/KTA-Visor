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

            if (Globals.STATIONS_LIST.Contains(station.data))
                return;

            Globals.STATIONS_LIST.Add(station.data);

            table.Rows.Add(
                station?.data?.stationId,
                e.Client?.IpAddress,
                station?.data?.stationIp,
                station.data.active ? "Tak" : "Nie",
                station?.data?.updatedAt,
                station?.data?.createdAt
            );

            e.Client.Send(new Request("command://cameras/all"));
        }
    }
}
