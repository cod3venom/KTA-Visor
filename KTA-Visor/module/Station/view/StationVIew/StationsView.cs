using KTA_Visor.module.Authentication.view;
using KTA_Visor.module.Settings.view;
using KTA_Visor.module.Station.components;
using KTA_Visor.module.Station.controller;
using KTA_Visor.module.Station.dto;
using KTA_Visor.module.Station.helper;
using KTA_Visor.module.Station.service;
using KTA_Visor.module.Station.view.StationVIew;
using KTA_Visor.module.Tunnel;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Station.view
{
    public partial class StationsView : Form
    {
        private readonly RFIDAuthenticationView authView;

        private readonly SettingsView settingsView;

        private readonly Tunnel.Tunnel tunnel;

        private readonly StationViewService stationViewService;

        private readonly StationController controller;

        private readonly List<StationTObject> stationsList;

        private readonly ColumnTObject[] Columns = new ColumnTObject[] { 
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IP Address"),
            new ColumnTObject(2, "Name"),
            new ColumnTObject(3, "Total ports"),
            new ColumnTObject(4, "Status"),
        };

        public StationsView()
        {
            InitializeComponent();
            this.authView = new RFIDAuthenticationView();
            this.settingsView = new SettingsView();
            this.tunnel = new Tunnel.Tunnel();
            this.stationViewService = new StationViewService(this);
            this.controller = new StationController(this, this.stationViewService);
            this.stationsList = new List<StationTObject>();
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            this.topBar1.onClose += StationsView_OnClose;
            this.table.bundle.column.addMultiple(this.Columns);

            this.initialize();
        }

        private void StationsView_OnClose(object sender, EventArgs e)
        {
            this.tunnel.stop();
        }

        private void initialize()
        {
            this.tunnel.start();
            this.tunnel.onClientConnected += Tunnel_onClientConnected;
            this.tunnel.onClientDisconnected += Tunnel_onClientDisconnected;
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;
            
            this.stationViewService.onAuthorized += StationViewService_onAuthorized;
            this.table.DataGridView.CellDoubleClick += TableRow_CellDoubleClick;
        }

        private void TableRow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();

            StationTObject station = RowHelper.RowToStation(this.table.DataGridView.SelectedRows);
            station = this.stationsList.Find(item => item.ID == station.ID);

            SingleStationView singleStationView = new SingleStationView(station, this.tunnel);
            singleStationView.ShowDialog();
        }
 
        private void Tunnel_onClientConnected(object sender, TCPTunnel.module.server.events.TCPServerClientConnectedEvent e)
        {
            e.getClient().Send(new Request(
                "command://station/authenticate"
            ));
        }

        private void Tunnel_onClientDisconnected(object sender, TCPTunnel.module.server.events.TCPServerClientDisonnectedEvent e)
        {
            this.table.bundle.row.removeRow(e.getClient().getIpAddress());
        }


        private void StationViewService_onAuthorized(object sender, Request e)
        {
            StationTObject station = new StationTObject();

            station.ID = this.stationsList.Count() + 1;
            station.IpAddress = e.Body?.IpAddress;
            station.Name = e.Body?.Name;
            station.TotalPorts = e.Body?.TotalPorts;
            station.Status = e.Body?.Status;
            station.Client = e.Client;

            if (this.stationsList.Find(item => item.IpAddress == station.IpAddress) == null)
            {
                this.stationsList.Add(station);

                this.table.bundle.row.add(
                  station.ID.ToString(),
                  station.IpAddress,
                  station.Name,
                  station.TotalPorts.ToString(),
                  station.Status
              );
            }
            
        }


        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.server.events.TCPServerClientMessageReceivedEvent e)
        {
            controller.StartWatching(e.getRoute());
        }

      
    }
}
