using KTA_Visor.module.Managemnt.module.station.view;
using KTA_Visor.module.Station.events;
using TCPTunnel.kernel.extensions.router.dto;
using System;

namespace KTA_Visor.module.Managemnt.module.station.controller
{
    public class StationController
    {
        private readonly StationView panel;

        public event EventHandler<OnRefreshCamerasListEvent> OnRefreshCamerasList;

        public StationController(StationView panel)
        {
            this.panel = panel;
        }

 
        
        public void Watch(Request request)
        {
        }
    }
}
