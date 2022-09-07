using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace TCPTunnel.module.server.events
{

    public class TCPServerClientDisonnectedEvent : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TCPServerClientDisonnectedEvent(TCPClientTObject client)
        {
            this.Client = client;
        }

        public TCPClientTObject Client { get; private set; }
        public TCPClientTObject getClient() => this.Client;
    }
}
