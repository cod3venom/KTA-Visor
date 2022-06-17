using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.kernel.extensions.router.events
{
    public class RouteControllerEvent : EventArgs
    {
        private readonly Request route;
        private readonly string callBackFunction;

        public RouteControllerEvent(Request route, string callBackFunction)
        {
            this.route = route;
            this.callBackFunction = callBackFunction;
        }

        public Request Route
        {
            get { return this.route; }
        }

        public string CallBackFunction
        {
            get { return this.callBackFunction;}
        }


    }
}
