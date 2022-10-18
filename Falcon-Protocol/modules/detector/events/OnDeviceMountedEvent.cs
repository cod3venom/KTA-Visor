using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.modules.detector.events
{
    public class OnDeviceMountedEvent : EventArgs
    {
        public OnDeviceMountedEvent(string driveName)
        {
            this.Drive = new DriveInfo(driveName);
        }

        public DriveInfo Drive { get; set; }
    }
}
