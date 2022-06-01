using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_TCPBridge.BridgeServer.dto
{
    public class ServerConfigTObject
    {
        public string serverName = "";
        public string ipAddress = "";
        public int port = 1337;
        public int listenInterval = 10;

        public ServerConfigTObject(
            string serverName = "",
            string ipAddress = "",
            int port = 0,
            int listenInterval = 10
        )
        {
            this.serverName = serverName;
            this.ipAddress = ipAddress;
            this.port = port;
            this.listenInterval = listenInterval;  
        }
    }
}
