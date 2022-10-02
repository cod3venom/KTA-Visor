using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.basic.table;
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
    public class DisplayFetchedStationInTableCommand
    {

        public static async void Execute(Table table)
        {

            StationEntity station  = await new StationService().all();

            if (station?.datas == null)
                return;
            
            Globals.STATIONS_LIST.Clear();
            table.DataGridView.Rows.Clear();

            foreach(StationEntity.Station stationData in station?.datas)
            {
                if (!stationData.active)
                    continue;

                table.Invoke((MethodInvoker)delegate
                {
                    table.DataGridView.Rows.Add(
                       stationData?.stationId,
                       stationData.stationIp,
                       stationData.stationIp,
                       stationData.active ? "Tak" : "Nie",
                       stationData.updatedAt,
                       stationData.createdAt
                   );
                });
            }
            
        }
    }
}
