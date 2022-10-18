using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.modules.detector.events
{
    public class OnDeviceRemoved : EventArgs
    {
        public OnDeviceRemoved(string driveName)
        {
            this.Drive = new DriveInfo(driveName);
        }

        public DriveInfo Drive { get; set; }
    }
}
