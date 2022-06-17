using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.module.client.events
{
    public class TCPClientDisconnectedEvent
    {
        private readonly Request request;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public TCPClientDisconnectedEvent(Request request)
        {
            this.request = request;
        }

        public Request getRoute() => this.request;
    }
}
