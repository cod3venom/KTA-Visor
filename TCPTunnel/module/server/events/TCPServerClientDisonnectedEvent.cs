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
        private readonly TCPClientTObject client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TCPServerClientDisonnectedEvent(TCPClientTObject client)
        {
            this.client = client;
        }

        public TCPClientTObject getClient() => this.client;
    }
}
