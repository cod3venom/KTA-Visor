using KTA_Visor_UI.component.custom.SideBar.components;
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
    public partial class LabelsListBar : UserControl
    {
        private List<SidebarMenuItem> menuItems;
        public LabelsListBar()
        {
            InitializeComponent();

            this.menuItems = new List<SidebarMenuItem>();
        }

        public List<SidebarMenuItem> MenuItems
        {
            get { return menuItems; }
        }

        public void add(SidebarMenuItem menuItem)
        {
            this.menuItems.Add(menuItem);
        }

        public void load()
        {
            foreach (SidebarMenuItem menuItem in this.menuItems)
            {
                menuItem.Dock = DockStyle.Top;

                if (this.menuPanel.Controls.Contains(menuItem)) continue;
                
                this.Invoke((MethodInvoker)delegate
                {
                    this.menuPanel.Controls.Add(menuItem);
                });
             }
        }
        private void SideBar_Load(object sender, EventArgs e)
        {
            this.load();
        }
    }
}
