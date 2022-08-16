using KTA_Visor.module.Station.components.StationItem.events;
using KTA_Visor.module.Management.station;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Station.components.StationItem
{
    public partial class StationItem : UserControl
    {
        public event EventHandler<StationItemClickEvent> OnClick;

        public StationItem()
        {
            InitializeComponent();
        }

        public StationItem(StationTObject station)
        {
            InitializeComponent();
            this.Station = station;
            this.ID = station.ID;
            this.Name = station.Name;
            this.IpAddress = station.Client.getIpAddress();
            this.openBtn.Click += onOpen;
            
        }

        private void onOpen(object sender, EventArgs e)
        {
           this.OnClick?.Invoke(sender, new StationItemClickEvent(this));
        }

        private void StationItem_Load(object sender, EventArgs e)
        {

        }

        public StationTObject Station { get; set; }

        public int ID { get; set; }

        public string Name
        {
            get { return this.stationNameLbl.Text; }
            set { this.stationNameLbl.Text = value; }
        }

        public string IpAddress
        {
            get { return this.ipAddressLbl.Text; }
            set { this.ipAddressLbl.Text = value; }
        }
    }
}
