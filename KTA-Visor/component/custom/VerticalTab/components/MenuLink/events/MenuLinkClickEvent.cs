using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.component.custom.VerticalTab.components.MenuLink.events
{
    public class MenuLinkClickEvent : EventArgs
    {
        private string link;

        public MenuLinkClickEvent(string link)
        {
            this.link = link;
        }

        public string getLink()
        {
            return this.link;
        }
    }
}
