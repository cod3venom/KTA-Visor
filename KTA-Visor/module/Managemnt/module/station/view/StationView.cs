using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.station.controller;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using KTA_Visor_UI.component.basic.table;
using KTA_Visor.module.Managemnt.module.station.handlers;
using MetroFramework;
using KTA_Visor_UI.component.basic.table.enums;
using TCPTunnel.kernel.types;
using KTA_Visor.module.Managemnt.module.camera.view.cameraFileTransfersView;
using KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool;
using KTA_Visor_UI.component.custom.ClientsList.events;

namespace KTA_Visor.module.Managemnt.module.station.view
{
    public partial class StationView : UserControl, IControllerInterface
    {
        private readonly ColumnTObject[] Columns = new ColumnTObject[] {
            new ColumnTObject(0, "IDENTYFIKATOR STACJI"),
            new ColumnTObject(1, "IP ADRES"),
            new ColumnTObject(2, "IP Klienta"),
            new ColumnTObject(3, "AKTYWNY", ColumnType.IMAGE, true, true, 25),
            new ColumnTObject(4, "ZMODYFIKOWANO"),
            new ColumnTObject(5, "UTWORZONO")
        };

        private readonly Management.view.Management _management;
        public StationView(Management.view.Management management)
        {
            InitializeComponent();
            this._management = management;
            this.StationController = new StationController(this);

            this.StationsUIHandler = new StationsUIHandler(this);
            this.StationContextMenuUIHandler = new StationContextMenuUIHandler(this, this.stationContextMenu);
            
            this.CamerasUIHandler = new CamerasUIHandler(this);
            this.CamerasFlowBoardContextMenuUIHandler = new CamerasFlowPanelContextMenuUIHandler(this, this.camerasFlowPanelContextMenu);

            this.table.AllowAdd = false;
            this.table.AllowEdit = false;
            this.table.AllowDelete = false;
            this.table.Columns = this.Columns;
            this.tabControl.SelectedIndex = 0;
        }

        public void Watch(Request request)
        {
            this.StationController.Watch(request);
        }

        private async void StationViewPanel_Load(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            this.hookEvents();
            this.initialize();
        }
 
        private void hookEvents()
        {
            this._management.ClientsManagerModule.OnClientConnected += onClientConnected;
            this._management.ClientsManagerModule.OnClientDisconnected += onClientDisconnected;
            this.table.DataGridView.CellDoubleClick += onCellDoubleClick;
            this.table.OnRefreshData += onRefreshTableData;
        }

        private void onClientConnected(object sender, OnClientConnected e)
        {
            ThreadPoolManager.Run(this.StationsUIHandler.LoadStations, true);
            ThreadPoolManager.Run(() => this.CamerasUIHandler.Load(this.StationId), true);
        }

        private void onClientDisconnected(object sender, OnClientDisconnected e)
        {
            this.StationsUIHandler.RemoveByValue(e.IpAddress);
        }

        private void initialize()
        {
            this.StationContextMenuUIHandler.Handle();
            this.CamerasFlowBoardContextMenuUIHandler.Handle();
            this.StationsUIHandler.LoadStations();
        }

        private void onRefreshTableData(object sender, EventArgs e)
        {
            ThreadPoolManager.Run(this.StationsUIHandler.LoadStations, true);
            ThreadPoolManager.Run(() => this.CamerasUIHandler.Load(this.StationId), true);
        }

        private void onCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.IsSelectedStationActive)
            {
                MetroMessageBox.Show(this, "Wybrana stacja jest nie aktywna", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ThreadPoolManager.Run(() => this.CamerasUIHandler.Load(this.StationId), true);
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
        public CamerasFlowPanelContextMenuUIHandler CamerasFlowBoardContextMenuUIHandler { get; set; }
        public CamerasUIHandler CamerasUIHandler{ get; set; }
 
        public Table Table { get { return this.table; } }
        public Control CamerasBoard { get { return this.camerasFlowPanel; } }

        public StationController StationController { get; set; }
        
        public string StationId
        {
            get
            {
                if (this.table.DataGridView.SelectedRows.Count == 0)
                {
                    return "";
                }
                if (this.table.DataGridView.SelectedRows[0].Cells.Count == 0)
                {
                    return "";
                }

                if (this.table.DataGridView.SelectedRows[0].Cells[0]?.Value == null)
                {
                    return "";
                }

                return this.table.DataGridView.SelectedRows[0].Cells[0]?.Value.ToString();
            }
        }
        public string StationIp
        {
            get
            {
                if (this.table.DataGridView.SelectedRows.Count == 0)
                {
                    return "";
                }
                if (this.table.DataGridView.SelectedRows[0].Cells.Count == 0)
                {
                    return "";
                }

                if (this.table.DataGridView.SelectedRows[0].Cells[1]?.Value == null)
                {
                    return "";
                }

                return this.table.DataGridView.SelectedRows[0].Cells[1]?.Value.ToString();
            }
        }
    }
}
