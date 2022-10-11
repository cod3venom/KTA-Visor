using KTA_USB_Relay.kernel.sharedKernel.module.COMConnector.events;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_USB_Relay.kernel.sharedKernel.module.COMConnector
{
    public class COMConnector
    {

        public event EventHandler<OnDataReceivedEvent> OnDataReceived;

        private string portName;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;
        private readonly KTALogger.Logger logger;

        private SerialPort client;

        public COMConnector(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, KTALogger.Logger logger)
        {
            this.portName = portName;
            this.baudRate = baudRate;
            this.parity = parity;
            this.dataBits = dataBits;
            this.stopBits = stopBits;
            this.logger = logger;
            this.client = new SerialPort(this.portName, this.baudRate, this.parity, this.dataBits, this.stopBits);
            this.initialize();
        }

        public COMConnector connect()
        {
            try
            {
                if (!this.client.IsOpen)
                {
                    this.client.Open();
                    this.initialize();
                    this.logger.success(string.Format("Connected to the {0}", this.portName));

                }
            }
            catch(Exception)
            {

            }
            return this;
        }

        public COMConnector disconnect()
        {
            this.client?.Close();
            return this;
        }

        public COMConnector reconnect()
        {
            if (this.client.IsOpen)
            {
                this.client.Close();
                Thread.Sleep(1000);
            }
            this.client.Open();
            return this;
        }
        public bool isConnected
        {
            get
            {
                return this.client.IsOpen;
            }
        }

        private void initialize()
        {
            this.client.DataReceived += onDataReceived;
        }

        private void onDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = this.client.ReadExisting();
            this.logger.info(string.Format("Received from {0} : {1}", this.portName, receivedData));
            this.OnDataReceived?.Invoke(sender, new OnDataReceivedEvent(this.client, receivedData));
        }

        public COMConnector send(string message)
        {

            byte[] msg = Encoding.ASCII.GetBytes(message);
            this.client.Write(msg, 0, msg.Length);
            this.logger.info(string.Format("Sending command OVER {0} : {1}", this.portName, message));

            Thread.Sleep(1);
            return this;
        }

        public COMConnector discardInBuffer()
        {
            this.client.DiscardInBuffer();
            return this;
        }
    }
}
