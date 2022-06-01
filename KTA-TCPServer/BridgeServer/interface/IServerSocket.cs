using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_TCPBridge.BridgeServer.inteface
{
    public interface IServerSocket
    {
        public void initializeConfig();
        public void startServer();
        public void stopServer();
    }
}
