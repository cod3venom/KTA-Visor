using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace TCPTunnel.module.shared.events
{
    public class OnAuthCommandReceived
    {
        public OnAuthCommandReceived(TCPClientTObject client, Request request)
        {
            this.Client = client;
            this.Request = request;
        }

        public TCPClientTObject Client { get; set; }
        public Request Request { get; set; }
    }
}
