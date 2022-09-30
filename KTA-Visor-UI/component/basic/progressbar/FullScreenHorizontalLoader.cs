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
    public partial class FullScreenHorizontalLoader : UserControl
    {
        public event EventHandler<EventArgs> OnProgressEnd;
        private bool isStopped = false;

        public FullScreenHorizontalLoader()
        {
            InitializeComponent();
        }

        private void FullScreenHorizontalLoader_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.improvedProgressBar1.Left = (this.ClientSize.Width - this.improvedProgressBar1.Width) / 2;
            this.improvedProgressBar1.Top = (this.ClientSize.Height - this.improvedProgressBar1.Height) / 2;
        }

        public async Task<Thread> Start(int maxValue = 100, int sleep = 10)
        {

            this.isStopped = false;
            this.Visible = true;
            this.BringToFront();


            return await this.improvedProgressBar1.Start(maxValue, sleep);
        }


        public async Task<bool> Stop(int delay = 100)
        {
           return await this.improvedProgressBar1.Stop(delay);
        }
    }
}
