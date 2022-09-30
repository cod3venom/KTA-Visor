using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TCPTunnel.kernel.extensions;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using TCPTunnel.module.server.dto;
using TCPTunnel.module.server.events;
using TCPTunnel.module.shared;
using TCPTunnel.module.shared.entity;
using TCPTunnel.module.shared.events;

namespace TCPTunnel.module.server
{
    public class Server : ExtensionManager
    {
        public event EventHandler<TCPServerStartedEvent> onServerStarted;
        public event EventHandler<EventArgs> onServerStopped;
        public event EventHandler<TCPServerClientConnectedEvent> onClientConnected;
        public event EventHandler<TCPServerClientDisonnectedEvent> onClientDisconnected;
        public event EventHandler<TCPServerClientMessageReceivedEvent> onMessageReceived;

        public event EventHandler<OnAuthCommandSent> onAuthCommandSent;
        public event EventHandler<OnAuthResponseDataReceived> onAuthResponseDataReceived;
        public event EventHandler<OnAuthIsOK> onAuthIsOk;

        private ServerConfigTObject serverConfig;
        private Socket serverSocket;
        private Thread serverSocketThread;
        private Thread heardBeatThread;
        private IPEndPoint ipEndpoint;

        private TCPClientList<string, TCPClientTObject> tempClientList;
        private TCPClientList<string, TCPClientTObject> clientsList;
        private bool isServerEnabled;
        private KTALogger.Logger logger;


        public Server(ServerConfigTObject serverConfig, KTALogger.Logger logger)
        {
            this.serverConfig = serverConfig;
            this.logger = logger;
            this.isServerEnabled = true;
            this.tempClientList = new TCPClientList<string, TCPClientTObject>();
            this.clientsList = new TCPClientList<string, TCPClientTObject>();
        }

        public void StartServer()
        {
            this.isServerEnabled = true;
            this.onAuthCommandSent += OnAuthCommandSent; ;
            this.onAuthResponseDataReceived += OnAuthResponseDataReceived; ;
            this.onAuthIsOk += OnAuthIsOk;
            this.logger.info(string.Format("Started TCP SERVER on {0}", this.serverConfig.ipAddress));

            this.bootstrap();
        }

        public void StopServer()
        {
            try
            {
                this.isServerEnabled = false;
                this.onAuthCommandSent -= OnAuthCommandSent; ;
                this.onAuthResponseDataReceived -= OnAuthResponseDataReceived; ;
                this.onAuthIsOk -= OnAuthIsOk;
                this.onServerStopped?.Invoke(this, EventArgs.Empty);
                this.logger.info(string.Format("Stopped TCP SERVER on {0}", this.serverConfig.ipAddress));
                this.serverSocket.Disconnect(true);
            }
            catch (Exception ex)
            {
                this.logger.error(ex.Message, ex);
            }

        }



        private void bootstrap()
        {
            try
            {
                this.ipEndpoint = new IPEndPoint(IPAddress.Parse(this.serverConfig.ipAddress), serverConfig.port);
                this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.serverSocket.Bind(this.ipEndpoint);
                this.serverSocket.Listen(this.serverConfig.listenInterval);
                // on server started

                this.serverSocketThread = new Thread(waitForClient);
                this.serverSocketThread.IsBackground = true;
                this.serverSocketThread.Start();
                this.isServerEnabled = true;
                this.onServerStarted?.Invoke(this, new TCPServerStartedEvent(this.serverConfig));


                this.heardBeatThread = new Thread(checkHeartBeat);
                this.heardBeatThread.IsBackground = true;
                this.heardBeatThread.Start();
                this.logger.info(string.Format("Bootstrapped TCP SERVER on {0}", this.serverConfig.ipAddress));

            }
            catch (SocketException ex)
            {
                this.logger.error(string.Format("Socket Exception occured : {0}", ex.Message));
            }
            catch (Exception ex)
            {
                this.logger.error(string.Format("Exception occured in TCP SERVER Bootstrapper: {0}", ex.Message));
            }
        }

        private void waitForClient()
        {
            try
            {
                while (this.isServerEnabled)
                {
                    Thread.Sleep(100);
                    Socket client = this.serverSocket.Accept();
                    this.handleNewCLient(client);
                }
            }
            catch (SocketException ex)
            {
                this.serverSocketThread?.Abort();
                this.serverSocket.Dispose();
                this.serverSocket.Close();
                this.logger.error(string.Format("Socket Exception occured when waiting for client: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                this.logger.error(string.Format("Exception occured when waiting for client: {0}", ex.Message));
            }
        }


        private void handleNewCLient(Socket newConnection)
        {


            string ipAddress = newConnection.RemoteEndPoint.ToString();
            TCPClientTObject client = new TCPClientTObject(ipAddress, newConnection, null, "Server");

            if (this.tempClientList.ContainsKey(ipAddress))
                return;

            this.tempClientList.addClient(ipAddress, client);

            Request authCommandRequest = new Request(Endpoints.AUTH_NEED_COMMAND_ENDPOINT);
            client.Send(authCommandRequest);
            this.onAuthCommandSent.Invoke(this, new shared.events.OnAuthCommandSent(client, authCommandRequest));

            Thread messengerThread = new Thread(() => this.OnReceiveMessage(client));
            messengerThread.IsBackground = true;
            messengerThread.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public void OnReceiveMessage(TCPClientTObject client)
        {
            while (client.IsConnected())
            {

                try
                {
                    Thread.Sleep(100);
                    byte[] receiveMessageArray = new byte[this.serverSocket.ReceiveBufferSize];
                    int length = client.getSocket().Receive(receiveMessageArray);
                    string message = Encoding.ASCII.GetString(receiveMessageArray, 0, length);

                    Request request = this.Router.ParseRoute(client, message);

                    if (request == null)
                    {
                        return;
                    }

                    if (request.Endpoint == Endpoints.AUTH_NEED_RESPONSE_ENDPOINT)
                    {
                        this.onAuthResponseDataReceived.Invoke(this, new OnAuthResponseDataReceived(client, request));
                    }
                    else
                    {
                        this.onMessageReceived.Invoke(this, new TCPServerClientMessageReceivedEvent(request));
                    }

                }
                catch (SocketException ex)
                {
                    this.logger.error(string.Format("Socket Exception occured when receiving message from client: {0}", ex.Message));
                }
                catch (Exception ex)
                {
                    this.logger.error(string.Format("Socket Exception occured when receiving message from client: {0}", ex.Message));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAuthCommandSent(object sender, OnAuthCommandSent e)
        {
            Console.WriteLine(String.Format("Client {0} Asked for authentication on : {1}", e.Client.getIpAddress(), e.Request.Endpoint));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAuthResponseDataReceived(object sender, OnAuthResponseDataReceived e)
        {
            if (e.Request.Body == null)
                return;
            this.onAuthIsOk.Invoke(this, new OnAuthIsOK(e.Client, e.Request));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAuthIsOk(object sender, OnAuthIsOK e)
        {
            JObject jb = (JObject)e.Request.Body;
            dynamic authData = jb.ToObject<AuthData>();
            e.Client.Send(new Request(Endpoints.AUTH_IS_OK_COMMAND_ENDPOINT));
            e.Client.AuthData = authData;

            string ipAddress = e.Client.getSocket().RemoteEndPoint.ToString();
            if (this.clientsList.ContainsKey(ipAddress))
                return;

            this.clientsList.addClient(ipAddress, e.Client);

            this.logger.info(string.Format("Successfully authenticated and added client in CLIENTLIST", e.Client.getIpAddress()));

            this.onClientConnected.Invoke(e, new TCPServerClientConnectedEvent(e.Client));
        }

        private void checkHeartBeat()
        {
            while (this.isServerEnabled)
            {
                Thread.Sleep(100);

                foreach (var existedClient in this.clientsList.Values.ToList())
                {
                    if (existedClient is null) continue;
                    if (existedClient.IsConnected()) continue;

                    var key = this.clientsList.Where(pair => pair.Value == existedClient).Select(pair => pair.Key).FirstOrDefault();
                    this.clientsList.Remove(key);
                    this.logger.info(string.Format("Detected client disconnection when checkin HEARTBEAT: {0}", existedClient.getIpAddress()));

                    this.onClientDisconnected?.Invoke(this, new TCPServerClientDisonnectedEvent(existedClient));
                }
            }
        }

        private void handleMessages(Object client)
        {

        }
    }
}