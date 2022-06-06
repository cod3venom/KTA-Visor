using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using KTA_TCPBridge.BridgeServer.dto;
using KTA_TCPBridge.BridgeServer.Resource.Server.Events;

namespace KTA_TCPBridge.BridgeServer.Resource.Server
{
     
    public class TCPServer
    {
        public event EventHandler<EventArgs> onServerStarted;
        public event EventHandler<TCPServerClientConnectedEvent> onClientConnected;
        public event EventHandler<TCPServerClientDisonnectedEvent> onClientDisconnected;


        private ServerConfigTObject serverConfig;
        private Socket serverSocket;
        private Thread serverSocketThread;
        private IPEndPoint ipEndpoint;
        private TCPClientList<string, TCPClientTObject> clientsList;
        private bool isServerEnabled;

        public TCPServer(ServerConfigTObject serverConfig)
        {
            this.serverConfig = serverConfig;
            this.isServerEnabled = false;
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
            if (!this.isServerEnabled)
            {
                this.isServerEnabled = true;
                this.bootstrap();
            }
        }

        public void stopServer()
        {
            if (this.isServerEnabled)
            {
                this.isServerEnabled = false;
            }
        }

        public Boolean isRunning()
        {
            return this.isServerEnabled;
        }

        private void bootstrap()
        {
            try
            {
                this.serverSocket.Bind(this.ipEndpoint);
                this.serverSocket.Listen(this.serverConfig.listenInterval);
                // on server started

                this.serverSocketThread = new Thread(this.waitForClient);
                this.serverSocketThread.IsBackground = true;
                this.serverSocketThread.Start();
                this.onServerStarted?.Invoke(this, new EventArgs());

            }
            catch (SocketException ex)
            {
                //on socketError
            }
            catch(Exception ex)
            {
                // onError
            }
        }

        private void waitForClient()
        {
            while(this.isServerEnabled)
            {
                if (!this.isServerEnabled || !this.serverSocket.Connected) break;

                this.handleNewCLient(this.serverSocket.Accept());
            }
        }

        private  void handleNewCLient(Socket newConnection)
        {
            Thread clientThread= new Thread(this.handleMessages);
            clientThread.IsBackground = true;
            clientThread.Start(newConnection);
            string ipAddress = newConnection.RemoteEndPoint.ToString();
            TCPClientTObject client = new TCPClientTObject(
                ipAddress,
                newConnection,
                clientThread
            );

            this.clientsList.addClient(ipAddress, client);
            this.onClientConnected?.Invoke(this, (new TCPServerClientConnectedEvent(client)));

        }

        private void handleMessages(Object client)
        {

        }
    }
}
