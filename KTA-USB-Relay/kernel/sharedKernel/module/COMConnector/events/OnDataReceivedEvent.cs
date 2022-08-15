using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.COMConnector.events
{
    public class OnDataReceivedEvent : EventArgs
    {
        public OnDataReceivedEvent(SerialPort serialPort)
        {
            this.SerialPort = serialPort;
            this.Message = serialPort.ReadLine();
        }

        public SerialPort SerialPort { get; set; }
        public string Message { get; set; }
    }
}
