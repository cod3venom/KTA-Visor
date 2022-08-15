using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace KTA_USB_Relay
{
    public class Program
    {
        public static void Main()
        {
            Relay relay = new Relay("COM5", 19200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            relay.Device.Open();
            relay.Device.TurnOff1();

            Environment.Exit(-1);
        }
    }
}
