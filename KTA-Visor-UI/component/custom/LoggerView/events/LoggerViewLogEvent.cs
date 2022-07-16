using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.custom.LoggerView.events
{
    public class LoggerViewLogEvent: EventArgs
    {
        
        public LoggerViewLogEvent(string log)
        {
            this.Log = log;
        }

        public string Log { get; set; }
    }
}
