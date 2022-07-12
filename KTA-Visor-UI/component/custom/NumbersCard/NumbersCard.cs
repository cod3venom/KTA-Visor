using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.NumbersCard
{
    public partial class NumbersCard : UserControl
    {
        public NumbersCard()
        {
            InitializeComponent();
        }

        public string Number
        {
            get { return this.numberLbl.Text; }
            set { this.numberLbl.Text = value; }
        }

        public string Label
        {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }


        private void NumbersCard_Load(object sender, EventArgs e)
        {
        }


        public void setNumber(string number)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.numberLbl.Text = number;
            });
        }

        public void setLabel(string label)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.label.Text = label;
            });
        }

        private void onMouseIn()
        {
            this.mainPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
            this.mainPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
            this.numberLbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
            this.label.BackColor = System.Drawing.ColorTranslator.FromHtml("#556C95");
        }
        private void onMouseOut()
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
            this.mainPanel.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
            this.numberLbl.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
            this.label.BackColor = System.Drawing.ColorTranslator.FromHtml("#002361");
        }

        private void mainPanel_MouseEnter(object sender, EventArgs e)
        {
            this.onMouseIn();
        }

        private void mainPanel_MouseLeave(object sender, EventArgs e)
        {
            this.onMouseOut();
        }

        private void numberLbl_MouseEnter(object sender, EventArgs e)
        {
            this.onMouseIn();
        }

        private void numberLbl_MouseLeave(object sender, EventArgs e)
        {
            this.onMouseOut();
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            this.onMouseIn();
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            this.onMouseOut();
        }
    }
}
