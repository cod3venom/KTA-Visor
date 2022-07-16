using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.Sidebar
{
    public partial class Sidebar : UserControl
    {
        private readonly int MAX_WIDTH = 220;

        private readonly int MIN_WIDTH = 43;

        private  Control[] menuItems = new Control[0];

        private bool isHidden = false;

        public Sidebar()
        {
            InitializeComponent();
        }

        public Form ParentForrm { get; set; }
        public Panel ParentPanel { get; set; } 

        public Control[] MenuItems 
        { 
            get { return this.menuItems; }
            set { this.menuItems = value; }
        }

        private void Sidebar_Load(object sender, EventArgs e)
        {

            this.Width = this.MAX_WIDTH;
            this.menuPanel.Width = this.MAX_WIDTH;
        }


        public void show()
        {
            foreach (Control c in this.MenuItems)
            {
                c.Visible = true;
            }
            this.Visible = true;
            this.ParentPanel.Visible = true;
        }

        public void hide()
        {
            foreach(Control c in this.MenuItems)
            {
                c.Visible = false;
            }
            this.Visible = false;
            this.ParentPanel.Visible = false;
        }
    }
}
