using KTA_Visor.module.Station.components.ClientsList.components.ClientItem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Station.components.ClientsList
{
    public partial class ClientsList : UserControl
    {
        public ClientsList()
        {
            InitializeComponent();
        }

        private void ClientsList_Load(object sender, EventArgs e)
        {

        }

        public bool exists(string ipAddress)
        {
            foreach(ClientItem item in this.clientsListPanel.Controls)
            {
                if (item.IpAddress != ipAddress) continue;
                return true;
            }

            return false;
        }

        public void add(ClientItem clientItem)
        {
            if (this.exists(clientItem.IpAddress)) return;
            clientItem.Dock = DockStyle.Top;
            this.clientsListPanel.Controls.Add(clientItem);
        }

        public void remove(ClientItem clientItem)
        {
            if (!this.exists(clientItem.IpAddress)) return;
            this.clientsListPanel.Controls.Remove(clientItem);
        }

    }
}
