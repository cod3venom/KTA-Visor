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

        private readonly StationView _stationView;
        private readonly StationService _stationService;

        public StationsUIHandler(StationView stationView)
        {
            this._stationView = stationView;
            this._stationService = new StationService();
            this.hookEvents();
        }

        private void hookEvents()
        {
            Globals.Server.OnClientConnected += onStationConnected;
        }
 

        private void onStationConnected(object sender, events.OnClientConnected e)
        {
            this.Load();
        }


        public void Load()
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

                this._stationView.CamerasUIHandler.Load(this.StationId);
            });
            loadingThread.IsBackground = true;
            loadingThread.Start();
        }

        private async Task<List<StationEntity.Station>> allStations()
        {
            StationEntity station = await this._stationService.all();
            if (station.datas == null){
                return new List<StationEntity.Station>();
            }
      
            return station.datas;
        }

        private void cleanTable()
        {
            if (!this._stationView.IsHandleCreated){
                return;
            }
            this._stationView.Table.Invoke((MethodInvoker)delegate
            {
                this._stationView.Table.DataTable.Rows.Clear();
            });
        }

        private void addToTable(StationEntity.Station station)
        {
            if (!this._stationView.IsHandleCreated){
                return;
            }
            this._stationView.Table.Invoke((MethodInvoker)delegate
            {
                bool active = Globals.Server.Clients.Find((TCPClientTObject stationClient) => stationClient.IpAddress == station.stationIp) != null;
                this._stationView.Table.Row.Add(
                   station?.stationId,
                   station.stationIp,
                   station.stationIp,
                   active ? Properties.Resources.green_circle : Properties.Resources.red_circle,
                   station.updatedAt,
                   station.createdAt
               );
            });
        }

        public string StationId
        {
            get
            {
                if (this._stationView.Table.DataGridView.SelectedRows.Count == 0)
                    return "";

                if (this._stationView.Table.DataGridView.SelectedRows[0].Cells[0]?.Value == null)
                    return "";

                return this._stationView.Table.DataGridView.SelectedRows[0].Cells[0]?.Value.ToString();
            }
        }
    }
}
