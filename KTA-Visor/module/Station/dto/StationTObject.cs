using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.types;

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

        public TCPClientTObject Client
        { get; set; }

        public string ToString()
        {
            return new StringBuilder()
                  .Append("<StationTObject: ")
                  .Append("ID: " + this.ID.ToString())
                  .Append(", IP Address: " + this.IpAddress)
                  .Append(", Name: " + this.Name)
                  .Append(", Total Ports: " + this.TotalPorts.ToString())
                  .Append(", Status: " + this.Status)
                  .Append(", Client: " + this.Client)
                  .Append("/>")
                  .ToString();
        }
    }
}
