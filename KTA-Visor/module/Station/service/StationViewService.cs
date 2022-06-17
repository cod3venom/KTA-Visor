﻿using KTA_Visor.module.Station.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Station.service
{
    public class StationViewService
    {
        private readonly StationsView stationView;

        public StationViewService(StationsView stationView)
        {
            this.stationView = stationView;
        }

        public void onAuthenticate(Request request)
        {
            Console.WriteLine("OnAUth: " + request.Body.ToString());
            request.Body = "Thanks";
            request.Client.Send(request);
        }
    }
}
