using KTA_Visor_UI.component.custom.NavigationBar.components;
using KTA_Visor_UI.component.custom.NavigationBar.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.NavigationBar
{
    public partial class NavigationBar : UserControl
    {
        private string[] links;

        public event EventHandler<NavigationBarLinkClickEvent> OnClick;

        public NavigationBar()
        {
            InitializeComponent();
            this.links = new string[] { };
        }

        public void NavigationBar_Load()
        {
            
        }

        public void initialize()
        {
            foreach (string link in this.links)
            {
                NavigationLink navLink = new NavigationLink();
                navLink.Label = link;
                navLink.Dock = DockStyle.Right;

                navLink.Click += new EventHandler((sender, e) => this.NavLink_Click(sender, e, link));
                navLink.LabelUI.Click += new EventHandler((sender, e) => this.NavLink_Click(sender, e, link));
                this.linksContainer.Controls.Add(navLink);
            }
        }

        private void NavLink_Click(object sender, EventArgs e, string link)
        {
            this.OnClick?.Invoke(this, new NavigationBarLinkClickEvent(link));
        }

        public string[] Links 
        {
            get { return this.links; } 
            set { this.links = value; }
        }
    }
}
