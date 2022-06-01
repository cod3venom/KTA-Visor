using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KTA_TCPBridge.BridgeServer.resource.Client
{
    public class TCPClient
    {
        private string ipAddress;
        private Socket socket;
        private Thread thread;
        private bool isBlocked;

        public TCPClient(string ipAddress, Socket socket, Thread thread, bool isBlocked = false)
        {
            this.ipAddress = ipAddress;
            this.socket = socket;
            this.thread = thread;
            this.isBlocked = isBlocked;
        }

        public TCPClient setIpAddress(string ipAddress)
        {
            this.ipAddress = ipAddress;
            return this;
        }

        public string getIpAddress()
        {
            return this.ipAddress;
        }

        public TCPClient setSocket(Socket socket)
        {
            this.socket = socket;
            return this;
        }
        
        public Socket getSocket()
        {
            return this.socket;
        }

        public TCPClient setThread(Thread thread)
        {
            this.thread = thread;

            return this;
        }

        public Thread getThread()
        {
            return this.thread;
        }

        public TCPClient block()
        {
            this.isBlocked = true;

            return this;
        }

        public TCPClient unblock()
        {
            this.isBlocked = false;

            return this;
        }

        public bool isblocked()
        {
            return this.isBlocked;
        }
    }
}
