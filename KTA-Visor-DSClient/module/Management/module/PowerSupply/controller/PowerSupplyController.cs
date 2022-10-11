using KTA_Visor_DSClient.module.Management.module.PowerSupply.service;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.controller
{
    internal class PowerSupplyController
    {
        private readonly PowerSupplyService powerSupplyService;
       
        public PowerSupplyController()
        {
            this.powerSupplyService = new PowerSupplyService();
        }

        public void Watch(Request request)
        {
            switch (request.Endpoint)
            {
                case "command://power-supply/off":
                    this.turnOffPowerSupply(request);
                    break;

                case "command://power-supply/restart":
                    this.restartPowerSupply(request);
                    break;


              
            }
        }

        private void turnOffPowerSupply(Request request)
        {
            this.powerSupplyService.TurnOff();
        }

        private void restartPowerSupply(Request request)
        {
            this.powerSupplyService.Restart();
        }
 

    }
}
