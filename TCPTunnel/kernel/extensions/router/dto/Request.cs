using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.helpers;
using TCPTunnel.kernel.types;

namespace TCPTunnel.kernel.extensions.router.dto
{
    public class Request
    {

        private string _endpoint = "";
        private dynamic _body = "";
        private dynamic _parameters = new string[] { };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="body"></param>
        public Request(string endpoint = "", dynamic body = null, TCPClientTObject client = null)
        {
            this._endpoint = endpoint;
            this._body = body;
            this.Client = client;
            if (this._endpoint.Contains("@"))
            {
                this._parameters = endpoint.Replace("/", "").Split('@');
            }
        }

        public TCPClientTObject Client { get; set; }
        
        public string Endpoint 
        {
            get { return this._endpoint == null ? "" : this._endpoint;  }
            set { this._endpoint = value; } 
        }

        public dynamic Body
        { 
            get { return this._body == null ? "" : this._body; }
            set { this._body = value; }
        }

        public dynamic[] Parameters 
        { 
            get { return this._parameters; }
            set { this._parameters = value; }
        }

        public string toJson()
        {
            dynamic schema = new ExpandoObject();
            schema.endpoint = this.Endpoint;
            schema.body = this.Body;
            schema.targetIp = this.Client?.IpAddress;

            string js = JsonConvert.SerializeObject(schema, Formatting.Indented);
            return js;
        }

        
    }
}
