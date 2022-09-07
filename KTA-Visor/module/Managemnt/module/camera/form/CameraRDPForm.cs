using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.camera.form
{
    public partial class CameraRDPForm : Form
    {
        public event EventHandler<EventArgs> OnClose;
        private readonly string stationIp;

        public CameraRDPForm()
        {
            InitializeComponent();
        }

        public CameraRDPForm(string stationIp)
        {
            InitializeComponent();
            this.stationIp = stationIp;

            this.topBar.Parent = this;
            this.topBar.MinimizeButton.Visible = false;
            this.topBar.onClose += onClose;
        }


        private void CameraRDPForm_Load(object sender, EventArgs e)
        {
            this.rdpClient.Server = this.stationIp;
            this.rdpClient.UserName = "venom";
            this.rdpClient.AdvancedSettings2.ClearTextPassword = "Stuxnet0013";
            this.rdpClient.AdvancedSettings7.EnableCredSspSupport = true;
            this.rdpClient.Connect();
        }

        private void onClose(object sender, EventArgs e)
        {
            this.rdpClient = new AxMSTSCLib.AxMsRdpClient6();
            this.rdpClient.Disconnect();
            this.OnClose?.Invoke(this, e);
            this.Close();
        }
    }
}
