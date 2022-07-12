using KTA_Visor_UI.component.custom.Sidebar.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.SideBar.components
{
    public partial class SidebarMenuItem : UserControl
    {
        
        public event EventHandler<SideBarItemClickedEvent> onClick;

        private dynamic extraObject;

        private readonly Font defaultFont;

        private bool active;

        public SidebarMenuItem()
        {
            InitializeComponent();
            this.defaultFont = this.label.Font;
        }

        public string Label
        {
            get { return this.label.Text; }
            set { this.label.Text = value; }
        }

        public dynamic ExtraObject
        {
            get { return this.extraObject; }
            set { this.extraObject = value; }
        }

        private void SidebarMenuItem_Load(object sender, EventArgs e)
        {
            this.label.Click += Label_Click;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            this.onClick?.Invoke(this, new SideBarItemClickedEvent(this));
        }

        public void setActive(string label)
        {
            if (this.Label != label)
            {
                this.label.Font = this.defaultFont; ;
                return;
            }

            this.label.Font = new Font(this.label.Font, FontStyle.Bold);
        }
 
    }
}

 
