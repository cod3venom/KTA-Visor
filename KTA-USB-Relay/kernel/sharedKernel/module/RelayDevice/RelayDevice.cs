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
using KTA_USB_Relay.kernel.sharedKernel.module.COMConnector.events;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.command;
using static KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.command.ParsePowerStatusCommand;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto;
using System.IO.Ports;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.enums;

namespace KTA_USB_Relay.kernel.sharedKernel.module.commander
{
    public class RelayDevice : IRelayDevice
    {
        /// <summary>
        /// 
        /// </summary>
        public static USBRelayPortsToObject USBRelayDeviceStatusList = new USBRelayPortsToObject();

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<OnReceivedPortStatusEvent> OnReceivedPortStatusEvent;

        public event EventHandler<EventArgs> OnEndTurningOnfAll;

        public event EventHandler<EventArgs> OnEndTurningOffAll;

        public event EventHandler<EventArgs> OnTurnedOnByPort;

        public event EventHandler<EventArgs> OnTurnedOffByPort;
        
        /// <summary>
        /// 
        /// </summary>
        public COMConnector.COMConnector connector;

        public List<int> Ports = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portName"></param>
        /// <param name="baudRate"></param>
        /// <param name="parity"></param>
        /// <param name="dataBits"></param>
        /// <param name="stopBit"></param>
        public RelayDevice(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBit, KTALogger.Logger logger)
        {
            this.connector = new COMConnector.COMConnector(portName, baudRate, parity, dataBits, stopBit, logger);
        }


        /// <summary>
        /// Connect to the device
        /// </summary>
        public void Open()
        {
            this.connector.OnDataReceived += OnReceivedMessageFromRelayDevice;
            this.connector.connect();
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
            Console.WriteLine(String.Format("Received stopbit from USBRelay: {0}", e.SerialPort.StopBits.ToString()));
            Console.WriteLine(String.Format("Received handshake from USBRelay: {0}", e.SerialPort.Handshake.ToString()));



            if (e.Message == "") return;

            if (ParsePowerStatusCommand.Execute(e.Message, ref RelayDevice.USBRelayDeviceStatusList) == true)
            {
                this.OnReceivedPortStatusEvent?.Invoke(sender, new OnReceivedPortStatusEvent(USBRelayDeviceStatusList));
            }
        }

        /// <summary>
        /// Turn off port 1
        /// </summary>
        public void TurnOff1()
        {
            this.sendCommand(TurnOff.P1);
        }


        /// <summary>
        /// Turn off port 2
        /// </summary>
        public void TurnOff2()
        {
            this.sendCommand(TurnOff.P2);
        }


        /// <summary>
        /// Turn off port 3
        /// </summary>
        public void TurnOff3()
        {
            this.sendCommand(TurnOff.P3);
        }


        /// <summary>
        /// Turn off port 4
        /// </summary>
        public void TurnOff4()
        {
            this.sendCommand(TurnOff.P4);
        }


        /// <summary>
        /// Turn off port 5
        /// </summary>
        public void TurnOff5()
        {
            this.sendCommand(TurnOff.P5);
        }


        /// <summary>
        /// Turn off port 6
        /// </summary>
        public void TurnOff6()
        {
            this.sendCommand(TurnOff.P6);
        }


        /// <summary>
        /// Turn off port 7
        /// </summary>
        public void TurnOff7()
        {
            this.sendCommand(TurnOff.P7);
        }


        /// <summary>
        /// Turn off port 8
        /// </summary>
        public void TurnOff8()
        {
            this.sendCommand(TurnOff.P1);
        }


        /// <summary>
        /// Turn on port 1
        /// </summary>
        public void TurnOn1()
        {
            this.sendCommand(TurnON.P1);
        }

        /// <summary>
        /// Turn on port 2
        /// </summary>
        public void TurnOn2()
        {
            this.sendCommand(TurnON.P2);
        }

        /// <summary>
        /// Turn on port 3
        /// </summary>
        public void TurnOn3()
        {
            this.sendCommand(TurnON.P3);
        }

        /// <summary>
        /// Turn on port 4
        /// </summary>
        public void TurnOn4()
        {
            this.sendCommand(TurnON.P4);
        }

        /// <summary>
        /// Turn on port 5
        /// </summary>
        public void TurnOn5()
        {
            this.sendCommand(TurnON.P5);
        }

        /// <summary>
        /// Turn on port 6
        /// </summary>
        public void TurnOn6()
        {
            this.sendCommand(TurnON.P6);
        }

        /// <summary>
        /// Turn on port 7
        /// </summary>
        public void TurnOn7()
        {
            this.sendCommand(TurnON.P7);
        }


        /// <summary>
        /// Turn on port 8
        /// </summary>
        public void TurnOn8()
        {
            this.sendCommand(TurnON.P8);
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
            for (int i = 1; i < 9; i++)
            {
                this.sendStringCommand(String.Format("L {0}", i.ToString()));
                Thread.Sleep(transition);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void turnOnAll(int transition = 100)
        {
            this.Ports.ForEach((delegate (int port)
            {
                this.sendStringCommand(String.Format("S {0}", port.ToString()));
                Thread.Sleep(transition);

                if (port == (int)Port.Eight)
                {
                    this.OnEndTurningOnfAll?.Invoke(this, EventArgs.Empty);
                }
            }));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        public void turnOffAll(int transition = 100)
        {
            this.Ports.ForEach((delegate (int port)
            {
                this.sendStringCommand(String.Format("C {0}", port.ToString()));
                Thread.Sleep(transition);
                if (port == (int)Port.Eight)
                {
                    this.OnEndTurningOffAll?.Invoke(this, EventArgs.Empty);
                }
            }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portNumber"></param>
        public void turnOnByPort(int portNumber)
        {
            this.sendStringCommand(String.Format("S {0}", portNumber.ToString()));
            Thread.Sleep(100);
            this.OnTurnedOnByPort?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portNumber"></param>
        public void turnOffByPort(int portNumber)
        {
            this.sendStringCommand(String.Format("C {0}", portNumber.ToString()));
            Thread.Sleep(100);
            this.OnTurnedOffByPort?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Send command as custom string
        /// </summary>
        /// <param name="command"></param>
        public void sendStringCommand(string command)
        {
            this.sendCommand(command);
        }

        /// <summary>
        /// Main private method for
        /// sending the of commands
        /// </summary>
        /// <param name="command"></param>
        /// <param name="withResolver"></param>
        private void sendCommand(string command, bool withResolver = true)
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
