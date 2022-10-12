using KTA_Visor.module.Managemnt.module.station.view.StationViewPanel;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.station.command
{
    public class HandleStationContextMenuClickEventCommand
    {
        public enum StationContextMenuItem
        {
            POWER_SUPPLY_OFF = 0,
            POWER_SUPPLY_RESTART = 1,

            TUNNEL_RESTART = 2,
            TUNNEL_DISCONNECT = 3,

            RDP_CONNECT = 4,
        }

        public static void Execute(object sender, EventArgs e,  StationViewPanel stationViewPanel, string stationId, int option)
        {
            var selectedOption = (StationContextMenuItem)option;
            
            
            switch(selectedOption.ToString())
            {
                case "POWER_SUPPLY_OFF":
                    handlePowerOff(stationId);
                    break;
                case "POWER_SUPPLY_RESTART":
                    handlePowerRestart(stationId);
                    break;


                case "TUNNEL_RESTART":
                    handleTunnelRstart(stationId);
                    break;


                case "TUNNEL_DISCONNECT":
                    handleTunnelDisconnect(stationId);
                    break;

                case "RDP_CONNECT":
                    handleRdpConnect(stationId);
                    break;
            }
        }

        private static async void handlePowerOff(string stationId)
        {
            StationEntity station = await GetStation(stationId);
            TCPClientTObject client = await GetClient(station.data.stationIp);

            if (client == null)
                return;

            client.Send(new Request(
                "command://power-supply/off",
                null,
                client
            ));
        }

        private static async void handlePowerRestart(string stationId)
        {
            StationEntity station = await GetStation(stationId);
            TCPClientTObject client = await GetClient(station.data.stationIp);

            if (client == null)
                return;

            client.Send(new Request(
               "command://power-supply/restart",
               null,
               client
           ));
        }

       
        private static void handleTunnelRstart(string stationId)
        {

        }

        private static void handleTunnelDisconnect(string stationId)
        {

        }

        private static void handleRdpConnect(string stationId)
        {

        }

        private static async Task<StationEntity> GetStation(string stationId)
        {
            return await new StationService().findByStationId(stationId);
        }

        private static async Task<TCPClientTObject> GetClient(string ipAddress)
        {
            return Globals.CLIENTS_LIST.Find((TCPClientTObject _client) => _client.getIpAddress() == ipAddress);
        }
    }
}
