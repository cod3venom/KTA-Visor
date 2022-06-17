using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

namespace TCPTunnel.kernel.extensions.router.dto
{
    public class Request
    {

        private string _endpoint = "";
        private string _body = "";

        public TCPClientTObject Client { get; set; }
        
        public string Endpoint 
        {
            get { return this._endpoint;  }
            set { this._endpoint = value; } 
        }

        public string Body
        { 
            get { return this._body; }
            set { this._body = value; }
        }


        public string toJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
