using KTA_USB_Relay.kernel.sharedKernel.module.commander.interfaces;
using KTA_USB_Relay.kernel.sharedKernel.module.COMConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.resolver;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.syntax.turnOf;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.syntax.turnOn;
using System.Threading;
using KTA_USB_Relay.kernel.sharedKernel.flags;

namespace KTA_USB_Relay.kernel.sharedKernel.module.commander
{
    public class RelayDevice : IRelayDevice
    {
        private readonly COMConnector.COMConnector connector;

        public RelayDevice(COMConnector.COMConnector connector)
        {
            this.connector = connector;
        }

        public void Open()
        {
            this.connector.OnDataReceived += OnReceivedMessageFromRelayDevice;
            this.connector.connect();
        }

        private void OnReceivedMessageFromRelayDevice(object sender, COMConnector.events.OnDataReceivedEvent e)
        {
            Console.WriteLine("USB RELAY RECEIVED > " + e.Message);
        }

        public void TurnOff1()
        {
            this.sendCommand(TurnOff.P1);
        }

        public void TurnOff2()
        {
            this.sendCommand(TurnOff.P2);
        }

        public void TurnOff3()
        {
            this.sendCommand(TurnOff.P3);
        }

        public void TurnOff4()
        {
            this.sendCommand(TurnOff.P4);
        }

        public void TurnOff5()
        {
            this.sendCommand(TurnOff.P5);
        }

        public void TurnOff6()
        {
            this.sendCommand(TurnOff.P6);
        }

        public void TurnOff7()
        {
            this.sendCommand(TurnOff.P7);
        }

        public void TurnOff8()
        {
            this.sendCommand(TurnOff.P1);
        }

        public void TurnOn1()
        {
            this.sendCommand(TurnON.P1);
        }

        public void TurnOn2()
        {
            this.sendCommand(TurnON.P2);
        }

        public void TurnOn3()
        {
            this.sendCommand(TurnON.P3);
        }

        public void TurnOn4()
        {
            this.sendCommand(TurnON.P4);
        }

        public void TurnOn5()
        {
            this.sendCommand(TurnON.P5);
        }

        public void TurnOn6()
        {
            this.sendCommand(TurnON.P6);
        }

        public void TurnOn7()
        {
            this.sendCommand(TurnON.P7);
        }

        public void TurnOn8()
        {
            this.sendCommand(TurnON.P8);
        }

        private void sendCommand(string command)
        {
            if (!USBRelayCommandResolver.Resolve(command))
                return;

            this.connector.send(ASCIIKey.ESC.ToString());
            this.connector.send(command);
            this.connector.send(ASCIIKey.RETURN.ToString());
        }
    }
}
