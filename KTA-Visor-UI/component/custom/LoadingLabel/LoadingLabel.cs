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

namespace KTA_Visor_UI.component.custom.LoadingLabel
{
    public partial class LoadingLabel : UserControl
    {
        public LoadingLabel()
        {
            InitializeComponent();
        }

        private void LoadingLabel_Load(object sender, EventArgs e)
        {

        }

        public void setStatusText(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                   this.loadingLbl.Text = text;
                });
            }
            else
            {
                this.loadingLbl.Text = text;
            }
        }
        public void start()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach(Control control in this.Parent.Controls)
                    {
                        control.Visible = false;
                    }
                    this.Visible = true;
                });
            }
            else
            {
                this.Visible = true;
            }

            Thread.Sleep(1000);
        }

        public void stop()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    foreach (Control control in this.Parent.Controls)
                    {
                        control.Visible = true;
                    }
                    this.Visible = false;
                });
            } else
            {
                this.Visible = false;
            }

            Thread.Sleep(1000);
        }
    }
}
