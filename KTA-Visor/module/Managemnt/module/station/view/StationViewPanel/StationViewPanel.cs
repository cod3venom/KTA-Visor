
using KTA_Visor.kernel.module.ThreadPool;
using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.controller;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.basic.table;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KTA_Visor.module.Managemnt.module.station.command.HandleStationContextMenuClickEventCommand;

namespace KTA_Visor.module.Managemnt.module.station.view.StationViewPanel
{
    public partial class StationViewPanel : UserControl
    {

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

        private async void StationViewPanel_Load(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            this.initialize();
        }

        private async void initialize()
        {
            this.hookEvents();
            this.fetchStations();

        }

        private void hookEvents()
        {
            Globals.ServerTunnelBackgroundWorker.OnClientConnected += onStationConnected;
            Globals.ServerTunnelBackgroundWorker.OnClientDisconnected += onStationDisconnected;
            Globals.ServerTunnelBackgroundWorker.OnMessageReceivedFromClient += onResponseReceivedFromStation;

            this.table.DataGridView.CellDoubleClick += onCellDoubleClick;
            this.table.DataGridView.SelectionChanged += onSelectionChanged;
            this.table.OnRefreshData += onRefreshTableData;

            this.stationController.OnRefreshCamerasList += onRefreshCamerasList;

            this.shutDownPowerSupplyMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.getStationId(), (int)StationContextMenuItem.POWER_SUPPLY_OFF);
            this.resetPowerSupplyMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.getStationId(), (int)StationContextMenuItem.POWER_SUPPLY_RESTART);
            this.disconnectFromTunnelMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.getStationId(), (int)StationContextMenuItem.TUNNEL_DISCONNECT);
            this.resetTunnelMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.getStationId(), (int)StationContextMenuItem.TUNNEL_RESTART);
            this.connectRemoteDesktopMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.getStationId(), (int)StationContextMenuItem.RDP_CONNECT);
        }
 
       
        private void onStationConnected(object sender, events.OnClientConnected e)
        {
            this.fetchStations();
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

        private void onSelectionChanged(object sender, EventArgs e)
        {
            this.downloadSelectedStationCameras();
        }


        private async void onRefreshTableData(object sender, EventArgs e)
        {
            await Task.Delay(100);
            this.fetchStations();
            this.downloadSelectedStationCameras();
        }


        private void onRefreshCamerasList(object sender, Station.events.OnRefreshCamerasListEvent e)
        {
            this.downloadSelectedStationCameras();
        }

        private async void fetchStations()
        {
            DisplayFetchedStationInTableCommand.Execute(this.table);
            return;
        }

        private void downloadSelectedStationCameras()
        {
            DisplayCamerasOfSelectedStationCommand.Execute(this.camerasFlowPanel, this.getStationId());
            return;

        }

        public string getStationId()
        {
            if (this.table.DataGridView.SelectedRows.Count == 0)
                return "";

            if (this.table.DataGridView.SelectedRows[0].Cells[0]?.Value == null)
                return "";

            return this.table.DataGridView.SelectedRows[0].Cells[0]?.Value.ToString();
        }
    }
}
