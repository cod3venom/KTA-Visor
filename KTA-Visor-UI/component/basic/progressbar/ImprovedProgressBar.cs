using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using KTA_Visor_UI.component.basic.progressbar.events;
using System.ComponentModel;

namespace KTA_Visor_UI.component.basic.progressbar
{
    public class ImprovedProgressBar : ProgressBar
    {
        public event EventHandler<OnProgressChangedEvent> OnProgressChanged;
        public event EventHandler<EventArgs> OnProgressEnd;

        private BackgroundWorker backgroundWorker;
        private int maxValue = 100;
        private int sleep = 1;
        public bool isStopped = false;

        public ImprovedProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.backgroundWorker = new BackgroundWorker();
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

                if (rec.Width <= 0) rec.Width = 1;
                if (rec.Height <= 0) rec.Height = 1;
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


        public string ProgressColor
        {
            set
            {
                this.ForeColor = ColorTranslator.FromHtml(value);
                this.BackColor = ColorTranslator.FromHtml(value);
            }
        }

        public void Start(int maxValue = 100, int sleep = 1)
        {
            this.maxValue = maxValue;
            this.sleep = 1;

            if (this.backgroundWorker.IsBusy)
            {
                this.backgroundWorker = new BackgroundWorker();
            }
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += onDoWork;
            this.backgroundWorker.RunWorkerAsync();
   
        }

        private void onDoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.BringToFront();

                for (int i = 0; i <= this.maxValue; i++)
                {
                    Thread.Sleep(sleep);

                    this.Maximum = maxValue;
                    this.Value = i;

                    this.backgroundWorker.ReportProgress(i);
                    this.OnProgressChanged?.Invoke(this, new OnProgressChangedEvent(i));

                    if (this.isStopped)
                        return;

                    if (this.Value == maxValue)
                    {
                        this.Hide();
                        this.OnProgressEnd?.Invoke(this, EventArgs.Empty);
                        return;
                    }
                }
            });
        }

        public async Task<bool> Stop(int delay = 1)
        {
            await Task.Delay(delay);
            this.isStopped = true;
            this.Hide();
            this.OnProgressEnd?.Invoke(this, EventArgs.Empty);
            return this.isStopped;
        }
 
    }
}
