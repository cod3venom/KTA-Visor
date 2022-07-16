using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.topbar.events
{
    public class TopBarToggleEvent : EventArgs
    {
        
        public TopBarToggleEvent(bool show)
        {
            this.Show = show;
        }

        public bool Show { get; set; }
    }
}
