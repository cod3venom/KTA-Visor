using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.server.types;

namespace TCPTunnel.module.server.events
{
    public class TCPServerClientConnectedEvent : EventArgs
    {
        private readonly TCPClientTObject client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TCPServerClientConnectedEvent(TCPClientTObject client)
        {
            this.client = client;
        }

        public TCPClientTObject getClient() => this.client;
    }
}
