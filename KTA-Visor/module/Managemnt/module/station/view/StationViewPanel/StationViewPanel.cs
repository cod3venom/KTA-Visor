using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.controller;
using KTA_Visor.module.Shared.Global;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using TCPTunnel.module.client;

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
            this.table.bundle.column.addMultiple(this.Columns);
        }

        private void StationViewPanel_Load(object sender, EventArgs e)
        {
            Globals.ServerTunnelBackgroundWorker.OnClientConnected += onStationConnected;
            Globals.ServerTunnelBackgroundWorker.OnClientDisconnected += onStationDisconnected;
            Globals.ServerTunnelBackgroundWorker.OnMessageReceivedFromClient += onResponseReceivedFromStation;
            this.table.DataGridView.Cursor = Cursors.Hand;
            this.table.DataGridView.CellDoubleClick += onCellDoubleClick;
        }

       
        private void onStationConnected(object sender, events.OnClientConnected e)
        {
            DisplayStationInTableCommand.Execute(this.table.DataGridView, e);
        }

        private void onStationDisconnected(object sender, events.OnClientDisconnected e)
        {
            this.table.bundle.row.removeRow(e.Client.getIpAddress());
        }


        private void onResponseReceivedFromStation(object sender, events.OnMessageReceivedFromClient e)
        {
            this.stationController.Watch(e.Request);
        }

        private void onCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AskForCamerasOfSelectedStationCommand.Execute(this.table.DataGridView, e);
        }

    }
}
