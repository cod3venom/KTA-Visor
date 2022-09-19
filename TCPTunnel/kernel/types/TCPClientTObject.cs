using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.shared.entity;

namespace TCPTunnel.kernel.types
{
    public class TCPClientTObject
    {
        private string ipAddress;
        private Socket socket;
        private Thread thread;
        private readonly string asWho;
        private bool isBlocked;

        private readonly KTALogger.Logger logger;
        public TCPClientTObject(string ipAddress, Socket socket, Thread thread = null, string asWho = "Client", bool isBlocked = false)
        {
            this.ipAddress = ipAddress;
            this.socket = socket;
            this.thread = thread;
            this.asWho = asWho;
            this.isBlocked = isBlocked;
            this.logger = new KTALogger.Logger();
        }

        public AuthData AuthData { get; set; }

        public string getIpAddress()
        {
            return this.ipAddress.Split(':')[0];
        }

        public string IpAddress
        {
            get { return this.ipAddress.Split(':')[0]; }
        }
        
        public int Port
        {
            get { return Int32.Parse(this.ipAddress.Split(':')[1]); }
        }

        public string FullAddress
        {
            get { return this.ipAddress; }
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
                byte[] messageArray = Encoding.UTF8.GetBytes(body);

                Thread sendThread = new Thread((ThreadStart)delegate
                {
                    this.socket.Send(messageArray);
                });

                sendThread.IsBackground = true;
                sendThread.Start();
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
