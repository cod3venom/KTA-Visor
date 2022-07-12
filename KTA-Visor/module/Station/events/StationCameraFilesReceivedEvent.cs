using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Station.events
{
    public class StationCameraFilesReceivedEvent : EventArgs
    {
        private readonly Dictionary<string, FileInfo> files;

        public StationCameraFilesReceivedEvent(Dictionary<string, FileInfo> files)
        {
            this.files = files;
        }

        public Dictionary<string, FileInfo> Files
        {
            get { return this.files; }
        }
    }
}
