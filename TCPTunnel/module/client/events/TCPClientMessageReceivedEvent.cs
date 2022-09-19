using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.module.client.events
{
    public class TCPClientMessageReceivedEvent
    {
        private readonly Request request;
 
        public TCPClientMessageReceivedEvent(Request request)
        {
            this.request = request;
        }

        public Request Request { get { return request; } }
        public Request getRoute()
        {
            return this.request;
        }
    }
}
