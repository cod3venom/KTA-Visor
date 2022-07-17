using KTA_Visor.module.Authentication.view;
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
using KTA_Visor.module.Station.components.StationItem;
using KTA_Visor.module.Station.components.StationItem.events;
using KTA_Visor.module.Station.components.ClientsList.components.ClientItem;
using KTA_Visor.module.Tunnel.view;

namespace KTA_Visor.module.Station.view
{
    public partial class StationsView : Form
    {
        
        private readonly TunnelSettingsView tunnelSettingsView;

        private readonly Tunnel.Tunnel tunnel;

        private readonly StationViewService stationViewService;

        private readonly StationController controller;

        private readonly List<StationItem> stationsList;

   

        public StationsView()
        {
            InitializeComponent();
            this.loggerView.ParentPanel = this.loggerPanel;
            this.tunnelSettingsView = new TunnelSettingsView();

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
            this.startTunnelServerMenuItem.Click += StartTunnel;
            this.stopTunnelServerMenuItem.Click += StopTunnel;
            this.tunnelSettingsBtn.OnClick += OpenTunnelSettings;
            this.tunnel.onClientConnected += Tunnel_onClientConnected;
            this.tunnel.onClientDisconnected += Tunnel_onClientDisconnected;
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;
            this.stationViewService.onAuthorized += StationViewService_onAuthorized1;
           
        }

        private void StationViewService_onAuthorized1(object sender, Request e)
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
                    stationItem.OnClick += OnOpenStation;
                });
            }
        }

        private void StartTunnel(object sender, EventArgs e)
        {
            this.tunnel.start();
            this.tunnelIndicator.running(true, "Uruchomiony");
        }

        private void StopTunnel(object sender, EventArgs e)
        {
            this.tunnel.stop();
            this.tunnelIndicator.running(false, "Wstrzymany");
        }

        private void OpenTunnelSettings(object sender, EventArgs e)
        {
            (new TunnelSettingsView()).ShowDialog();
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
                    stationItem.OnClick += OnOpenStation;
                });
            }
            
        }

        private void OnOpenStation(object sender, StationItemClickEvent e)
        {
            this.Hide();

            SingleStationView singleStationView = new SingleStationView(e.Item?.Station, this.tunnel);
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
