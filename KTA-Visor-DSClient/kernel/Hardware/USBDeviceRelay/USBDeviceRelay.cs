using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay
{
    public class USBDeviceRelay
    {
        public KTA_USB_Relay.Relay USBRelay;

        public USBDeviceRelay()
        {
            this.USBRelay = new KTA_USB_Relay.Relay("COM5", 9200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
        }

    }
}
