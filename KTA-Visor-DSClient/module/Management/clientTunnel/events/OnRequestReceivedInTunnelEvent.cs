using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.clientTunnel.events
{
    public class OnRequestReceivedInTunnelEvent
    {
        public OnRequestReceivedInTunnelEvent(Request request)
        {
            this.Request = request;
        }

        public Request Request { get; set; }
    }
}
