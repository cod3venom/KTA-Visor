using KTA_Visor.module.Managemnt.events;
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
    public class AskForCamerasOfSelectedStationCommand
    {

        public static  void Execute(DataGridView table, DataGridViewCellEventArgs e)
        {

            string ipAddress = table?.Rows[e.RowIndex]?.Cells[1]?.Value?.ToString();
            TCPClientTObject client = Globals.CLIENTS_LIST.Find((TCPClientTObject _cl) => _cl.IpAddress == ipAddress);
            if (client == null)
                return;

            client.Send(new Request("command://cameras/all"));
        }
    }
}
