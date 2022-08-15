
using KTA_USB_Relay.kernel.sharedKernel.module.COMConnector;
using KTA_USB_Relay.kernel.sharedKernel.module.commander;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay
{
    public class Relay 
    {

        private readonly COMConnector connector;

        private readonly RelayDevice device;

        public Relay(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBit)
        {
            this.connector = new COMConnector(portName, baudRate, parity, dataBits, stopBit);
            this.device = new RelayDevice(connector);
        }

        public RelayDevice Device => this.device;
 
    }
}
