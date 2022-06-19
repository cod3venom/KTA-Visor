using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPTunnel.kernel.helpers
{
    public class JSON
    {
        public static string ArrayTOJsonString(Dictionary<string, object> items)
        {
            string json = "";

            foreach(KeyValuePair<string, object> item in items)
            {
                 
                json += String.Format("\"{0}\": \"{1}\",", item.Key, item.Value);
            }

            
            json = "'{" + json.Remove(json.Length - 1) + "}'";

            return json;
        }
    }
}
