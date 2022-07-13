using KTALogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;

namespace TCPTunnel.module.client
{
    public class Client : ExtensionManager
    {
        public bool AutoReconnect;

        public event EventHandler<TCPClientConnectedEvent> onClientConnected;

        public event EventHandler<EventArgs> onClientDisconnected;

        public event EventHandler<TCPClientMessageReceivedEvent> onReceivedMessage;

        private readonly ClientConfigTObject config;
        private readonly IPEndPoint ipEndpoint;
        
        private Thread clientThread;
        private Thread bootstrapThread;
        private TCPClientTObject client;

        private readonly KTALogger.Logger logger;

        public Client(ClientConfigTObject config, KTALogger.Logger logger)
        {
            this.config = config;
            this.ipEndpoint =  new IPEndPoint(IPAddress.Parse(config.IpAddress), config.Port);
            this.logger = logger;
        }

        public Client connect()
        {
            try
            {
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(this.ipEndpoint);

                this.client = new TCPClientTObject(clientSocket.RemoteEndPoint.ToString(), clientSocket);

                this.onClientConnected?.Invoke(this, new TCPClientConnectedEvent(this.client));

                this.bootstrapThread = new Thread(this.bootStrap);
                this.bootstrapThread.IsBackground = true;
                this.bootstrapThread.Start();

                this.logger.success("Successfully connected to: " + this.config.IpAddress);


                while (!this.isConnected())
                {
                    this.onClientDisconnected?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
            catch(SocketException)
            {
                this.onClientDisconnected?.Invoke(this, EventArgs.Empty);
            }

            return this;
        }

        public Client disconnect()
        {
            this.client.getSocket().Close();

            return this;
        }

        public void autoReconnect()
        {
            while (!this.isConnected())
            {
                if (this.isConnected()) break;

                this.logger.warn("Trying to auto-reconnect ...");
                this.connect();

                Thread.Sleep(5000);
            }
        }

        public Client reConnect()
        {
            this.logger.warn("Reconnecting ...");
            this.client.getSocket().Disconnect(false);
            this.connect();
            this.logger.success("Successfully reconnected");
            return this;
        }

        private void bootStrap()
        {
            while(this.client.IsConnected())
            {
                Thread.Sleep(5000);

                Thread onReceiveThread = new Thread(() => this.receiveMessages(this.client));
                onReceiveThread.IsBackground = true;
                onReceiveThread.Start();
            }
        }

        private void receiveMessages(TCPClientTObject client)
        {
            try
            {
                
                byte[] receiveMessageArray = new byte[4096];

                int length = client.getSocket().Receive(receiveMessageArray);
                string message = Encoding.ASCII.GetString(receiveMessageArray, 0, length);
                this.logger.info("Plain message: " + message);

                Request request = this.Router.ParseRoute(client, message);

                this.logger.info("Received Request on: " + request.Endpoint +  "\n with body: "+ request.Body);

                this.onReceivedMessage?.Invoke(this, new TCPClientMessageReceivedEvent(request));

                Thread.SpinWait(5000);
            }
            catch (Exception ex)
            {

            }
        }


        public void send(Request request)
        {
            this.client.Send(request);

            this.logger.info("Sent request on: " + request.Endpoint + "\n with body: " + request.Body);
        }

        public bool isConnected()
        {
            if (this.client != null)
            {
                return this.client.IsConnected();
            }
            return false;
        }
    }
}
