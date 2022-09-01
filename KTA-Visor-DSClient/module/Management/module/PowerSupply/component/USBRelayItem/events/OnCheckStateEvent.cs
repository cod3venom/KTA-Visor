using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem.events
{
    public class OnCheckStateEvent : EventArgs
    {
        public OnCheckStateEvent(int portNumber, int status)
        {
            this.PortNumber = portNumber;
            this.Status = status;
        }

        public int PortNumber { get; set; }
        public int Status{ get; set; }
    }
}
