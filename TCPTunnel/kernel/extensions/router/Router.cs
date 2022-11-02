using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;

namespace TCPTunnel.kernel.extensions.router
{
    public class Router
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly KTALogger.Logger logger;

        /// <summary>
        /// 
        /// </summary>
        private Request currentRequest;
        
        /// <summary>
        /// 
        /// </summary>
        public Router()
        {
            this.logger = new KTALogger.Logger();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Request ParseRoute(TCPClientTObject client, string message)
        {
            try
            {
                this.logger.hidden("Received plain message: " + message);
                message = message.Replace("\r\n", "\n");
                message = message.Replace("\n", "");

                this.currentRequest = JsonConvert.DeserializeObject<Request>(message);
                if (this.currentRequest != null)
                {
                    this.currentRequest.Client = client;
                }
                
                return this.currentRequest;
            }
            catch (Exception ex)
            {
                this.logger.error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetParams()
        {
            return this.currentRequest.Endpoint.Replace("/", "").Split('@');
        }
    }
}
