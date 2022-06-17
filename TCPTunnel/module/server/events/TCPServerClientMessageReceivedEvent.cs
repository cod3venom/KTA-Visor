using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.module.server.events
{
    public class TCPServerClientMessageReceivedEvent : EventArgs
    {
        private readonly Request route;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="route"></param>
        public TCPServerClientMessageReceivedEvent(Request route)
        {
            this.route = route;
        }

        public Request getRoute() => this.route;
    }
}
