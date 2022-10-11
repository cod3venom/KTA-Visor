using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.progressbar
{
    public partial class ImprovedProgressBarWithPercentage : UserControl
    {
        public event EventHandler<EventArgs> OnProgressEnd;
        public ImprovedProgressBarWithPercentage()
        {
            InitializeComponent();
        }

        private void ImprovedProgressBarWithTitle_Load(object sender, EventArgs e)
        {
            this.improvedProgressBar1.OnProgressChanged += onProgressChanged;
            this.improvedProgressBar1.OnProgressEnd += onProgressEnd;
        }

        private void onProgressEnd(object sender, EventArgs e)
        {
            this.improvedProgressBar1.Stop();
            this.percentageLbl.Visible = false;
        }

        public string PercentageAlign
        {
            get { return this.percentageLbl.Dock.ToString();  }
            set
            {
                switch(value)
                {
                    case "left":
                        this.percentageLbl.Dock = DockStyle.Left;
                        break;

                    case "right":
                        this.percentageLbl.Dock = DockStyle.Right;
                        break;

                    case "top":
                        this.percentageLbl.Dock = DockStyle.Top;
                        break;

                    case "bottom":
                        this.percentageLbl.Dock = DockStyle.Bottom;
                        break;
                }
            }
        }

        public void Start(int maxValue = 100, int sleep = 1)
        {
            this.improvedProgressBar1.Start(maxValue, sleep);

            if (this.improvedProgressBar1.Value == maxValue)
            {
                this.OnProgressEnd?.Invoke(this, EventArgs.Empty);
                return;
            }
        }

        private void onProgressChanged(object sender, events.OnProgressChangedEvent e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.percentageLbl.Text = e.ProgressText;
            });
        }
    }
}
