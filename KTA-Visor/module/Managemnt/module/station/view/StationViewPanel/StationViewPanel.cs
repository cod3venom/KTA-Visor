
using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.controller;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.basic.table;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.view.StationViewPanel
{
    public partial class StationViewPanel : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "IDENTYFIKATOR STACJI"),
            new ColumnTObject(1, "IP ADRES"),
            new ColumnTObject(2, "IP Klienta"),
            new ColumnTObject(3, "AKTYWNY"),
            new ColumnTObject(4, "ZMODYFIKOWANO"),
            new ColumnTObject(5, "UTWORZONO")
        };

        private readonly StationService stationService;
        private readonly StationController stationController;
        private readonly CameraService cameraService;


        public StationViewPanel()
        {
            InitializeComponent();
            this.stationService = new StationService();
            this.stationController = new StationController(this);
            this.cameraService = new CameraService();
            this.table.AllowAdd = false;
            this.table.AllowEdit = false;
            this.table.AllowDelete = false;
            this.table.Column.addMultiple(this.Columns);
        }

      

        private void StationViewPanel_Load(object sender, EventArgs e)
        {

            this.initialize();
        }
 
        private async void initialize()
        {
            await this.loader.Start(1000, 100);
            this.hookEvents();
            await this.loader.Stop(1000);

        }
        private void hookEvents()
        {
            Globals.ServerTunnelBackgroundWorker.OnClientConnected += onStationConnected;
            Globals.ServerTunnelBackgroundWorker.OnClientDisconnected += onStationDisconnected;
            Globals.ServerTunnelBackgroundWorker.OnMessageReceivedFromClient += onResponseReceivedFromStation;
            this.table.DataGridView.Cursor = Cursors.Hand;
            this.table.DataGridView.CellDoubleClick += onCellDoubleClick;
            this.stationController.OnRefreshCamerasList += onRefreshCamerasList;
        }

        private void onStationConnected(object sender, events.OnClientConnected e)
        {
            DisplayStationInTableCommand.Execute(this.table.DataGridView, e);
            this.downloadSelectedStationCameras();
        }

        private void onStationDisconnected(object sender, events.OnClientDisconnected e)
        {
            this.table.Row.Remove(e.Client.getIpAddress());
            this.downloadSelectedStationCameras();
        }


        private void onResponseReceivedFromStation(object sender, events.OnMessageReceivedFromClient e)
        {
            this.stationController.Watch(e.Request);
        }

        private void onCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           this.downloadSelectedStationCameras();
        }

        private void onRefreshCamerasList(object sender, Station.events.OnRefreshCamerasListEvent e)
        {
            this.downloadSelectedStationCameras();
        }

        private void downloadSelectedStationCameras()
        {
            string stationCustomId = this.getStationId();
            DisplayCamerasOfSelectedStationCommand.Execute(this.cameraService, this.camerasFlowPanel, stationCustomId);
        }

        private string getStationId()
        {
            if (this.table.DataGridView.SelectedRows.Count == 0)
                return "";

            if (this.table.DataGridView.SelectedRows[0].Cells[0]?.Value == null)
                return "";

            return this.table.DataGridView.SelectedRows[0].Cells[0]?.Value.ToString();
        }
    }
}
