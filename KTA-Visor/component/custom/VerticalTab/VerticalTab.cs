using KTA_Visor.component.custom.VerticalTab.components.MenuLink;
using KTA_Visor.component.custom.VerticalTab.components.MenuLink.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.component.custom.VerticalTab
{
    public partial class VerticalTab : UserControl
    {
        public event EventHandler<MenuLinkClickEvent> OnMenuLinkClick;

        private string[] links;

        public VerticalTab()
        {
            InitializeComponent();
            this.links = new string[] { };
        }

        public string[] Links 
        {
            get { return this.links; }
            set { this.links = value; }
        }

        private void VerticalTab_Load(object sender, EventArgs e)
        {

        }

        public void initialize()
        {
            foreach(string link in this.Links)
            {
                MenuLink menuLink = new MenuLink();
                menuLink.Label = link;
                menuLink.Dock = DockStyle.Top;
                menuLink.OnClick += MenuLink_OnClick;
                this.menuItemsListContainer.Controls.Add(menuLink);
            }
        }

        private void MenuLink_OnClick(object sender, components.MenuLink.events.MenuLinkClickEvent e)
        {
            this.OnMenuLinkClick(sender, e);
        }
    }
}
