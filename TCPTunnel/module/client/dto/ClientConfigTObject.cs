using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.module.client.dto
{
    public class ClientConfigTObject
    {
        public ClientConfigTObject(string ipAddress = "", int port = 0)
        {
            this.IpAddress = ipAddress;
            this.Port = port;
        }


        public string IpAddress
        { get; set; }

        public int Port
        { get; set; }
    }
}
