using KTA_TCPBridge.BridgeServer.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using KTA_TCPBridge.BridgeServer;

namespace KTA_TCPBridge
{
    public class TCPBridge : AbstractResource
    {

        public TCPBridge(ServerConfigTObject serverConfig) : base(serverConfig)
        {

        }
    }
}
