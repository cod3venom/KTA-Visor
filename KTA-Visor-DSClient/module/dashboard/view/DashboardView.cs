using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
using KTA_Visor_DSClient.module.camera.service;
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
        private readonly FalconBridge falconBridge;

        /// <summary>
        /// 
        /// </summary>
        private tunnel.Tunnel tunnel;

        /// <summary>
        /// 
        /// </summary>
        private readonly CameraDeviceService cameraDeviceService;

        /// <summary>
        /// 
        /// </summary>
        private readonly CameraService cameraService;
        /// <summary>
        /// 
        /// </summary>
        private Thread deviceListenerThr;

        /// <summary>
        /// 
        /// </summary>
        private USBCameraDeviceList<USBCameraDevice> camerasList;


        private enum WM_DEVICECHANGE
        {
            DBT_DEVNODES_CHANGED = 0x0007
        }

        private int WmDevicechange = 0x0219; // device change event  

        public DashboardView()
        {
            InitializeComponent();
            this.settings = new Settings();

            this.topBar1.Parent = this;
            this.topBar1.Title = this.settings.SettingsObj.app.title;
            this.topBar1.onClose += OnClose;

            this.loggerView.ParentPanel = this.loggerViewPanel;

            this.logger = new KTALogger.Logger();
            this.falconBridge = new FalconBridge();
            this.camerasList = new USBCameraDeviceList<USBCameraDevice>();
            this.cameraDeviceService = this.falconBridge.CameraDeviceService();
            this.cameraService = new CameraService(this.camerasList);

            this.tunnel = new tunnel.Tunnel(new ClientConfigTObject(
                this.settings.SettingsObj.app.management.serverIp,
                this.settings.SettingsObj.app.management.serverPort
            ));
            //this.tcpClientPanel.Tunnel = this.tunnel;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DashboardView_Load(object sender, EventArgs e)
        {
           
            for(int i =0;i < 10; i++)
            {
                this.fileHistory.addFile("file_" + i.ToString() + ".mp4", "z:\\dowody", false);
            }

            for (int i = 0; i < 10; i++)
            {
                CameraItem camera = new CameraItem();
                camera.Margin = new Padding(10, 10, 10, 20);
                camerasPanel.Controls.Add(camera);
            }
        }

        private void OnStartListeningForCameras(object sender, EventArgs e)
        {
            Thread watchForDeviceThr = new Thread(this.watchForDevices);
            watchForDeviceThr.IsBackground = true;
            watchForDeviceThr.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose(object sender, EventArgs e)
        {
            this.tunnel.disconnect();
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
        private void watchForDevices()
        {
            this.deviceListenerThr = new Thread(() => this.cameraDeviceService.listenForConnection());
            this.deviceListenerThr.IsBackground = true;
            this.deviceListenerThr.Start();

            this.cameraDeviceService.OnCameraConnectedEvent += OnCameraConnectedEvt;
            this.cameraDeviceService.OnCameraDisconnectedEvent += OnCameraDisconnectedEvent;

            this.tunnel.onClientDisconnected += Tunnel_onClientDisconnected;
            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;


            this.logger.info("Started Listening process");

            Thread.Sleep(5000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraConnectedEvt(object sender, CameraConnectedEvent e)
        {
            CameraItem cameraItem = new CameraItem(e.Camera);
            this.camerasList.Add(e.getCamera());
 
            this.Invoke((MethodInvoker)delegate {
               // this.camerasLayoutPanel.Controls.Add(cameraItem);
            });

            if (this.settings.SettingsObj.app.fileSystem.autoCopy)
            {
                this.cameraService
                    .copyFielsToNetworkStorage(e.getCamera().Drive.Name);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            //foreach(USBCameraDevice camera in this.camerasList)
            //{
            //    if (camera.SerialNumber != e.Camera.SerialNumber) continue;

            //    foreach (CameraItem cameraItem in camerasLayoutPanel.Controls)
            //    {
            //        if (cameraItem.Camera.SerialNumber != e.Camera.SerialNumber) continue;

            //        this.camerasList.Remove(camera);

            //        this.Invoke((MethodInvoker)delegate { 
            //            this.camerasLayoutPanel.Controls.Remove(cameraItem);
            //        });
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tunnel_onMessageReceived(object sender, TCPClientMessageReceivedEvent e)
        {
            new CameraController(
                this.camerasList,
                this.tunnel
            ).StartWatching(e.getRoute());

            Thread.Sleep(5000);
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
                        Thread watchForDeviceThr = new Thread(this.watchForDevices);
                        watchForDeviceThr.IsBackground = true;
                        watchForDeviceThr.Start();
                        break;
                }
            }
        }

        
    }
}
