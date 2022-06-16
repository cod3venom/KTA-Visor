using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPTunnel.module.server.types
{
    public class TCPClientTObject
    {
        private string ipAddress;
        private Socket socket;
        private Thread thread;
        private bool isBlocked;

        public TCPClientTObject(string ipAddress, Socket socket, Thread thread, bool isBlocked = false)
        {
            this.ipAddress = ipAddress;
            this.socket = socket;
            this.thread = thread;
            this.isBlocked = isBlocked;
        }

        public TCPClientTObject setIpAddress(string ipAddress)
        {
            this.ipAddress = ipAddress;
            return this;
        }

        public string getIpAddress()
        {
            return this.ipAddress;
        }

        public TCPClientTObject setSocket(Socket socket)
        {
            this.socket = socket;
            return this;
        }

        public Socket getSocket()
        {
            return this.socket;
        }

        public TCPClientTObject setThread(Thread thread)
        {
            this.thread = thread;

            return this;
        }

        public Thread getThread()
        {
            return this.thread;
        }

        public TCPClientTObject block()
        {
            this.isBlocked = true;

            return this;
        }

        public TCPClientTObject unblock()
        {
            this.isBlocked = false;

            return this;
        }

        public bool isblocked()
        {
            return this.isBlocked;
        }

        public bool IsConnected()
        {
            try
            {
                return !(this.socket.Poll(1, SelectMode.SelectRead) && this.socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
    }
}
