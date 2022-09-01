using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto
{
    public class USBRelayPortsToObject
    {
        public Port port1 = new Port();
        public Port port2 = new Port();
        public Port port3 = new Port();
        public Port port4 = new Port();
        public Port port5 = new Port();
        public Port port6 = new Port();
        public Port port7 = new Port();
        public Port port8 = new Port();


        public Port findByPortNumber(int number)
        {
            switch(number)
            {
                case 1: return this.port1;
                case 2: return this.port2;
                case 3: return this.port3;
                case 4: return this.port4;
                case 5: return this.port5;
                case 6: return this.port6;
                case 7: return this.port7;
                case 8: return this.port8;

                default:
                    return new Port();
            }
        }
        public class Port
        {
            public Port()
            {
                this.Name = "Port ~";
                this.PortNumber = -1;
                this.Status = 0;
            }

            public Port(int portNumber, int status)
            {
                this.Name = "Port " + portNumber;
                this.PortNumber = portNumber;
                this.Status = status;
            }

            public string Name { get; set; }
            public int PortNumber { get; set; }
            public int Status { get; set; }
        }
    }
}
