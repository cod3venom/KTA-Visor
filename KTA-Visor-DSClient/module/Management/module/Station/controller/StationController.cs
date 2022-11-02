using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Station.controller
{
    public class StationController : IControllerInterface
    {
        private readonly StationService _stationService;
        public StationController()
        {
            this._stationService = new StationService();
        }

        public void Watch(Request request)
        {
            switch(request.Endpoint)
            {
                case "command://power-supply/restart":
                    this.onRestartPowerSupply();
                    break;


                case "command://tunnel/disconnect":
                    this.onDisconnectTunnelConnection();
                    break;

                case "command://tunnel/restart":
                    this.onRestartTunnelConnection();
                    break;


                case "command://station/delete":
                    this.onDelete();
                    break;
            }
        }

        private void onRestartPowerSupply()
        {
            Globals.Relay.restartAll();
        }

        private void onDisconnectTunnelConnection()
        {
            Globals.ClientTunnel.Disconnect();
        } 
        
        private void onRestartTunnelConnection()
        {
            Globals.ClientTunnel.Restart();
        }

        private async void onDelete()
        {
            if (!Globals.IS_ALL_COPYING_PROCESS_ARE_END)
            {
                Globals.ClientTunnel.Emit(new Request("response://station/delete/still-copying"));
                return;
            }
            if (Globals.STATION?.data == null)
            {
                Program.Restart();
                return;
            }

            this._stationService.delete(Globals.STATION.data?.stationId);
            
            Globals.ClientTunnel.Disconnect();
            Program.Restart();
        }
    }
}
