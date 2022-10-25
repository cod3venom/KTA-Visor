using System;
using System.Drawing;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.StatusIndicator
{
    public partial class StatusIndicator : UserControl
    {
        public StatusIndicator()
        {
            InitializeComponent();
        }

        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        private void StatusIndicator_Load(object sender, EventArgs e)
        {

        }

        public void running(bool flag, string label = "")
        {
            if (flag)
            {
                this.Icon = Properties.Resources.green_circle_pulse_on_gray;
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
