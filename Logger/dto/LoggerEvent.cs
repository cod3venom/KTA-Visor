using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.dto
{
    public class LoggerEvent:EventArgs
    {
        public LoggerEvent(string type = "", string log = "", string message = "")
        {
            this.Type = type;
            this.Log = log;
            this.Message = message;
        }

        public string Type { get; set; }
        public string Log { get; set; }
        public string Message { get; set; }
    }
}
