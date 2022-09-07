using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Station.events
{
    public class OnStationCRUDEvent : EventArgs
    {

        public OnStationCRUDEvent(string stationId, string stationIpAddress)
        {
            this.stationId = stationId;
            this.stationIpAddress = stationIpAddress;
        }

        public string stationId { get; set; }
        public string stationIpAddress { get; set; }

        
    }
}
