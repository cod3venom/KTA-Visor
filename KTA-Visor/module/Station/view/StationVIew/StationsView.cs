using KTA_Visor.module.Authentication.view;
using KTA_Visor.module.Settings.view;
using KTA_Visor.module.Station.components.StationItem.StationItem;
using KTA_Visor.module.Station.components.StationItem.events;
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
using KTA_Visor.module.station.componnets.StationItem;

namespace KTA_Visor.module.Station.view
{
    public partial class StationsView : Form
    {
        private readonly RFIDAuthenticationView authView;

        private readonly SettingsView settingsView;

        private readonly Tunnel.Tunnel tunnel;

        private readonly StationViewService stationViewService;

        private readonly StationController controller;

        private readonly List<StationItem> stationsList;

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
            this.stationsList = new List<StationItem>();

          
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar.Parent = this;
            this.topBar.onClose += StationsView_OnClose;
            this.initialize();
        }

        private void initialize()
        {
            this.tunnel.onClientConnected += Tunnel_onClientConnected;
            this.tunnel.onClientDisconnected += Tunnel_onClientDisconnected;
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;   
            this.stationViewService.onAuthorized += StationViewService_onAuthorized;
        }
 
 
        private void Tunnel_onClientConnected(object sender, TCPTunnel.module.server.events.TCPServerClientConnectedEvent e)
        {
            e.getClient().Send(new Request(
                "command://station/authenticate"
            ));
        }

        private void Tunnel_onClientDisconnected(object sender, TCPTunnel.module.server.events.TCPServerClientDisonnectedEvent e)
        {
            foreach (StationItem stationItem in this.stationsFlowLayoutPanel.Controls)
            {
                if (stationItem.Station.Client.getIpAddress() != e.getClient().getIpAddress()) continue;

                this.Invoke((MethodInvoker)delegate {
                    this.stationsFlowLayoutPanel.Controls.Remove(stationItem);
                });
            }
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

            StationItem stationItem = new StationItem(station);

            if (this.stationsList.Find(item => item.Station.IpAddress == station.IpAddress) == null)
            {
                this.stationsList.Add(stationItem);

                this.Invoke((MethodInvoker)delegate
                {
                    this.stationsFlowLayoutPanel.Controls.Add(stationItem);
                    stationItem.OnStationClick += OnOpenStation;
                });
            }
            
        }

        private void OnOpenStation(object sender, StationOnClickEvent e)
        {
            this.Hide();

            SingleStationView singleStationView = new SingleStationView(e.Station, this.tunnel);
            singleStationView.ShowDialog();
        }

        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.server.events.TCPServerClientMessageReceivedEvent e)
        {
            controller.StartWatching(e.getRoute());
        }

        private void StationsView_OnClose(object sender, EventArgs e)
        {
            this.tunnel.stop();
        }

    }
}
