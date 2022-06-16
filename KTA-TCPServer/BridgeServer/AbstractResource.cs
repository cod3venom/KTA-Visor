using KTA_TCPBridge.BridgeServer.dto;
using KTA_TCPBridge.BridgeServer.Resource.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_TCPBridge.BridgeServer
{
    public abstract  class AbstractResource
    {
        private ServerConfigTObject serverConfig;

        private readonly TCPServer tcpServer;

        protected AbstractResource (ServerConfigTObject serverConfig)
        {
            this.serverConfig = serverConfig;
            this.tcpServer = new TCPServer(this.serverConfig);

        }

        public TCPServer TcpServer
        {
            get { return this.tcpServer; }
        }        
    }
}
