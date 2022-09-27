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

namespace KTA_Visor_UI.component.custom.HorizontalProgressBar
{
    public partial class HorizontalProgressBar : UserControl
    {
        public event EventHandler<EventArgs> OnProgressStarted;
        public event EventHandler<EventArgs> OnProgressFinished;
        public HorizontalProgressBar()
        {
            InitializeComponent();
        }

        public int Transition { get; set; }

        public Color ProgressColor { get; set; } 

        private void HorizontalProgressBar_Load(object sender, EventArgs e)
        {
            this.Width = 232;
            this.bunifuProgressBar.MaximumValue = 100;
        }



        public void start()
        {
            if (this.ProgressColor != null) 
                this.bunifuProgressBar.ProgressColor = this.ProgressColor;

            this.percentageLbl.Visible = true;
            Thread progressThr = new Thread(this._start);
            progressThr.IsBackground = true;
            progressThr.Start();
        }

        public void _start()
        {
            this.OnProgressStarted?.Invoke(this, EventArgs.Empty);
            for (int i = 0; i <= 100; i++)
            {
                this.Invoke((MethodInvoker)delegate {
                    this.bunifuProgressBar.Value = i;
                    this.percentageLbl.Text = String.Format("{0}%", i.ToString());
                

                    if (this.bunifuProgressBar.Value == 100)
                    {
                        this.OnProgressFinished?.Invoke(this, EventArgs.Empty);
                        this.Hide();
                        return;
                    }

                    Thread.Sleep(this.Transition);
                });
            }
        }
    }
}
