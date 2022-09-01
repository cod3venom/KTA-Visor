using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.button
{
    public partial class PrimaryButton : UserControl
    {
        public event EventHandler<EventArgs> OnClick;
        
        private bool active = false;


        public PrimaryButton()
        {
            InitializeComponent();

            if (this.active)
            {
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
            get { return this.btn.Text; }
            set { btn.Text = value; }
        }

        public Button button
        {
            get { return this.btn; }
            set { this.btn = value; }
        }

        private void button_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.ForeColor = System.Drawing.ColorTranslator.FromHtml("#3F3F46");
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.OnClick?.Invoke(this, e);
        }
    }
}
