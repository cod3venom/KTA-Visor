using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.command
{
    public class ParsePowerStatusCommand
    {
        public class USBRelayDeviceStatusTObject
        {
            public USBRelayDeviceStatusTObject(int portId = -1, int status = 0)
            {
                this.portId = portId;
                this.status = status;
            }
            public int portId { get; set; }
            public int status { get; set; }
        }

        public static bool Execute(string message, ref USBRelayPortsToObject ports)
        {
            message = message.Trim();
            message = message.Replace("\n", "");
            message = message.Replace("\r", "");

            string newMsg = "";
            for (int i = 0; i < message.Length; i++)
            {
                newMsg += (message[i] + "@");
            }

            newMsg = Regex.Replace(newMsg, @"\s+", "");

            string[] segments = newMsg.Split('@');

            string prefix = "";
            string position = "";
            string status = "";
 

            if (segments.Length >= 3)
            {
                prefix = segments[0];
                position = segments[1];
                status = segments[2];
            }

            if (prefix == "" || position == "" || status == "")
                return false;

            if (prefix == "L")
            {
                int portIndex = Int32.Parse(position);
                int statusAsInt = Int32.Parse(status);

                switch(portIndex)
                {
                    case 1:
                        ports.port1 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;
                    case 2:
                        ports.port2 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;

                    case 3:
                        ports.port3 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;

                    case 4:
                        ports.port4 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;

                    case 5:
                        ports.port5 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;

                    case 6:
                        ports.port6 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;

                    case 7:
                        ports.port7 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;

                    case 8:
                        ports.port8 = new USBRelayPortsToObject.Port(portIndex, statusAsInt);
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }
    }
}
