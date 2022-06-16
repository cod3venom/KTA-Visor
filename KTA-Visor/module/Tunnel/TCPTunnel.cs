
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Tunnel
{
    public class TCPTunnel
    {
        private readonly ServerConfigTObject config;
        private readonly KTAServer server;
         
        public TCPTunnel()
        {
            this.config = new ServerConfigTObject("Server 1", "192.168.0.136", 1337);
            this.server = new KTAServer(this.config);
        }

        public void start()
        {
            this.server.Bridge.TcpServer.startServer();
            this.server.Bridge.TcpServer.onServerStarted += TcpServer_onServerStarted;
            this.server.Bridge.TcpServer.onClientConnected += TcpServer_onClientConnected;
            this.server.Bridge.TcpServer.onClientDisconnected += TcpServer_onClientDisconnected;
        }

        private void TcpServer_onServerStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Server: UP");

        }

        private void TcpServer_onClientConnected(object sender, TCPServerClientConnectedEvent e)
        {
            Console.WriteLine("Connected: " + e.getClient().getIpAddress());
        }
        private void TcpServer_onClientDisconnected(object sender, TCPServerClientDisonnectedEvent e)
        {
            Console.WriteLine("Disconnected: " + e.getClient().getIpAddress());
        }


    }
}
