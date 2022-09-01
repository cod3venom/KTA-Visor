using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.Spinner
{
    public partial class Spinner : UserControl
    {

        public Spinner()
        {
            InitializeComponent();
        }

        private void Spinner_Load(object sender, EventArgs e)
        {
    
        }

        public void Show()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    this.spinnerBox.Show();
                });
            } else
            {
                this.spinnerBox.Show();
            }
        }

        public void Hide()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate {
                    this.spinnerBox.Hide();
                });
            }
            else
            {
                this.spinnerBox.Hide();
            }
        }
    }
}
