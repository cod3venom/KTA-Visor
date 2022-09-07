using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.client.events;

namespace KTA_Visor.module.Managemnt.workers.tunnel.controller
{
    public class TunnelController
    {
        public event EventHandler<TCPEndpointReceivedEvent> OnEndpointReceived;
        
        public void Watch(Request request)
        {
            switch (request.Endpoint)
            {
                case "response://identify-your-self":
                case "response://show-active-devices":
                    this.OnEndpointReceived?.Invoke(this, new TCPEndpointReceivedEvent(request));
                    break;
            }
        }
    }
}
