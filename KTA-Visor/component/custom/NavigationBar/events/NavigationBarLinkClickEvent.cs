using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.component.custom.NavigationBar.events
{
    public class NavigationBarLinkClickEvent: EventArgs
    {
        private string linkName;

        public NavigationBarLinkClickEvent(string linkName)
        {
            this.linkName = linkName;
        }

        public string getLinkName()
        {
            return this.linkName;
        }
    }
}
