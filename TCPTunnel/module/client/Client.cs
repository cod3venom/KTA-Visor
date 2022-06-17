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
        public event EventHandler<TCPClientConnectedEvent> onClientConnected;

        public event EventHandler<TCPClientMessageReceivedEvent> onReceivedMessage;

        private readonly ClientConfigTObject config;
        private readonly IPEndPoint ipEndpoint;
        
        private Thread clientThread;
        private Thread bootstrapThread;
        private TCPClientTObject client;

        private readonly Logger logger;

        public Client(ClientConfigTObject config)
        {
            this.config = config;
            this.ipEndpoint =  new IPEndPoint(IPAddress.Parse(config.IpAddress), config.Port);
        }

        public Client connect()
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(this.ipEndpoint);

            this.client = new TCPClientTObject(clientSocket.RemoteEndPoint.ToString(), clientSocket);

            this.onClientConnected?.Invoke(this, new TCPClientConnectedEvent(this.client));

            this.bootstrapThread = new Thread(this.bootStrap);
            this.bootstrapThread.IsBackground = true;
            this.bootstrapThread.Start();

            return this;
        }

        private void bootStrap()
        {
            while(this.client.IsConnected())
            {
                Thread.SpinWait(1000);

                Thread onReceiveThread = new Thread(() => this.receiveMessages(this.client));
                onReceiveThread.IsBackground = true;
                onReceiveThread.Start();
            }
        }

        private void receiveMessages(TCPClientTObject client)
        {
            try
            {
                Thread.SpinWait(100);
                byte[] receiveMessageArray = new byte[1024];

                int length = client.getSocket().Receive(receiveMessageArray);
                string message = Encoding.ASCII.GetString(receiveMessageArray, 0, length);

                Request request = this.Router.ParseRoute(client, message);

                this.onReceivedMessage?.Invoke(this, new TCPClientMessageReceivedEvent(request));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
