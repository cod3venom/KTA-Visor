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

namespace TCPTunnel.module.server
{
    public class Server : ExtensionManager
    {
        public event EventHandler<EventArgs> onServerStarted;
        public event EventHandler<TCPServerClientConnectedEvent> onClientConnected;
        public event EventHandler<TCPServerClientDisonnectedEvent> onClientDisconnected;
        public event EventHandler<TCPServerClientMessageReceivedEvent> onMessageReceived;


        private ServerConfigTObject serverConfig;
        private Socket serverSocket;
        private Thread serverSocketThread;
        private Thread heardBeatThread;
        private IPEndPoint ipEndpoint;

        private TCPClientList<string, TCPClientTObject> clientsList;
        private bool isServerEnabled;

        public Server(ServerConfigTObject serverConfig)
        {
            this.serverConfig = serverConfig;
            this.isServerEnabled = true;
            this.initialize();
        }

        private void initialize()
        {
            this.clientsList = new TCPClientList<string, TCPClientTObject>();
            this.ipEndpoint = new IPEndPoint(IPAddress.Parse(this.serverConfig.ipAddress), serverConfig.port);
            this.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void startServer()
        {
            this.isServerEnabled = true;
            this.bootstrap();
        }

        public void stopServer()
        {
            this.isServerEnabled = false;
            this.serverSocket.Close();
        }

    

        private void bootstrap()
        {
            try
            {
                this.serverSocket.Bind(this.ipEndpoint);
                this.serverSocket.Listen(this.serverConfig.listenInterval);
                // on server started

                this.serverSocketThread = new Thread(waitForClient);
                this.serverSocketThread.IsBackground = true;
                this.serverSocketThread.Start();
                this.isServerEnabled = true;
                this.onServerStarted?.Invoke(this, new EventArgs());


                this.heardBeatThread = new Thread(checkHeartBeat);
                this.heardBeatThread.IsBackground = true;
                this.heardBeatThread.Start();



            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void waitForClient()
        {
            while (this.isServerEnabled)
            {
                Thread.Sleep(10);
                Socket client = this.serverSocket.Accept();
                this.handleNewCLient(client);
            }
        }


        private void handleNewCLient(Socket newConnection)
        {
            Thread clientThread = new Thread(this.handleMessages);
            clientThread.IsBackground = true;
            clientThread.Start(newConnection);
            
            string ipAddress = newConnection.RemoteEndPoint.ToString();
            TCPClientTObject client = new TCPClientTObject(ipAddress,newConnection,clientThread);

            this.clientsList.addClient(ipAddress, client);
            this.onClientConnected?.Invoke(this, new TCPServerClientConnectedEvent(client));

            Thread messengerThread = new Thread(() => this.OnReceiveMessage(client));
            messengerThread.IsBackground = true;
            messengerThread.Start();
        }


        public void OnReceiveMessage(TCPClientTObject client)
        {
            while(client.IsConnected())
            {
               
                try
                {
                    Thread.SpinWait(100);
                    byte[] receiveMessageArray = new byte[1024];
                    int length = client.getSocket().Receive(receiveMessageArray);
                    string message = Encoding.ASCII.GetString(receiveMessageArray, 0, length);

                    Request route = this.Router.ParseRoute(client, message);
                    this.onMessageReceived?.Invoke(this, new TCPServerClientMessageReceivedEvent(route));
                }
                catch (SocketException ex)
                { }
            }
        }

        private void checkHeartBeat()
        {
            while (this.isServerEnabled)
            {
                foreach (var existedClient in this.clientsList.Values.ToList())
                {
                    if (existedClient is null) continue;
                    if (existedClient.IsConnected()) continue;

                    var key = this.clientsList.Where(pair => pair.Value == existedClient).Select(pair => pair.Key).FirstOrDefault();
                    this.clientsList.Remove(key);

                    this.onClientDisconnected?.Invoke(this, new TCPServerClientDisonnectedEvent(existedClient));
                }

                Thread.Sleep(1000);
            }
        }

        private void handleMessages(Object client)
        {

        }
    }
}
