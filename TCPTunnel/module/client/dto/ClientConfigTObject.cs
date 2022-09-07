using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.shared.entity;

namespace TCPTunnel.module.client.dto
{
    public class ClientConfigTObject
    {
        public ClientConfigTObject(string ipAddress = "", int port = 0, AuthData authData = null)
        {
            this.IpAddress = ipAddress;
            this.Port = port;
            this.AuthData = authData;
        }


        public string IpAddress
        { get; set; }

        public int Port
        { get; set; }

        public AuthData AuthData { get; set; }
    }
}
