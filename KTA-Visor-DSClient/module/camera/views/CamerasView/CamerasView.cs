using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
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
        private readonly FalconBridge falconBridge;

        private readonly CameraService cameraService;

        public CamerasView()
        {
            InitializeComponent();

            this.falconBridge = new FalconBridge();
            this.cameraService = this.falconBridge.CameraService();
        }

        private void CamerasView_Load(object sender, EventArgs e)
        {

            string[] columns = new string[] { "ID", "Battery", "Disk usage", "SOCK Pos", "Status"};
            this.table.addColumns(columns);

            this.startListeningForDevices();
        }

        private void startListeningForDevices()
        {
            Thread deviceListenerThr = new Thread(() => this.cameraService.listenForConnection());
            deviceListenerThr.IsBackground = true;
            deviceListenerThr.Start();

            this.cameraService.OnCameraConnectedEvt += CameraService_OnCameraConnectedEvt;

        }

        private void CameraService_OnCameraConnectedEvt(object sender, CameraConnectedEvt e)
        {

            string[] row = new string[] {
                    e.getCamera().getDriveInfo().Name,
                    "100%",
                    e.getCamera().getDiskUsage(),
                    "5",
                    "ONLINE"
            };

            this.table.addRow(row);
        }

    }
}
