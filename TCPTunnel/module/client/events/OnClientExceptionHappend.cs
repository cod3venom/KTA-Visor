using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace TCPTunnel.module.client.events
{
    public class OnClientExceptionHappend
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public OnClientExceptionHappend(Exception ex)
        {
            this.Exception = ex;
        }

        public Exception Exception { get; set; }
    }
}
