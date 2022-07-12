using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.Footer
{
    public partial class Footer : UserControl
    {
        public Footer()
        {
            InitializeComponent();
        }

        private void Footer_Load(object sender, EventArgs e)
        {
            this.sfBtn.Click += SfBtn_Click;
        }

        private void SfBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.skillsforge.co");
        }
    }
}
