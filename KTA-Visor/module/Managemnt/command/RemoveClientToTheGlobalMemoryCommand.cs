using KTA_Visor.module.Shared.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.command
{
    public class AddClientToTheGlobalMemoryCommand
    {
        public static bool Execute(TCPClientTObject client)
        {
            if (Globals.CLIENTS_LIST.Contains(client))
                return false;
            
            Globals.CLIENTS_LIST.Add(client);
            return true;
        }
    }
}
