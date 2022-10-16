﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.ClientsList.sub_components.Client
{
    public partial class ClientItem : UserControl
    {
        public ClientItem()
        {
            InitializeComponent();
        }

        public ClientItem(Socket client)
        {
            this.Client = client;
            InitializeComponent();
        }
        private void ClientItem_Load(object sender, EventArgs e)
        {

            this.Dock = DockStyle.Top;
            if (this.Client != null)
            {
                this.Title = this.Client.RemoteEndPoint.ToString();
                this.Online = this.Client.Connected;
            }
        }

        public Socket Client{get; set;}

        public string Title
        {
            set { this.titleLbl.Text = value; }
            get { return this.titleLbl.Text; }
        }

        public string IpAddress
        {
            get
            {
                if (this.Client.RemoteEndPoint.ToString().Contains(':'))
                {
                    return this.Client.RemoteEndPoint.ToString().Split(':')[0].ToString();
                }
                return "";
            }
        }
        public bool Online
        {
            set
            {
                if (value == true)
                {
                    this.statusPic.Image = Properties.Resources.green_circle;
                } else
                {
                    this.statusPic.Image = Properties.Resources.red_circle;
                }
            }
            get
            {
                if (this.statusPic.Image == Properties.Resources.green_circle)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
