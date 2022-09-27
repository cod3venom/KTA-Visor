using KTALogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;
using TCPTunnel.module.shared;
using TCPTunnel.module.shared.events;

namespace TCPTunnel.module.client
{
    public class Client : ExtensionManager
    {

        public event EventHandler<TCPClientConnectedEvent> onClientConnected;
        public event EventHandler<EventArgs> onClientDisconnected;
        public event EventHandler<TCPClientMessageReceivedEvent> onReceivedMessage;
        public event EventHandler<OnAuthCommandReceived> onAuthCommandReceived;
        public event EventHandler<OnAuthIsOK> onAuthIsOk;
        public event EventHandler<OnClientExceptionHappend> OnException;

        private readonly ClientConfigTObject config;
        private readonly IPEndPoint ipEndpoint;

        private TCPClientTObject client;

        private readonly KTALogger.Logger logger;

        public Client(ClientConfigTObject config, KTALogger.Logger logger)
        {
            this.config = config;
            this.ipEndpoint = new IPEndPoint(IPAddress.Parse(config.IpAddress), config.Port);
            this.logger = logger;

            this.onAuthCommandReceived += OnAuthCommandReceived;
            this.onAuthIsOk += OnAuthIsOk;
            this.onClientDisconnected += onClientDisconnectedHandler;
        }

        public bool IsAutoReconnectEnabled { get; set; }

        public Client connect()
        {
            try
            {
                Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(this.ipEndpoint);

                this.client = new TCPClientTObject(clientSocket.RemoteEndPoint.ToString(), clientSocket);

                this.logger.success("Successfully connected to: " + this.config.IpAddress);

                Thread listeningThread = new Thread(() => this.listening());
                listeningThread.Start();

            }
            catch (SocketException)
            {
                this.onClientDisconnected?.Invoke(this, EventArgs.Empty);
            }

            return this;
        }


        private void listening()
        {
            try
            {
                while (this.client.IsConnected())
                {
                    Thread.Sleep(1000);

                    Thread onReceiveThread = new Thread(() => this.OnReceiveMessage(this.client));
                    onReceiveThread.IsBackground = true;
                    onReceiveThread.Start();
                }

                this.onClientDisconnected?.Invoke(this, EventArgs.Empty);
            }
            catch(Exception exception) {
                this.OnException?.Invoke(this, new OnClientExceptionHappend(exception));
            }
        }

        public Client disconnect()
        {
            if (this.client == null)
                return this;

            if (this.client.IsConnected())
            {
                this.client.getSocket().Close();
            }

            return this;
        }



        private void onClientDisconnectedHandler(object sender, EventArgs e)
        {
            if (!this.IsAutoReconnectEnabled)
                return;
            if (!this.isConnected())
                return;

            Thread.Sleep(1000);
            this.connect();
        }

        private void OnReceiveMessage(TCPClientTObject client)
        {
            try
            {

                byte[] receiveMessageArray = new byte[4096];

                int length = client.getSocket().Receive(receiveMessageArray);
                string message = Encoding.ASCII.GetString(receiveMessageArray, 0, length);
                this.logger.hidden("Plain message: " + message);

                Request request = this.Router.ParseRoute(client, message);

                if (request == null)
                {
                    return;
                }
                this.logger.print(String.Format("Received Command on: {0}, {1}", request.Endpoint, request.Body));

                if (request.Endpoint == Endpoints.AUTH_NEED_COMMAND_ENDPOINT)
                {
                    this.onAuthCommandReceived?.Invoke(this, new OnAuthCommandReceived(client, request));
                    return;
                }
                if (request.Endpoint == Endpoints.AUTH_IS_OK_COMMAND_ENDPOINT)
                {
                    this.onAuthIsOk?.Invoke(this, new OnAuthIsOK(client, request));
                    return;
                }
                else
                {
                    this.onReceivedMessage?.Invoke(this, new TCPClientMessageReceivedEvent(request));
                }

                request = null;

                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                this.client.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }


        public void send(Request request)
        {
            this.client.Send(request);

            this.logger.info("Sent request on: " + request.Endpoint + "\n with body: " + request.Body);
        }

        public bool isConnected()
        {
            bool connected = this.client.IsConnected();
            return connected;
        }

        private void OnAuthCommandReceived(object sender, OnAuthCommandReceived e)
        {
            client.Send(new Request(Endpoints.AUTH_NEED_RESPONSE_ENDPOINT, this.config.AuthData));
        }

        private void OnAuthCommandSent(object sender, OnAuthResponseDataSent e)
        {
            Console.WriteLine(String.Format("Sent auth request from {0}", e.Client.getIpAddress()));
        }

        private void OnAuthIsOk(object sender, OnAuthIsOK e)
        {
            this.onClientConnected?.Invoke(this, new TCPClientConnectedEvent(this.client));
        }
    }
}