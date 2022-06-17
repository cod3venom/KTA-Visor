using KTA_Visor.module.Station.service;
using KTA_Visor.module.Station.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.extensions.router.events;

namespace KTA_Visor.module.Station.controller
{
    public class StationController
    {
        public event EventHandler<RouteControllerEvent> OnRouteControllerInvoked;

        private readonly StationsView stationView;

        private readonly StationViewService stationViewService;
        public StationController(StationsView stationView)
        {
            this.stationView = stationView;
            this.stationViewService = new StationViewService(this.stationView);
        }

        public  void StartWatching(Request request)
        {
            switch (request.Endpoint)
            {
                case "/initializing": this.onInitializing(request); break;

                case "/authenticate": this.onAuthenticate(request); break;

                case "/logout": this.onLogout(request); break;
            }
        }

        private void onInitializing(Request request)
        {
            request.Endpoint = "/getinfo";
            request.Client.Send(request);
        }

        private void onAuthenticate(Request request)
        {
           this.stationViewService.onAuthenticate(request);
        }

        private void onLogout(Request route)
        {
            route.Endpoint = "/getinfo";
            route.Client.Send(route);
        }
    }
}
