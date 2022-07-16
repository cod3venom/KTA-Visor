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
        public event EventHandler<EventArgs> OnProgressFinished;
        public HorizontalProgressBar()
        {
            InitializeComponent();
        }

        public int Transition { get; set; }

        private void HorizontalProgressBar_Load(object sender, EventArgs e)
        {
            this.bunifuProgressBar.MaximumValue = 100;
        }

        public void start()
        {
            for(int i = 0; i <= 100; i++)
            {
                this.Invoke((MethodInvoker)delegate {
                    this.bunifuProgressBar.Value = i;
                });

                if (this.bunifuProgressBar.Value == 100)
                {
                    this.OnProgressFinished?.Invoke(this, EventArgs.Empty);
                    break;
                }

                if (this.Transition != null)
                {
                    Thread.Sleep(Transition);
                } else
                {
                    Thread.Sleep(20);
                }
            }
        }
    }
}
