using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.component.basic.button
{
    public partial class PrimaryButton : UserControl
    {
        private bool active = false;

        private bool disabled = false;


        public PrimaryButton()
        {
            InitializeComponent();

            if (this.active)
            {
                this.BackColor = System.Drawing.ColorTranslator.FromHtml("#3F3F46"); ;
                this.ForeColor = Color.White;
            }
        }

        public bool Active
        {
            get { return active; }
            set { this.active = value; }
        }

        public string Title
        {
            get { return this.button.Text; }
            set { button.Text = value; }
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3F3F46");
        }
    }
}
