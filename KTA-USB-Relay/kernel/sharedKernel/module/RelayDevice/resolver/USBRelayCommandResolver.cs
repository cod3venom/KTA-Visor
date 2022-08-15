using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.syntax.turnOf;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.syntax.turnOn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.resolver
{
    internal class USBRelayCommandResolver
    {
        public static bool Resolve(string command)
        {
            switch (command)
            {
                case TurnON.P1:
                case TurnON.P2:
                case TurnON.P3:
                case TurnON.P4:
                case TurnON.P5:
                case TurnON.P6:
                case TurnON.P7:
                case TurnON.P8:

                case TurnOff.P1:
                case TurnOff.P2:
                case TurnOff.P3:
                case TurnOff.P4:
                case TurnOff.P5:
                case TurnOff.P6:
                case TurnOff.P7:
                case TurnOff.P8:


                    return true;

                default:
                    return false;
            }
        }
    }
}
