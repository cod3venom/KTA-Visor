
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

        public TCPBridge getBridge()
        {
            return this.bridge;
        }

        public KTAServer setBridge(TCPBridge bridge)
        {
            this.bridge = bridge;

            return this;
        }
    }
}