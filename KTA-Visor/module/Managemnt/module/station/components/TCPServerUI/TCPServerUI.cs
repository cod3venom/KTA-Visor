using Logger.dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.components.TCPServerUI
{
    public partial class TCPServerUI : UserControl
    {
        public event EventHandler<TCPTunnel.module.client.events.TCPClientConnectedEvent> OnClientConnected;

        public event EventHandler<EventArgs> OnClientDisconnected;


        public TCPServerUI()
        {
            InitializeComponent();
        }

    }
}
