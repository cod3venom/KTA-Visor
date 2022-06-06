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
        public RFIDAuthenticationView()
        {
            InitializeComponent();
        }

        private void RFIDAuthenticationView_Load(object sender, EventArgs e)
        {
            this.topBar.Parent = this;
        }
    }
}
