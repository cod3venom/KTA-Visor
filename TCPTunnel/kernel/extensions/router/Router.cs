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
        private readonly KTALogger.Logger logger;

        public Router()
        {
            this.logger = new KTALogger.Logger();
        }

        public Request ParseRoute(TCPClientTObject client, string message)
        {
            try
            {
                this.logger.warn("Received plain message: " + message);
                message = message.Replace("\r\n", "\n");
                message = message.Replace("\n", "");
                message = message.Replace("\\", "");

                Request route = JsonConvert.DeserializeObject<Request>(message);

                this.logger.warn("Converted message to json: " + route.Body);

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
