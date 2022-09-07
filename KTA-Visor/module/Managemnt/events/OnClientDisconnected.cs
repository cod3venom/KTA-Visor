using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.events
{
    public class OnClientConnected: EventArgs
    {
        public OnClientConnected(TCPClientTObject client)
        {
            this.Client = client;
        }
        public TCPClientTObject Client { get; private set; }
    }
}
