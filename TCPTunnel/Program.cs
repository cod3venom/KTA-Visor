using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.server;
using TCPTunnel.module.server.dto;

namespace TCPTunnel
{
    public class TCPTunnel
    {

        public TCPTunnel()
        {

        }

        public Server createServer(ServerConfigTObject config)
        {
            return new Server(config);
        }
    }
}
