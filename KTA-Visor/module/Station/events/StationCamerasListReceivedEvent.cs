using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Station.events
{
    public class StationCamerasListReceivedEvent: EventArgs
    {
        private readonly Dictionary<string, USBCameraDevice> cameras;

        public StationCamerasListReceivedEvent(Dictionary<string, USBCameraDevice> cameras)
        {
            this.cameras = cameras;
        }

        public Dictionary<string, USBCameraDevice> Cameras
        {
            get { return this.cameras; }
        }
    }
}
