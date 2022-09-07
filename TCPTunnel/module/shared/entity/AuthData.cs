using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.module.shared.entity
{
    public class AuthData
    {
        public AuthData()
        {
            this.AdditionalData = new Dictionary<string, dynamic>();
        }

        public string Identificator { get; set; }

        public Dictionary<string, dynamic> AdditionalData { get; set; }
        
    }
}
