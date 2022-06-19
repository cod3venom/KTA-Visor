using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Station.dto
{
    public class StationTObject
    {
        public int ID
        { get; set; }

        public string IpAddress
        { get; set; }

        public string Name
        { get; set; }

        public int TotalPorts
        { get; set; }
        
        public string Status
        { get; set; }

    }
}
