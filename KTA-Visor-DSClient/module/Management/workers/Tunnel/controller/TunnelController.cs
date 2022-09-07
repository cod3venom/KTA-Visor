using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.client.events;

namespace KTA_Visor_DSClient.module.Management.workers.Tunnel.controller
{
    public class TunnelController
    {
        public event EventHandler<TCPEndpointReceivedEvent> OnEndpointReceived;

        public  TunnelController()
        {

        }

        public void Watch(Request request)
        {
            switch (request.Endpoint)
            {
                case "command://identify-your-self":
                case "command://show-active-devices":
                    this.OnEndpointReceived?.Invoke(this, new TCPEndpointReceivedEvent(request));
                    break;

            }
        }
    }
}
