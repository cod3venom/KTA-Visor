using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.custom.ClientsList.events
{
    public class OnClientConnected : EventArgs
    {
        public OnClientConnected(Socket socket)
        {
            this.Socket = socket;
        }

        public string IpAddress { get { return this.Socket.RemoteEndPoint.ToString().Split(':')[0].ToString(); } }
        public Socket Socket { get; set; }
    }
}
