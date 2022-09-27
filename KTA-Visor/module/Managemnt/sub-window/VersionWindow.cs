using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.sub_window
{
    public partial class VersionWindow : Form
    {
        public VersionWindow()
        {
            InitializeComponent();
            this.topBar1.Parent = this;
            this.topBar1.onClose += onClose;
        }

    
        private void VersionWindow_Load(object sender, EventArgs e)
        {
            this.okBtn.Click += onClose;
        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
