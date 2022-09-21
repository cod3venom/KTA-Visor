using System;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Station.events
{
    public class OnRefreshCamerasListEvent : EventArgs
    {

        public OnRefreshCamerasListEvent(Request request)
        {
            this.Request = request;
        }

        public Request Request{ get; set; }

        
    }
}
