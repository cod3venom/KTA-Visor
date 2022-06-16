using KTA_Visor.kernel.module.VirtualRFID;
using KTA_Visor.module.Authentication.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Authentication.view
{
    public partial class RFIDAuthenticationView : Form
    {
        public event EventHandler<RFIDAuthFailEvent> OnAuthFailed;
        public event EventHandler<RFIDAuthSuccessEvent> OnAuthSucceed;

        private readonly VirtualRFID rfid;
        public RFIDAuthenticationView()
        {
            InitializeComponent();
            this.rfid = new VirtualRFID();
        }

        private void RFIDAuthenticationView_Load(object sender, EventArgs e)
        {
            this.topBar.Parent = this;
            this.rfid.connect();
        }
    }
}
