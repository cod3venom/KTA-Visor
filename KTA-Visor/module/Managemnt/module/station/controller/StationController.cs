using KTA_Visor.module.Managemnt.module.camera.form;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem;
using KTA_Visor.module.Managemnt.module.Camera.component.CameraItem.events;
using KTA_Visor.module.Managemnt.module.station.command;
using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.station.controller
{
    public class StationController
    {
        private readonly StationViewPanel panel;
        private readonly StationService stationService;

        public StationController(StationViewPanel panel)
        {
            this.panel = panel;
            this.stationService = new StationService();
        }

 
        
        public void Watch(Request request)
        {
             switch (request.Endpoint)
            {
                case "response://cameras/all":
                    this.displayCamerasOfSelectedStationCommand(request.Body);
                    break;
            }
        }


        private void displayCamerasOfSelectedStationCommand(dynamic response)
        {
            DisplayCamerasOfSelectedStationCommand.Execute(this.panel.camerasFlowPanel, response);
        }

    }
}
