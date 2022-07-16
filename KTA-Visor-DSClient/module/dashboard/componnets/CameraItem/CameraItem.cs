using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.dashboard.componnets.CameraItem
{
    public partial class CameraItem : UserControl
    {
        public CameraItem()
        {
            InitializeComponent();
        }

        public CameraItem(USBCameraDevice camera)
        {
            this.Name = camera.Drive.Name;
            this.SerialNumber = camera.SerialNumber;
            this.Camera = camera;
        }

        public CameraItem(string name, string serialNumber = "")
        {
            this.Name = name;
            this.SerialNumber = serialNumber;
        }

        private void CameraItem_Load(object sender, EventArgs e)
        {

        }

        private void CameraItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
        }

        private void CameraItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
        }

        public USBCameraDevice Camera { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }

       
    }
}
