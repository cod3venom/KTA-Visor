using KTA_Visor.component.basic.table;
using KTA_Visor.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor.component.basic.table.bundle.abstraction.row.dto;
using KTA_Visor.component.custom.NavigationBar;
using KTA_Visor.module.Authentication.view;
using KTA_Visor.module.Settings.view;
using KTA_Visor.module.Station.components;
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

        private readonly TCPTunnel tunnel;

        private readonly ColumnTObject[] Columns = new ColumnTObject[] { 
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "IP Address"),
            new ColumnTObject(2, "Name"),
            new ColumnTObject(3, "Serial Number"),
            new ColumnTObject(4, "Total ports"),
            new ColumnTObject(5, "Status"),
        };
        public StationsView()
        {
            InitializeComponent();
            this.authView = new RFIDAuthenticationView();
            this.settingsView = new SettingsView();
            this.tunnel = new TCPTunnel();
        }

        private void StationsView_Load(object sender, EventArgs e)
        {
            this.topBar1.Parent = this;
            NavigationBar navBar = new NavigationBar();
            navBar.Links = new string[] { "Stacje", "Ustawienia" };
            navBar.Dock = DockStyle.Fill;
            navBar.OnClick += NavBar_OnClick;
            navBar.initialize();            
            this.versionTopBarContainer.Controls.Add(navBar);

            this.table1.bundle.column.addMultiple(this.Columns);

            this.tunnel.start();
        }

        private void NavBar_OnClick(object sender, component.custom.NavigationBar.events.NavigationBarLinkClickEvent e)
        {
            switch(e.getLinkName())
            {
                case "Ustawienia":
                    this.settingsView?.ShowDialog();
                    break;
            }
        }

        private void Item_OnLogin(object sender, components.events.StationItemActionEvent e)
        {
            this.authView.ShowDialog();
        }
    }
}
