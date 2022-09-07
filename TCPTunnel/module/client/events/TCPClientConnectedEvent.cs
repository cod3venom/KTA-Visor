using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace TCPTunnel.module.client.events
{
    public class TCPClientConnectedEvent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TCPClientConnectedEvent(TCPClientTObject client)
        {
            this.Client = client;
        }

        public TCPClientTObject getClient() => this.Client;

        public TCPClientTObject Client { get; private set; }
    }
}
