using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace KTA_Visor.module.Managemnt.events
{
    public class OnMessageReceivedFromClient : EventArgs
    {
        public OnMessageReceivedFromClient(Request request)
        {
            this.Request = request;
        }
        public Request Request { get; private set; }
    }
}
