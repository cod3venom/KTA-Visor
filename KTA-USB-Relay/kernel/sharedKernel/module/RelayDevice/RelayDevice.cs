using KTA_USB_Relay.kernel.sharedKernel.module.commander.interfaces;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.resolver;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.syntax.turnOf;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.syntax.turnOn;
using KTA_USB_Relay.kernel.sharedKernel.flags;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.command;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.enums;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;


namespace KTA_USB_Relay.kernel.sharedKernel.module.commander
{
    public class RelayDevice : IRelayDevice
    {
        public static USBRelayPortsToObject USBRelayDeviceStatusList = new USBRelayPortsToObject();
        public event EventHandler<EventArgs> OnSuccessFullyConnected;
        public event EventHandler<EventArgs> OnUnableToConnect;
        public event EventHandler<EventArgs> OnTurnedOnAll;
        public event EventHandler<EventArgs> OnTurnedOffAll;
        public event EventHandler<EventArgs> OnTurnedOnSingle;
        public event EventHandler<EventArgs> OnTurnedOffSingle;
        public event EventHandler<OnReceivedPortStatusEvent> OnReceivedPortStatusEvent;

        public COMConnector.COMConnector connector;
        public List<int> Ports = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        public RelayDevice(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBit, KTALogger.Logger logger)
        {
            this.connector = new COMConnector.COMConnector(portName, baudRate, parity, dataBits, stopBit, logger);
        }

        public void Open()
        {
            try
            {
                this.connector.OnDataReceived += OnReceivedMessageFromRelayDevice;
                this.connector.connect();
                this.OnSuccessFullyConnected?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                this.OnUnableToConnect?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Close()
        {
            this.connector.OnDataReceived -= OnReceivedMessageFromRelayDevice;
            this.connector.disconnect();
        }

        public void Reconnect()
        {
            this.connector.reconnect();
        }

        private void OnReceivedMessageFromRelayDevice(object sender, COMConnector.events.OnDataReceivedEvent e)
        {
            Console.WriteLine(String.Format("Received message from USBRelay: {0}", e.Message));

            if (e.Message == "") return;

            if (ParsePowerStatusCommand.Execute(e.Message, ref RelayDevice.USBRelayDeviceStatusList) == true)
            {
                this.OnReceivedPortStatusEvent?.Invoke(sender, new OnReceivedPortStatusEvent(USBRelayDeviceStatusList));
            }
        }

        public void isTurnedOn(int portNumber, int transition = 1000)
        {
            this.sendCommand("L " + portNumber.ToString(), false);
            Thread.Sleep(transition);
        }

        public void getAllStatuses(int transition = 100)
        {
            foreach (int port in this.Ports)
            {
                this.sendCommand(String.Format("L {0}", port.ToString()));
                Thread.Sleep(transition);
            }
        }

        public void turnOnAll(int transition = 1000)
        {
            foreach (int port in this.Ports)
            {
                this.sendCommand(String.Format("C {0}", port.ToString()));
                Console.WriteLine(string.Format("Turned ON Port {0}", port.ToString()));

                Thread.Sleep(transition);
            }
            this.OnTurnedOnAll?.Invoke(this, EventArgs.Empty);
        }
        
        public void turnOffAll(int transition = 1000)
        {
            foreach(int port in this.Ports)
            {
                this.sendCommand(String.Format("S {0}", port.ToString()));
                Thread.Sleep(transition);
            }

            this.OnTurnedOffAll?.Invoke(this, EventArgs.Empty);
        }

        public void turnOnByPort(int portNumber, int transition = 1000)
        {
            this.sendCommand(String.Format("C {0}", portNumber.ToString()));
            Thread.Sleep(transition);

            this.OnTurnedOnSingle?.Invoke(this, EventArgs.Empty);

        }

        public void turnOffByPort(int portNumber, int transition = 1000)
        {
            this.sendCommand(String.Format("S {0}", portNumber.ToString()));
            Thread.Sleep(transition);

            this.OnTurnedOffSingle?.Invoke(this, EventArgs.Empty);
        }

        public void restartAll()
        {
            this.turnOffAll();
            Thread.Sleep(5000);
            this.turnOnAll();
        }

        public void restartSingle(int portNumber)
        {
            this.turnOffByPort(portNumber);
            Thread.Sleep(5000);
            this.turnOnByPort(portNumber);
        }


        public void sendCommand(string command, bool withResolver = true)
        {
            if (!this.connector.isConnected)
            {
                Console.WriteLine("Unable to send message, because you are not connected to the USBRelay COM port");
                return;
            }

            if (withResolver)
            {
                if (!USBRelayCommandResolver.Resolve(command))
                    return;
            }

            this.connector.send(ASCIIKey.ESC.ToString());
            this.connector.send(command);
            this.connector.send(ASCIIKey.RETURN.ToString());
        }
    }
}
