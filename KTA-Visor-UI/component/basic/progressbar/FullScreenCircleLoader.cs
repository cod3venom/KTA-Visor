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
    public partial class FullScreenCircleLoader : UserControl
    {
        public event EventHandler<EventArgs> OnProgressEnd;

        private bool isStopped = false;

        public FullScreenCircleLoader()
        {
            InitializeComponent();
        }

        private void FullScreenCircleLoader_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }


        public async Task<Thread> Start(int maxValue = 100, int sleep = 10)
        {

            this.isStopped = false;
            this.Visible = true;
            this.BringToFront();

            Thread thr = new Thread((ThreadStart)delegate
            {
                for (int i = 0; i <= maxValue; i++)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (this.isStopped)
                            return;

                        Thread.Sleep(sleep);

                        if (i == maxValue)
                        {
                            this.Hide();
                            this.OnProgressEnd?.Invoke(this, EventArgs.Empty);
                            return;
                        }
                    });
                }
            });

            thr.IsBackground = true;
            thr.Start();
            return thr;
        }


        public async Task<bool> Stop(int delay = 100)
        {
            await Task.Delay(delay);
            this.isStopped = true;
            this.Hide();
            this.OnProgressEnd?.Invoke(this, EventArgs.Empty);
            return this.isStopped;
        }
    }
}
