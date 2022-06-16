using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
using KTA_Visor_DSClient.kernel.sharedKernel.logger;
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

namespace KTA_Visor_DSClient.module.camera.views.CamerasView
{
    public partial class CamerasView : Form
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
        private readonly CameraService cameraService;

        /// <summary>
        /// 
        /// </summary>
        private Thread deviceListenerThr;

        private enum WM_DEVICECHANGE
        {
            DBT_DEVNODES_CHANGED = 0x0007
        }

        private int WmDevicechange = 0x0219; // device change event  

        private string[] Columns = new string[] { 
            "ID", "Name", "SN", "Battery", "Disk usage", "SOCK Pos", "Status" 
        };


        public CamerasView()
        {
            InitializeComponent();

            this.logger = new Logger();
            this.falconBridge = new FalconBridge();
            this.cameraService = this.falconBridge.CameraService();
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

        private void CamerasView_Load(object sender, EventArgs e)
        {
            this.table.addColumns(this.Columns);
            this.startListeningForDevices();
        }

        private void startListeningForDevices()
        {
            this.deviceListenerThr = new Thread(() => this.cameraService.listenForConnection());
            this.deviceListenerThr.IsBackground = true;
            this.deviceListenerThr.Start();
            this.deviceListenerThr.Join();
            this.cameraService.OnCameraConnectedEvent += CameraService_OnCameraConnectedEvt;
            this.cameraService.OnCameraDisconnectedEvent += CameraService_OnCameraDisconnectedEvent;

            this.logger.info("Started Listening process");
        }

        private void CameraService_OnCameraConnectedEvt(object sender, CameraConnectedEvent e)
        {
            string id = (this.cameraService.Cameras.Count()).ToString();
            string[] row = new string[] {
                    id,
                    e.getCamera().getDriveInfo().Name,
                    e.getCamera().getSerialNumber(),
                    "100%",
                    e.getCamera().getDiskUsage(),
                    "5",
                    "ONLINE"
            };

            this.table.addRow(row);
        }

        private void CameraService_OnCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {

            DataGridViewRow row = this.table.findRow(e.getCamera().getSerialNumber());
            this.table.removeRow(row.Index);
        }

    }
}
