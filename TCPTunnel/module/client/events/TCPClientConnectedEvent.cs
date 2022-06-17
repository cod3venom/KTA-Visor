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
        private readonly TCPClientTObject client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public TCPClientConnectedEvent(TCPClientTObject client)
        {
            this.client = client;
        }

        public TCPClientTObject getClient() => this.client;
    }
}
