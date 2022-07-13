using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.kernel.types
{
    public class TCPClientTObject
    {
        private string ipAddress;
        private Socket socket;
        private Thread thread;
        private bool isBlocked;

        private readonly KTALogger.Logger logger;
        public TCPClientTObject(string ipAddress, Socket socket, Thread thread = null, bool isBlocked = false)
        {
            this.ipAddress = ipAddress;
            this.socket = socket;
            this.thread = thread;
            this.isBlocked = isBlocked;
            this.logger = new KTALogger.Logger();
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

        public Socket Sock
        {
            get { return this.socket; }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public void Send(Request request)
        {
            if (this.IsConnected())
            {
               
                string body = request.toJson();
                this.logger.info("Sending JSON message : ");
                this.logger.info(body);
                byte[] messageArray = Encoding.UTF8.GetBytes(body);
                this.socket.Send(messageArray);

                Thread.SpinWait(5000);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            try
            {
                return !(this.socket.Poll(1, SelectMode.SelectRead) && this.socket.Available == 0);
            }
            catch (SocketException) { return false; }
            catch(Exception) { return false; }
        }
    }
}
