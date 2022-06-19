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
        private readonly Request request;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public TCPServerClientMessageReceivedEvent(Request request)
        {
            this.request = request;
        }

        public Request getRoute()
        {
            return this.request == null ? new Request() : this.request;
        }
    }
}
