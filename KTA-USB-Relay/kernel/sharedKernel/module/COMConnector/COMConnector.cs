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

        private SerialPort client;

        public COMConnector(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            this.portName = portName;
            this.baudRate = baudRate;
            this.parity = parity;
            this.dataBits = dataBits;
            this.stopBits = stopBits;

            this.client = new SerialPort(this.portName, this.baudRate, this.parity, this.dataBits, this.stopBits);
        }

        public COMConnector connect()
        {
            if (!this.client.IsOpen)
            {
                this.client.Open();
            }

            this.initialize();
            return this;
        }

        private void initialize()
        {
            this.client.DataReceived += onDataReceived;
        }

        private void onDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.OnDataReceived?.Invoke(sender, new OnDataReceivedEvent(this.client));
            Console.WriteLine(this.client.ReadLine());
        }

        public COMConnector disconnect()
        {
            this.client?.Close();
            return this;
        }

        public COMConnector send(string message)
        {

            byte[] msg = Encoding.ASCII.GetBytes(message);
            this.client.Write(msg, 0, msg.Length);

            Thread.Sleep(1);
            return this;
        }

    }
}
