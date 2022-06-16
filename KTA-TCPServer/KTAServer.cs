
using KTA_TCPBridge.BridgeServer.dto;

namespace KTA_TCPBridge
{
    public class KTAServer
    {
        private TCPBridge  bridge;

        public KTAServer(ServerConfigTObject serverConfig)
        {
            this.bridge = new TCPBridge(serverConfig);
        }

        public TCPBridge Bridge
        {
            get { return this.bridge; }
        }
 
    }
}