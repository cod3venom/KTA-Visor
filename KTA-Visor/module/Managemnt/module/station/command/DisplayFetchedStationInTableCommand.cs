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

            table.Invoke((MethodInvoker)delegate
            {
                table.DataGridView.Rows.Clear();
            });
            foreach (StationEntity.Station stationData in station?.datas)
            {
                
                table.Invoke((MethodInvoker)delegate
                {
                    bool active = Globals.STATIONS_LIST.Find((stationClient) => stationClient.stationIp == stationData.stationIp) != null;
                    table.DataGridView.Rows.Add(
                       stationData?.stationId,
                       stationData.stationIp,
                       stationData.stationIp,
                       active ? "Tak" : "Nie",
                       stationData.updatedAt,
                       stationData.createdAt
                   );
                });
            }
            
        }
    }
}
