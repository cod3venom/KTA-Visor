using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace TCPTunnel.kernel.extensions.router
{
    public class Router
    {
        public Request ParseRoute(TCPClientTObject client, string message)
        {
            try
            {
                message = message.Replace("\r\n", "\n");
                message = message.Replace("\n", "");
                message = message.Replace("\\", "");
                Request route = JsonConvert.DeserializeObject<Request>(message);
                route.Client = client;
                client.Send(route);
                return route;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
