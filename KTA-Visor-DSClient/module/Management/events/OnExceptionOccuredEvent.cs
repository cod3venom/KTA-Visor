using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.events
{
    public class OnExceptionOccuredEvent: EventArgs
    {

        public OnExceptionOccuredEvent(Exception ex)
        {
            this.Exception = ex;
        }

        public Exception Exception { get; set; }
    }
}
