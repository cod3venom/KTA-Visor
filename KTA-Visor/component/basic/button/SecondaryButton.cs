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
    public partial class SecondaryButton : UserControl
    {
        public EventHandler<EventArgs> OnClick;

        public SecondaryButton()
        {
            InitializeComponent();
        }

        private void SecondaryButton_Load(object sender, EventArgs e)
        {
            this.Click += SecondaryButton_Click;
            this.button.Click += SecondaryButton_Click;
        }

        private void SecondaryButton_Click(object sender, EventArgs e)
        {
            this.OnClick?.Invoke(this, EventArgs.Empty);
        }

        public string Title
        {
            get { return this.button.Text; }
            set { button.Text = value; }
        }
    }
}
