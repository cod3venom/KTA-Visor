using KTA_TCPBridge.BridgeServer.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.components.ClientsList.components.ClientItem
{
    public partial class ClientItem : UserControl
    {
        public ClientItem()
        {
            InitializeComponent();
        }

        public ClientItem(TCPClientTObject client)
        {
            InitializeComponent();
            this.Client = client;
            this.IpAddress = client.getIpAddress();
        }

        private void ClientItem_Load(object sender, EventArgs e)
        {

        }

        public TCPClientTObject Client
        { get; set; }

        public string IpAddress 
        {
            get { return this.ipLbl.Text; }
            set { this.ipLbl.Text = value; }
        }
    }
}
