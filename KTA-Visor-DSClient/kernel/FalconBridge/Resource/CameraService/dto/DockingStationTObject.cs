using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.dto
{
    public class DockingStationTObject
    {
        public DockingStationTObject(string IpAddress = "",  int totalPorts = 8, string status = "",  USBCameraDevice[] cameras = null)
        {
            this.IpAddress = IpAddress;
            this.TotalPorts = totalPorts;
            this.Status = status;
            this.Cameras = cameras;
        }

        public string IpAddress{ get; set; }

        public string Name
        {
            get { return "Docking Station #" + this.IpAddress; }
            set { this.IpAddress = value; }
        }

        public int TotalPorts
        { get; set; }


        public string Status
        { get; set; }


        public USBCameraDevice[] Cameras 
        { get; set; }

        public Dictionary<string, object> asDict()
        {
            Dictionary<string, object> stationDict = new Dictionary<string, object>();
            stationDict.Add("ipAddress", this.IpAddress);
            stationDict.Add("name", this.Name);
            stationDict.Add("totalPorts", this.TotalPorts.ToString());
            stationDict.Add("status", this.Status);
            stationDict.Add("cameras", this.Cameras);

            return stationDict;
        }
    }
}
