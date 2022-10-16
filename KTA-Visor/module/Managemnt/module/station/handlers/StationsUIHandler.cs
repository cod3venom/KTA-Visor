using KTA_Visor.module.Managemnt.module.station.view;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.station.handlers
{
    public class StationsUIHandler
    {

        private readonly StationView stationView;
        private readonly StationService stationService;
        public StationsUIHandler(StationView stationView)
        {
            this.stationView = stationView;
            this.stationService = new StationService();
        }

        public  void Load()
        {
            Thread loadingThread = new Thread(async () =>
            {
                List<StationEntity.Station> stations = await this.allStations();
                this.cleanTable();

                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
                Parallel.ForEach(stations, options, station =>
                {
                    this.addToTable(station);
                });
            });
            loadingThread.IsBackground = true;
            loadingThread.Start();
        }


        
        
        private async Task<List<StationEntity.Station>> allStations()
        {
            StationEntity station = await this.stationService.all();
            if (station.datas == null){
                return new List<StationEntity.Station>();
            }
      
            return station.datas;
        }


        private void cleanTable()
        {
            this.stationView.Table.Invoke((MethodInvoker)delegate
            {
                this.stationView.Table.DataGridView.Rows.Clear();
            });
        }
        private void addToTable(StationEntity.Station station)
        {
            this.stationView.Table.Invoke((MethodInvoker)delegate
            {
                bool active = Globals.Server.Clients.Find((TCPClientTObject stationClient) => stationClient.IpAddress == station.stationIp) != null;
                this.stationView.Table.DataGridView.Rows.Add(
                   station?.stationId,
                   station.stationIp,
                   station.stationIp,
                   active ? Properties.Resources.green_circle : Properties.Resources.red_circle,
                   station.updatedAt,
                   station.createdAt
               );
            });
        }
    }
}
