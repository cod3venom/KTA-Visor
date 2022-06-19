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
    public partial class RoundedTextBox : UserControl
    {
        public RoundedTextBox()
        {
            InitializeComponent();
        }

        public string Text
        {
            get { return this.textBox.Text; }
            set { this.textBox.Text = value; }
        }

        public int BorderRadius
        {
            get { return this.bunifuElipse1.ElipseRadius; }
            set { this.bunifuElipse1.ElipseRadius = value; }
        }


        public TextBox Input
        {
            get { return this.textBox; }
            set { this.textBox = value; }
        }

        private void RoundedTextBox_Load(object sender, EventArgs e)
        {
            this.textBox.MinimumSize = new Size(this.Width - 20, this.Height);
            this.textBox.Size = new Size(this.Width - 20, this.Height);
            this.textBox.BackColor = this.BackColor;

            //this.textBox.Dock = DockStyle.Fill;

        }
    }
}
