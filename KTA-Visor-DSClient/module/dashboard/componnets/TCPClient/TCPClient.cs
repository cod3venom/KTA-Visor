 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.dashboard.componnets.TCPClient
{
    public partial class TCPClient : UserControl
    {
        public event EventHandler<TCPTunnel.module.client.events.TCPClientConnectedEvent> OnClientConnected;

        public event EventHandler<EventArgs> OnClientDisconnected;

        private tunnel.Tunnel tunnel;
      

        public TCPClient()
        {
            InitializeComponent();
        }

        public TCPClient(tunnel.Tunnel tunnel)
        {
            this.tunnel = tunnel;
        }

        public tunnel.Tunnel Tunnel
        {
            get { return this.tunnel; }
            set { this.tunnel = value; }
        }
      
        private void TCPClient_Load(object sender, EventArgs e)
        {
            if (this.tunnel == null)
                return;
            this.tunnel.DebuggingPipe.OnLogHasWritten += OnLogReceivedInDebuggingPipe;
        }

        private void OnLogReceivedInDebuggingPipe(object sender, Logger.dto.LoggerEvent e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.richTextBox.Select(0, e.Log.Length);
                switch(e.Type)
                {
                    case "success": this.richTextBox.ForeColor = Color.DarkGreen; break;
                    case "info": this.richTextBox.ForeColor = Color.DarkBlue; break;
                    case "warn": this.richTextBox.ForeColor = Color.Yellow; break;
                    case "error": this.richTextBox.ForeColor = Color.DarkRed; break;

                }
                this.richTextBox.AppendText(e.Log + Environment.NewLine);
                Application.DoEvents();
            });
             
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            this.tunnel.onClientConnected += OnClientConnectedToTheTunnel;
            this.tunnel.connect();



            this.Invoke((MethodInvoker)delegate
            {
                this.connectBtn.Enabled = false;
                this.disconnectBtn.Enabled = true;
            });
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            this.tunnel.onClientDisconnected += OnClientDisconnectedFromTheTunnel;
            this.tunnel.disconnect();

            this.Invoke((MethodInvoker)delegate
            {
                this.connectBtn.Enabled = true;
                this.disconnectBtn.Enabled = false;
            });
        }

        

        private void OnClientConnectedToTheTunnel(object sender, TCPTunnel.module.client.events.TCPClientConnectedEvent e)
        {
            this.clientStatusLbl.Text = "Status: Connected";
            this.OnClientConnected?.Invoke(sender, e);
        }

        private void OnClientDisconnectedFromTheTunnel(object sender, EventArgs e)
        {
            this.clientStatusLbl.Text = "Status: Disconnected";
            this.OnClientDisconnected?.Invoke(sender, e);
        }

    }
}
