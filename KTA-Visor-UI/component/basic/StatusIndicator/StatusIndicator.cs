using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.StatusIndicator
{
    public partial class StatusIndicator : UserControl
    {
        public StatusIndicator()
        {
            InitializeComponent();
        }

        private void StatusIndicator_Load(object sender, EventArgs e)
        {

        }

        public void running(bool flag, string label = "")
        {
            if (flag)
            {
                this.Icon = Properties.Resources.green_circle;
            } else
            {
                this.Icon = Properties.Resources.red_circle;
            }

            this.Label = label;
        }

        public Image Icon
        {
            get { return this.picBox.Image; }
            set { this.picBox.Image = value; }
        }

        public string Label
        {
            get { return this.lbl.Text; }
            set { this.lbl.Text = value; }
        }
    }
}
