
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
    public class Relay : RelayDevice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBit"></param>
        public Relay(
            string portName,
            int baudRate,
            Parity parity, 
            int dataBits, 
            StopBits stopBit,
            KTALogger.Logger logger
        ): base(portName, baudRate, parity, dataBits, stopBit, logger)
        {}
 
    }
}
