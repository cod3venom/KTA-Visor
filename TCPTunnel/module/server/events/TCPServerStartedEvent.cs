using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.server.dto;

namespace TCPTunnel.module.server.events
{
    public class TCPServerStartedEvent:EventArgs
    {
        public TCPServerStartedEvent(ServerConfigTObject config)
        {
            this.Config = config;
        }

        public ServerConfigTObject Config { get; set; }
    }
}
