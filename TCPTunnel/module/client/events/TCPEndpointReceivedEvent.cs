using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.module.client.events
{
    public class TCPEndpointReceivedEvent : EventArgs
    {
        public TCPEndpointReceivedEvent(Request request)
        {
            this.Request = request;
        }

         public Request Request { get; private set; }
    }
}
