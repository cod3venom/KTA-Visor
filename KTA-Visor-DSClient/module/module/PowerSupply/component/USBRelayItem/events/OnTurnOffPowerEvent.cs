using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem.events
{
    public class OnTurnOffPowerEvent: EventArgs
    {
        public OnTurnOffPowerEvent(string portNumber)
        {
            this.PortNumber = portNumber;
            this.Command = "C " + portNumber;
        }

        public string PortNumber { get; set; }  
        public string Command { get; set; }
    }
}
