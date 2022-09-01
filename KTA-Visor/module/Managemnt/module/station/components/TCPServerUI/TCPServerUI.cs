using KTA_Visor.module.Management.tunnel;
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


        public Tunnel tunnel
        {
            get { return Program.Tunnel; }
        }
        private void TCPServerUI_Load(object sender, EventArgs e)
        {

            if (this.tunnel == null)
                return;
            this.tunnel.DebuggingPipe.OnLogHasWritten += OnLogReceivedInDebuggingPipe;
        }


        private void startListeningBTN_Click(object sender, EventArgs e)
        {
            this.tunnel.onServerStarted += Tunnel_onServerStarted;
            this.tunnel.start();
        }

        private void Tunnel_onServerStarted(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.serverStatuslbl.Text = "Status: Running";
            });
        }

        private void stopListeningBtn_Click(object sender, EventArgs e)
        {
            this.tunnel.onServerStopped += Tunnel_onServerStopped;
            this.tunnel.stop();
            
        }

        private void Tunnel_onServerStopped(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.serverStatuslbl.Text = "Status: Stopped";
            });
        }

        private void OnLogReceivedInDebuggingPipe(object sender, LoggerEvent e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.richTextBox.Select(0, e.Log.Length);
                switch (e.Type)
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
    }
}
