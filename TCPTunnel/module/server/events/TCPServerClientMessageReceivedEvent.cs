using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.server.extensions.router.dto;
using TCPTunnel.module.server.types;

namespace TCPTunnel.module.server.events
{
    public class TCPServerClientMessageReceivedEvent : EventArgs
    {
        private readonly RouteTObject route;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="route"></param>
        public TCPServerClientMessageReceivedEvent(RouteTObject route)
        {
            this.route = route;
        }

        public RouteTObject getRoute() => this.route;
    }
}
