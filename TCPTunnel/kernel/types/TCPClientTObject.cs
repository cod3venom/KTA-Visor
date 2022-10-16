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
    public class TCPClientTObject : IDisposable
    {
        private string ipAddress;
        private Socket socket;


        public TCPClientTObject(string ipAddress, Socket socket = null)
        {
            this.ipAddress = ipAddress;
            this.socket = socket;

            if (this.socket == null){
                this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            this.IsDisposed = false;

        }

        public AuthData AuthData { get; set; }
        public string IpAddress {get { return this.ipAddress.Split(':')[0]; }}
        public int Port { get { return Int32.Parse(this.ipAddress.Split(':')[1]); }}
        public Socket Socket { get { return this.socket; }}
        public bool IsDisposed { get; set; }

        public void Send(Request request)
        {
            if (this.IsConnected)
            {
               
                string body = request.toJson();
                byte[] messageArray = Encoding.UTF8.GetBytes(body);

                this.socket.Send(messageArray);
            }
        }

        public void Disconnect()
        {
            if (this.socket == null)
                return;

           if (this.socket.Connected)
            {
                this.socket?.Shutdown(SocketShutdown.Both);
                this.socket?.Close();
            }
            this.Dispose();
        }

        public void Dispose()
        {
            this.socket?.Dispose();
            this.IsDisposed = true;
        }

        public bool IsConnected
        {
            get
            {
                try
                {
                    return !(this.socket.Poll(1, SelectMode.SelectRead) && this.socket.Available == 0);
                }
                catch (SocketException) { return false; }
                catch (Exception) { return false; }
            }
        }
    }
}
