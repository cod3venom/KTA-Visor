using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.server.extensions.router.dto;
using TCPTunnel.module.server.types;

namespace TCPTunnel.module.server.extensions.messenger
{
    public class Router
    {
        public RouteTObject ParseRoute(string message)
        {
            try
            {
                RouteTObject route = JsonConvert.DeserializeObject<RouteTObject>(message);

                return route;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
