using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
using KTA_Visor_DSClient.kernel.Hardware;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTA_Visor_DSClient.module.camera.dto;
using KTA_Visor_DSClient.module.camera.service;
using KTA_Visor_DSClient.module.camera.store;
using KTA_Visor_DSClient.module.dashboard.componnets.CameraItem;
using KTA_Visor_DSClient.module.dashboard.controller;
using KTA_Visor_DSClient.module.settings.views;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTA_Visor_UI.component.custom.MenuStripRenderer;
using KTALogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.client.events;

namespace KTA_Visor_DSClient.module.dashboard.view
{
    public partial class DashboardView : Form
    {
        private readonly Settings settings;

        /// <summary>
        /// 
        /// </summary>
        private readonly KTALogger.Logger logger;


        /// <summary>
        /// 
        /// </summary>
        private tunnel.Tunnel _tunnel;

   

        /// <summary>
        /// 
        /// </summary>
        private readonly SingleCameraService _singleCameraService;

        /// <summary>
        /// 
        /// </summary>
        private readonly CameraDeviceServiceWrapper _cameraDeviceServiceWrapper;


        private enum WM_DEVICECHANGE
        {
            DBT_DEVNODES_CHANGED = 0x0007
        }

        private int WmDevicechange = 0x0219; // device change event  

        public DashboardView(KTALogger.Logger logger)
        {
            InitializeComponent();

            this.logger = logger;
            this.settings = new Settings();

            this._cameraDeviceServiceWrapper = new CameraDeviceServiceWrapper(this.logger);
            this._singleCameraService = new SingleCameraService();

            this._tunnel = new tunnel.Tunnel(new ClientConfigTObject(
                this.settings.SettingsObj.app.management.serverIp,
                this.settings.SettingsObj.app.management.serverPort
            ));
            
            this.topBar.Parent = this;
            this.topBar.Title = this.settings.SettingsObj.app.title;
            this.topBar.onClose += OnClose;

            this.loggerView.ParentPanel = this.loggerViewPanel;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DashboardView_Load(object sender, EventArgs e)
        {

            this.logger.OnLogHasWritten += OnLogHasWritten;
            this._cameraDeviceServiceWrapper.OnCameraConnectedEvent += OnCameraConnectedEvent;
            this._cameraDeviceServiceWrapper.OnCameraDisconnectedEvent += OnCameraDisconnectedEvent;


            this._tunnel.onClientDisconnected += Tunnel_onClientDisconnected;
            this._tunnel.onMessageReceived += Tunnel_onMessageReceived;

            this.connectToTunelMenuItem.Click += ConnectToTunnel;
            this.disconnectFromTunelMenuItem.Click += DisconnectFromTunnel;
            this.restartTunelMenuItem.Click += RestartTunnelConnection;
            this._cameraDeviceServiceWrapper.Start();


            //USBDeviceRelay relayDevice = new USBDeviceRelay();
            

        }

        private void ConnectToTunnel(object sender, EventArgs e)
        {
            this._tunnel.connect();
        }
         
        private void DisconnectFromTunnel(object sender, EventArgs e)
        {
            this._tunnel.disconnect();
        }

        private void RestartTunnelConnection(object sender, EventArgs e)
        {
            this._tunnel.disconnect();
            Task.Delay(100);
            this._tunnel.connect();
        }


        private void OnLogHasWritten(object sender, Logger.dto.LoggerEvent e)
        {
            this.loggerView.append(e.Log);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, EventArgs e)
        {
            this._tunnel.disconnect();
            Application.Exit();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShowFileSystem(object sender, EventArgs e)
        {
            new FileSystemSettingsView().ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShowManagement(object sender, EventArgs e)
        {
            new ManagementSettingsView().ShowDialog();
        }
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraConnectedEvent(object sender, CameraConnectedEvent e)
        {
            CameraItem cameraItem = new CameraItem(e.Camera);
            if (CamerasVirtualStorage.exists(cameraItem)) return;

            CamerasVirtualStorage.Add(cameraItem);

             
            if (camerasFlowLayoutPanel.InvokeRequired || this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    camerasFlowLayoutPanel.Controls.Add(cameraItem);
                    
                });
            } else
            {
                camerasFlowLayoutPanel.Controls.Add(cameraItem);
            }
            

            if (!this.settings.SettingsObj.app.fileSystem.autoCopy)
                return;

            var copiedFiles = this._singleCameraService.copyFielsToNetworkStorage(e.getCamera().Drive.Name);

            foreach (KeyValuePair<string, CopiedCameraFileTObject> pair in copiedFiles)
            {
                this.fileHistory.addFile(pair.Value.File, pair.Value.Directory, pair.Value.Diff);
                this.logger.info(String.Format("Copied file {0} from device {1} ", pair.Value.File.FullName, e.getCamera().Drive.Name));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            foreach (CameraItem cameraItem in CamerasVirtualStorage.CameraItems)
            {
                if (cameraItem.SerialNumber != e.Camera.SerialNumber) continue;

                this.camerasFlowLayoutPanel.Controls.Remove(cameraItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tunnel_onMessageReceived(object sender, TCPClientMessageReceivedEvent e)
        {
            new CameraController(
                this._tunnel,
                this.logger
            ).StartWatching(e.getRoute());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Tunnel_onClientDisconnected(object sender, EventArgs e)
        {
            MessageBox.Show("KTA-Visor server is offline");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WmDevicechange)
            {
                switch ((WM_DEVICECHANGE)m.WParam)
                {
                    case WM_DEVICECHANGE.DBT_DEVNODES_CHANGED:
                        this._cameraDeviceServiceWrapper.Start();
                        break;
                }
            }
        }

        
    }
}
