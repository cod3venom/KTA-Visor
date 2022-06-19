using KTA_Visor.module.Station.service;
using KTA_Visor.module.Station.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.extensions.router.events;

namespace KTA_Visor.module.Station.controller
{
    public class StationController
    {

        private readonly StationsView stationView;

        private readonly StationViewService stationViewService;


        public StationController(StationsView stationView, StationViewService stationViewService)
        {
            this.stationView = stationView;
            this.stationViewService = stationViewService;
        }

        public  void StartWatching(Request request)
        {
            switch (request.Endpoint)
            {
                case "/authenticate": this.onAuthenticate(request); break;
                case "/re-authenticate": this.onAuthenticate(request); break;

                case "/logout": this.onLogout(request); break;

                default:
                    return;
            }
        }
 

        private void onAuthenticate(Request request)
        {
            this.stationViewService.onAuthenticate(request);
        }

        private void onLogout(Request route)
        {
          
        }
    }
}
