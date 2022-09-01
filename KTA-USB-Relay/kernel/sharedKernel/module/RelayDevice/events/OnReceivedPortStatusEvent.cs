using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events
{
    public class OnReceivedPortStatusEvent
    {
        public OnReceivedPortStatusEvent(USBRelayPortsToObject ports)
        {
            this.Ports = ports;
        }

        public USBRelayPortsToObject Ports { get; set; }
 
    }
}
