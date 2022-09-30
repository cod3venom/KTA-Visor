using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Station.events;
using TCPTunnel.kernel.extensions.router.dto;
using System;

namespace KTA_Visor.module.Managemnt.module.station.controller
{
    public class StationController
    {
        private readonly StationViewPanel panel;

        public event EventHandler<OnRefreshCamerasListEvent> OnRefreshCamerasList;

        public StationController(StationViewPanel panel)
        {
            this.panel = panel;
        }

 
        
        public void Watch(Request request)
        {
            switch (request.Endpoint)
            {
                case "response://cameras/refresh":
                    this.OnRefreshCamerasList(this, new OnRefreshCamerasListEvent(request));
                    return;
            }
        }
    }
}
