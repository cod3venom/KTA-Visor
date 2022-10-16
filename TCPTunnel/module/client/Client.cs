using KTALogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.types;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;
using TCPTunnel.module.shared;
using TCPTunnel.module.shared.events;

namespace TCPTunnel.module.client
{
    public class Client : ExtensionManager
    {

        public event EventHandler<TCPClientConnectedEvent> OnClientConnected;
        public event EventHandler<EventArgs> OnConnectionWasTerminated;

        public event EventHandler<TCPClientMessageReceivedEvent> OnDataReceived;
        public event EventHandler<OnClientExceptionHappend> OnExceptionOccured;

        private readonly ClientConfigTObject _config;
        private readonly KTALogger.Logger _logger;
        private BackgroundWorker _transmissionWorker;
        private TCPClientTObject _client;
        private readonly IPEndPoint _ipEndpoint;
        private bool _isConnected;


        public Client(ClientConfigTObject config, KTALogger.Logger logger)
        {
            this._config = config;
            this._logger = logger;
            this._transmissionWorker = new BackgroundWorker{
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            this._client = new TCPClientTObject(config.IpAddress);
            this._ipEndpoint = new IPEndPoint(IPAddress.Parse(config.IpAddress), config.Port);
            this._isConnected = false;
        }

        public void Connect()
        {
            try
            {
                if (this._isConnected){
                    return;
                }
                if (this._client.IsDisposed){
                    this._client = new TCPClientTObject(this._config.IpAddress);
                }
                if (this._transmissionWorker.IsBusy)
                {
                    this._transmissionWorker.CancelAsync();
                    this._transmissionWorker = new BackgroundWorker{
                        WorkerReportsProgress = true,
                        WorkerSupportsCancellation = true
                    };
                }
                

                this._client.Socket.Connect(this._ipEndpoint);
                this._isConnected = true;
                this._logger.info("Successfully connected to: " + this._config.IpAddress);

                this._transmissionWorker.DoWork += WatchTransmission;
                this._transmissionWorker.RunWorkerAsync();

            }
            catch(ObjectDisposedException exception)
            {
                this._logger.error("Client disconnected from the: " + this._config.IpAddress);
                this.HandleException(exception);
            }
            catch (SocketException exception)
            {
                this._logger.error("Client disconnected from the: " + this._config.IpAddress);
                this.HandleException(exception);
            }
        }

        public void Reconnect(int delay = 1000)
        {
            Thread.Sleep(delay);
            this.Connect();
        }

        private void WatchTransmission(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker transmissionWorker = (BackgroundWorker)sender;
            while (!transmissionWorker.CancellationPending)
            {
                this.HandleData();
                Thread.Sleep(1000);
            }
        }
 

        private void HandleData()
        {
            try
            {
                byte[] receiveMessageArray = new byte[4096];
                int length = this._client.Socket.Receive(receiveMessageArray);
                string message = Encoding.ASCII.GetString(receiveMessageArray, 0, length);
                Request request = this.Router.ParseRoute(this._client, message);

                if (request == null) {
                    return;
                }

                this._logger.print(String.Format("Received Request on: {0}, {1}", request.Endpoint, request.Body));

                if (request.Endpoint == Endpoints.AUTH_NEED_COMMAND_ENDPOINT)
                {
                    this.OnAuthCommandReceived(new OnAuthCommandReceived(this._client, request));
                    return;
                }

                if (request.Endpoint == Endpoints.AUTH_IS_OK_COMMAND_ENDPOINT)
                {
                    this.OnAuthIsOk(new OnAuthIsOK(this._client, request));
                    return;
                }
                else
                {
                    this.OnDataReceived?.Invoke(this, new TCPClientMessageReceivedEvent(request));
                }
            }

            catch(Exception exception)
            {
               this.HandleException(exception);
            }

        }

        private void OnAuthCommandReceived(OnAuthCommandReceived e)
        {
            this._client.Send(new Request(Endpoints.AUTH_NEED_RESPONSE_ENDPOINT, this._config.AuthData, e.Client));
        }

        private void OnAuthIsOk(OnAuthIsOK e)
        {
            this.OnClientConnected?.Invoke(this, new TCPClientConnectedEvent(this._client));
        }

        public void Send(Request request)
        {
            if (!this._isConnected){
                this._logger.warn("Unable to send request trought DISCONNECTED CLIENT");
                return;
            }

            this._client.Send(request);
        }
        private void HandleException(Exception exception)
        {
            this._isConnected = false;
            this._client.Disconnect();
            this.OnExceptionOccured?.Invoke(this, new OnClientExceptionHappend(exception));
        }
    }
}