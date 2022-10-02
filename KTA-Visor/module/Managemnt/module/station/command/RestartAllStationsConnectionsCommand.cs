using KTA_Visor.module.Shared.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.module.station.command
{
    public class RestartAllStationsConnectionsCommand
    {
        public static void Execute()
        {
           Globals.CLIENTS_LIST.ToList().ForEach(delegate (TCPClientTObject client)
           {
               client.Send(new TCPTunnel.kernel.extensions.router.dto.Request(
                    "command://client/connection/restart"     
               ));
           });
        }
    }
}
