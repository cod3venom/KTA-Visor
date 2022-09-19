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
        public event EventHandler<OnReceivedPortStatusEvent> OnReceivedPortStatusEvent;
        public event EventHandler<EventArgs> OnTurnedOnAll;
        public event EventHandler<EventArgs> OnTurnedOffAll;
        public event EventHandler<EventArgs> OnTurnedOnSingle;
        public event EventHandler<EventArgs> OnTurnedOffSingle;

        public COMConnector.COMConnector connector;
        public List<int> Ports = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        public RelayDevice(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBit, KTALogger.Logger logger)
        {
            this.connector = new COMConnector.COMConnector(portName, baudRate, parity, dataBits, stopBit, logger);
        }


        /// <summary>
        /// Connect to the device
        /// </summary>
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

        /// <summary>
        /// Connect to the device
        /// </summary>
        public void Close()
        {
            this.connector.OnDataReceived -= OnReceivedMessageFromRelayDevice;
            this.connector.disconnect();
        }

        /// <summary>
        /// Connect to the device
        /// </summary>
        public void Reconnect()
        {
            this.connector.reconnect();
        }

        /// <summary>
        /// This method is used to handle received data
        /// from the USB relay device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReceivedMessageFromRelayDevice(object sender, COMConnector.events.OnDataReceivedEvent e)
        {
            Console.WriteLine(String.Format("Received message from USBRelay: {0}", e.Message));

            if (e.Message == "") return;

            if (ParsePowerStatusCommand.Execute(e.Message, ref RelayDevice.USBRelayDeviceStatusList) == true)
            {
                this.OnReceivedPortStatusEvent?.Invoke(sender, new OnReceivedPortStatusEvent(USBRelayDeviceStatusList));
            }
        }

      

        /// <summary>
        /// Check the state of the selected
        /// port
        /// </summary>
        /// <param name="portNumber"></param>
        public void isTurnedOn(int portNumber)
        {
            this.sendCommand("L " + portNumber.ToString(), false);
        }

        /// <summary>
        /// Check the state of the selected
        /// port
        /// </summary>
        /// <param name="portNumber"></param>
        public void getAllStatuses(int transition = 100)
        {
            foreach (int port in this.Ports)
            {
                this.sendCommand(String.Format("L {0}", port.ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void turnOnAll()
        {
            foreach (int port in this.Ports)
            {
                this.sendCommand(String.Format("S {0}", port.ToString()));
            }

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void turnOffAll()
        {
            foreach(int port in this.Ports)
            {
                this.sendCommand(String.Format("C {0}", port.ToString()));
            }

            this.OnTurnedOffAll?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portNumber"></param>
        public void turnOnByPort(int portNumber)
        {
            this.sendCommand(String.Format("S {0}", portNumber.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portNumber"></param>
        public void turnOffByPort(int portNumber)
        {
            this.sendCommand(String.Format("C {0}", portNumber.ToString()));
        }

      
        /// <summary>
        /// Main private method for
        /// sending the of commands
        /// </summary>
        /// <param name="command"></param>
        /// <param name="withResolver"></param>
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
