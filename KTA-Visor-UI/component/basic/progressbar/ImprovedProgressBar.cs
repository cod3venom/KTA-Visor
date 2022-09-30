using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.progressbar
{
    public class ImprovedProgressBar : ProgressBar
    {
        public event EventHandler<EventArgs> OnProgressEnd;

        public bool isStopped = false;

        public ImprovedProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                LinearGradientBrush brush = null;
                Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
                double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));

                if (ProgressBarRenderer.IsSupported)
                    ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

                rec.Width = (int)((rec.Width * scaleFactor) - 4);
                rec.Height -= 4;
                brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
                e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);

                this.ForeColor = ColorTranslator.FromHtml("#EBB90B");
                this.BackColor = ColorTranslator.FromHtml("#EBB90B");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<Thread> Start(int maxValue = 100, int sleep = 15)
        {
            this.BringToFront();
             

            Thread thr = new Thread((ThreadStart)delegate
            {
                for (int i = 0; i <= maxValue; i++)
                {
                    this.Invoke((MethodInvoker)delegate {
                        this.Maximum = maxValue;
                        this.Value = i;
                        Thread.Sleep(sleep) ;

                        if (this.isStopped)
                            return;

                        if (this.Value == maxValue)
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
