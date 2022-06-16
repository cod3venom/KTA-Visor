using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Station.components.events
{
    public class StationItemActionEvent : EventArgs
    {
        private int id;
        private string name;

        public StationItemActionEvent(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }
    }
}
