using KTA_Visor_UI.component.custom.ClientsList.events;
using KTA_Visor_UI.component.custom.ClientsList.sub_components.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.ClientsList
{
    public partial class ClientsList : UserControl
    {
        public event EventHandler<OnClientConnected> OnClientConnected;
        public event EventHandler<OnClientDisconnected> OnClientDisconnected;
        private List<ClientItem> clients;
        public ClientsList()
        {
            InitializeComponent();
            this.clients = new List<ClientItem>();
        }

        private void ClientsList_Load(object sender, EventArgs e)
        {
            this.refreshBtn.Click += onRefresh;
        }

        public string Title
        {
            set { this.titleLbl.Text = value; }
            get { return this.titleLbl.Text; }   
        }

        public string TotalConnectionsText
        {
            set { this.totalTextLbl.Text = value; }
            get { return this.totalTextLbl.Text; }
        }

        public string TotalConnectionsNumber
        {
            set { this.totalLbl.Text = value; }
            get { return this.totalLbl.Text; }
        }


        private void onRefresh(object sender, EventArgs e)
        {
            List<ClientItem> connectedClients = new List<ClientItem>();
           foreach (ClientItem item in clients)
            {
                if (item.Client.Connected)
                {
                    connectedClients.Add(item);
                }
            }

            this.clients = connectedClients;
            this.updateUI();
        }

        public void Add(Socket client)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (!client.RemoteEndPoint.ToString().Contains(':')){
                    return;
                }
                
                string ipAddress = client.RemoteEndPoint.ToString().Split(':')[0];
                ClientItem item = this.clients.Find((ClientItem _item) => _item.IpAddress == ipAddress);
                if (item == null)
                {
                    item = new ClientItem(client);
                }

                if (this.clients.Contains(item)) {
                    this.clients.Remove(item);
                }

                this.clients.Add(item);
                this.OnClientConnected?.Invoke(this, new events.OnClientConnected(client));
                this.updateUI();
                Application.DoEvents();
            });
        }

        public void Remove(Socket client)
        {
            this.Invoke((MethodInvoker)delegate
            {
                ClientItem item = this.clients.Find((ClientItem _item) => _item.Client == client);
                this.clients.Remove(item);
                this.OnClientDisconnected?.Invoke(this, new events.OnClientDisconnected(client));
                this.updateUI();
            });

        }

        private void updateUI()
        {
            Thread uiThread = new Thread((ThreadStart)delegate
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.contentPanel.Controls.Clear();

                    foreach (ClientItem item in clients)
                    {
                       // item.Dock = DockStyle.Top;
                        this.contentPanel.Controls.Add(item);
                    }

                    this.totalLbl.Text = this.clients.Count.ToString();
                });
            });
            uiThread.IsBackground = true;
            uiThread.Start();
        }
    }
}
