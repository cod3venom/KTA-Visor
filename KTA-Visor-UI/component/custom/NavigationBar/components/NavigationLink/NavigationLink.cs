using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.NavigationBar.components
{
    public partial class NavigationLink : UserControl
    {
        
        public NavigationLink()
        {
            InitializeComponent();
        }

        private void NavigationLink_Load(object sender, EventArgs e)
        {
        }

        public string Label
        {
            get { return this.linkLabel.Text; }
            set { this.linkLabel.Text = value; }
        }
        public Label LabelUI
        {
            get { return this.linkLabel; }
        }

        private void linkLabel_MouseEnter(object sender, EventArgs e)
        {
            this.linkLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#44D62C");
        }

        private void linkLabel_MouseLeave(object sender, EventArgs e)
        {
            this.linkLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#B8D4F5"); ;
        }
    }
}
