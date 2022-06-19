using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
using KTA_Visor_DSClient.module.camera.controller;
using KTA_Visor_UI.component.basic.table.bundle.abstraction.column.dto;
using KTALogger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.module.client.dto;

namespace KTA_Visor_DSClient.module.camera.views.CamerasView
{
    public partial class CamerasListView : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Logger logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly FalconBridge falconBridge;

        /// <summary>
        /// 
        /// </summary>
        private readonly tunnel.Tunnel tunnel;

        /// <summary>
        /// 
        /// </summary>
        private readonly CameraService cameraService;

        /// <summary>
        /// 
        /// </summary>
        private Thread deviceListenerThr;

        private USBCameraDeviceList<USBCameraDevice> camerasList;

        /// <summary>
        /// 
        /// </summary>
        private readonly CamerasListViewController controller;

        private enum WM_DEVICECHANGE
        {
            DBT_DEVNODES_CHANGED = 0x0007
        }

        private int WmDevicechange = 0x0219; // device change event  

        private ColumnTObject[] Columns = new ColumnTObject[] { 
            new ColumnTObject(0, "ID"),
            new ColumnTObject(1, "Name"),
            new ColumnTObject(2, "SN"),
            new ColumnTObject(3, "Disk usage"),
            new ColumnTObject(4, "Status"),
        };


        public CamerasListView()
        {
            InitializeComponent();

            this.topBar1.Parent = this;

            this.logger = new Logger();
            this.falconBridge = new FalconBridge();
            this.camerasList = new USBCameraDeviceList<USBCameraDevice>();
            this.cameraService = this.falconBridge.CameraService();
            this.tunnel = new tunnel.Tunnel(new ClientConfigTObject("127.0.0.1", 1337));
            this.controller = new CamerasListViewController(this);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WmDevicechange)
            {
                switch ((WM_DEVICECHANGE)m.WParam)
                {
                    case WM_DEVICECHANGE.DBT_DEVNODES_CHANGED:
                        this.startListeningForDevices();
                        break;
                }
            }
        }

        public tunnel.Tunnel Tunnel
        {
            get { return this.tunnel; }
        }

        public USBCameraDeviceList<USBCameraDevice> CamerasList
        {
            get { return this.camerasList; }
        }

        private void CamerasView_Load(object sender, EventArgs e)
        {
            this.table.bundle.column.addMultiple(this.Columns);
            this.startListeningForDevices();
            this.tunnel.connect();
        }

        private void startListeningForDevices()
        {
            this.deviceListenerThr = new Thread(() => this.cameraService.listenForConnection());
            this.deviceListenerThr.IsBackground = true;
            this.deviceListenerThr.Start();

            this.cameraService.OnCameraConnectedEvent -= CameraService_OnCameraConnectedEvt;
            this.cameraService.OnCameraDisconnectedEvent -= CameraService_OnCameraDisconnectedEvent;

            this.cameraService.OnCameraConnectedEvent += CameraService_OnCameraConnectedEvt;
            this.cameraService.OnCameraDisconnectedEvent += CameraService_OnCameraDisconnectedEvent;

            this.tunnel.onMessageReceived += Tunnel_onMessageReceived;

            this.logger.info("Started Listening process");

            Thread.Sleep(5000);
        }
 

        private void Tunnel_onMessageReceived(object sender, TCPTunnel.module.client.events.TCPClientMessageReceivedEvent e)
        {
            CamerasListViewController controller = new CamerasListViewController(this);
            controller.StartWatching(e.getRoute());
            Thread.Sleep(5000);
        }

        private void CameraService_OnCameraConnectedEvt(object sender, CameraConnectedEvent e)
        {
           
            string id = (this.cameraService.Cameras.Count()).ToString();
            this.table.bundle.row.add(
                id,
                e.getCamera().Drive?.Name,
                e.getCamera().SerialNumber,
                "100%",
                e.getCamera().DiskUsage,
                "5",
                "ONLINE"
            );

            this.camerasList.Add(e.getCamera());
            this.controller.onAuthenticate(this.camerasList.ToArray());
        }

        private void CameraService_OnCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            this.table.bundle.row.removeRow(e.getCamera().SerialNumber);
        }

    }
}
