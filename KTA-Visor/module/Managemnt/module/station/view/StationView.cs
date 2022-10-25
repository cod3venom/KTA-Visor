using static KTA_Visor.module.Managemnt.module.station.command.HandleStationContextMenuClickEventCommand;
using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.controller;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using KTA_Visor.module.Station.events;
using KTA_Visor_UI.component.basic.table;
using KTA_Visor.module.Managemnt.module.station.handlers;
using MetroFramework;
using KTA_Visor_UI.component.basic.table.enums;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.station.view
{
    public partial class StationView : UserControl, IControllerInterface
    {
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "IDENTYFIKATOR STACJI"), // stationCustomId
            new ColumnTObject(1, "IP ADRES"),
            new ColumnTObject(2, "IP Klienta"),
            new ColumnTObject(3, "AKTYWNY", ColumnType.IMAGE, true, 50),
            new ColumnTObject(4, "ZMODYFIKOWANO"),
            new ColumnTObject(5, "UTWORZONO")
        };

        private readonly StationController stationController;
        
        public StationView()
        {
            InitializeComponent();
            this.stationController = new StationController(this);
            this.StationsUIHandler = new StationsUIHandler(this);
            this.StationContextMenuUIHandler = new StationContextMenuUIHandler(this, this.stationContextMenu);
            this.CamerasUIHandler= new CamerasUIHandler(this);

            this.table.AllowAdd = false;
            this.table.AllowEdit = false;
            this.table.AllowDelete = false;
            this.table.Column.addMultiple(this.Columns);
        }

        public Table Table { get { return this.table; } }
        public Control CamerasBoard { get { return this.camerasFlowPanel; } }

        public void Watch(Request request)
        {
            this.stationController.Watch(request);
        }

        private async void StationViewPanel_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            this.hookEvents();
            this.initialize();
        }
 
        private void hookEvents()
        {
            this.table.DataGridView.CellDoubleClick += onCellDoubleClick;
            this.table.OnRefreshData += onRefreshTableData;

            this.shutDownPowerSupplyMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.StationId, (int)StationContextMenuItem.POWER_SUPPLY_OFF);
            this.resetPowerSupplyMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.StationId, (int)StationContextMenuItem.POWER_SUPPLY_RESTART);
            this.disconnectFromTunnelMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.StationId, (int)StationContextMenuItem.TUNNEL_DISCONNECT);
            this.resetTunnelMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.StationId, (int)StationContextMenuItem.TUNNEL_RESTART);
            this.connectRemoteDesktopMenuItem.Click += (sender, e) => HandleStationContextMenuClickEventCommand.Execute(sender, e, this, this.StationId, (int)StationContextMenuItem.RDP_CONNECT);
        }
 

        private void initialize()
        {
            this.StationContextMenuUIHandler.Handle();
            this.StationsUIHandler.Load();
        }


        private void onRefreshTableData(object sender, EventArgs e)
        {
            this.StationsUIHandler.Load();
        }

        private void fetchStationCameras()
        {
            this.CamerasUIHandler.Load(this.StationId);
        }

        private void onCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.IsSelectedStationActive)
            {
                MetroMessageBox.Show(this, "Wybrana stacja jest nie aktywna", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.fetchStationCameras();
        }

        private bool IsSelectedStationActive
        {
            get
            {
                return Globals.Server.Clients.Find((TCPClientTObject _client) => _client.IpAddress == this.StationIp) != null;
            }
        }

        public StationsUIHandler StationsUIHandler { get; set; }
        public StationContextMenuUIHandler StationContextMenuUIHandler { get; set; }
        public CamerasUIHandler CamerasUIHandler{ get; set; }
        
        public string StationId
        {
            get
            {
                if (this.table.DataGridView.SelectedRows.Count == 0)
                    return "";

                if (this.table.DataGridView.SelectedRows[0].Cells[0]?.Value == null)
                    return "";

                return this.table.DataGridView.SelectedRows[0].Cells[0]?.Value.ToString();
            }
        }
        public string StationIp
        {
            get
            {
                if (this.table.DataGridView.SelectedRows.Count == 0)
                    return "";

                if (this.table.DataGridView.SelectedRows[0].Cells[1]?.Value == null)
                    return "";

                return this.table.DataGridView.SelectedRows[0].Cells[1]?.Value.ToString();
            }
        }
    }
}
