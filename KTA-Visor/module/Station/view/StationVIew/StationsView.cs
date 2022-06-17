using KTA_Visor.component.basic.table;
using KTA_Visor.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor.component.basic.table.bundle.abstraction.row.dto;
using KTA_Visor.component.custom.NavigationBar;
using KTA_Visor.module.Authentication.view;
using KTA_Visor.module.Settings.view;
using KTA_Visor.module.Station.components;
using KTA_Visor.module.Station.controller;
using KTA_Visor.module.Tunnel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.view
{
    public partial class StationsView : Form
    {
        private readonly RFIDAuthenticationView authView;

        private readonly SettingsView settingsView;

        private readonly Tunnel.Tunnel tunnel;

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
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            this.table1.bundle.column.addMultiple(this.Columns);

            this.hookTunnelPipe();
        }

        private void hookTunnelPipe()
        {
            this.tunnel.start();
            this.tunnel.onClientConnected += Tunnel_onClientConnected;
            this.tunnel.onClientDisconnected += Tunnel_onClientDisconnected;
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;
        }

        private void Tunnel_onClientConnected(object sender, TCPTunnel.module.server.events.TCPServerClientConnectedEvent e)
        {
            this.table1.bundle.row.add(
                "1",
                e.getClient().getIpAddress(),
                "Docking station#" + e.getClient().getIpAddress(),
                "8",
                "Online"
            );
        }

        private void Tunnel_onClientDisconnected(object sender, TCPTunnel.module.server.events.TCPServerClientDisonnectedEvent e)
        {
           this.table1.bundle.row.removeRow(e.getClient().getIpAddress());
        }


        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.server.events.TCPServerClientMessageReceivedEvent e)
        {
            StationController controller = new StationController(this);
            controller.StartWatching(e.getRoute());
        }

      
    }
}
