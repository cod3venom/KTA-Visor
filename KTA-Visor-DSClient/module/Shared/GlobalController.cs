using KTA_Visor_DSClient.module.Management.module.Camera.controller;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
using KTA_Visor_DSClient.module.Management.module.PowerSupply.controller;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Shared
{
    public class GlobalController
    {
        private string CAMERAS_SCHEMA = "command://cameras";
        private string STATIONS_SCHEMA = "command://stations";
        private string POWER_SUPPLY_SCHEMA = "command://power-supply";

        private readonly ClientTunnel client;
        private readonly CameraController cameraController;
        private readonly PowerSupplyController powerSupplyController;
        public GlobalController(ClientTunnel client)
        {
            this.client = client;
            this.cameraController = new CameraController();
            this.powerSupplyController = new PowerSupplyController();
        }

        
        public void Watch(Request request)
        {
            if (request == null) {
                return;
            }

            if (request.Endpoint.Contains(this.CAMERAS_SCHEMA) ) {
                this.cameraController.Watch(request);
                return;
            }

            if (request.Endpoint.Contains(this.STATIONS_SCHEMA))
            {
                 
                return;
            }

            if (request.Endpoint.Contains(this.POWER_SUPPLY_SCHEMA))
            {
                this.powerSupplyController.Watch(request);
                return;
            }

        }
    }
}
