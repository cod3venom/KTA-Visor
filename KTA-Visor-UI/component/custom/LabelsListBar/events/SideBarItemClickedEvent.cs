using KTA_Visor_UI.component.custom.SideBar.components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.custom.Sidebar.events
{
    public class SideBarItemClickedEvent
    {
        private readonly SidebarMenuItem _item;

        public SideBarItemClickedEvent(SidebarMenuItem item)
        {
            this._item = item;
        }

        public SidebarMenuItem Item
        {
            get { return _item; }
        }
    }
}
