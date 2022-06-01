using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using KTA_TCPBridge.BridgeServer.dto;
using KTA_TCPBridge.BridgeServer.resource.Client;

namespace KTA_TCPBridge.BridgeServer.Resource.Server
{
    public delegate void ServerStartedEventHandler(object sender, EventArgs e);
     
    public class TCPServer
    {
        private ServerConfigTObject serverConfig;
        private Socket serverSocket;
        private Thread serverSocketThread;
        private IPEndPoint ipEndpoint;
        private TCPClientList<string, TCPClient> clientsList;
        private bool isServerEnabled;

        public event ServerStartedEventHandler onServerStarted;

        public TCPServer(ServerConfigTObject serverConfig)
        {
            this.serverConfig = serverConfig;
            this.isServerEnabled = false;
            this.initialize();
        }

        private void initialize()
        {
            this.clientsList = new TCPClientList<string, TCPClient>();
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

                this.onServerStarted += new EventHandler(onServerStartedHandler);
            }
            catch(SocketException ex)
            {
                //on socketError
            }
            catch(Exception ex)
            {
                // onError
            }
        }

        private void onServerStartedHandler(object? sender, EventArgs e)
        {
            this.onServerStarted?.Invoke(sender, e);
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
            TCPClient client = new TCPClient(
                ipAddress,
                newConnection,
                clientThread
            );

            this.clientsList.addClient(ipAddress, client);

            //on client added
        }

        private void handleMessages(Object client)
        {

        }
    }
}
