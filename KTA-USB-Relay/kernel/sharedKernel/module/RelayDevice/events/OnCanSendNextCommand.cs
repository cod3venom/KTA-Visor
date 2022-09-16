using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events
{
    public class OnCanSendNextCommand
    {
        public OnCanSendNextCommand(bool canSendNext)
        {
            this.CanSendNext = canSendNext;
        }

        public bool CanSendNext{ get; set; }
 
    }
}
