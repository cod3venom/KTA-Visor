using KTA_Visor.module.Managemnt.server;
using KTA_Visor.module.Managemnt.workers.tunnel;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Shared.Global
{
    public class Globals
    {

        public static KTALogger.Logger Logger = new KTALogger.Logger();

        public static string READED_CARD_INPUT = "";
        public static bool IS_SERVER_ONLINE = false;
        public static ServerTunnel Server;

        
    }
}
