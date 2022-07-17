using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.basic.textbox
{
    public partial class DefaultTextBox : UserControl
    {
        public DefaultTextBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return this.textBox.Text; }
            set { this.textBox.Text = value; }
        }
        private void DefaultTextBox_Load(object sender, EventArgs e)
        {
            this.textBox.GotFocus += TextBox_GotFocus;
            this.textBox.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            this.textBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#D9D9D9");
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            this.textBox.BackColor = Color.White;
        }
    }
}
