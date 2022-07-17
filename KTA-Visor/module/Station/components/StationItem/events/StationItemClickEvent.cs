using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Station.components.StationItem.events
{
    public class StationItemClickEvent: EventArgs
    { 
        public StationItemClickEvent(StationItem item)
        {
            this.Item = item;
        }

        public StationItem Item { get; set; }
    }
}
