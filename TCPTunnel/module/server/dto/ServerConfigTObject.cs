﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.module.server.dto
{
    public class ServerConfigTObject
    {
        public string serverName = "";
        public string ipAddress = "";
        public int port = 1337;
        public int listenInterval = 1000;

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
