using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher.events
{
    public class DriveChangedEventArgs : EventArgs
    {
        internal readonly string Drive;

        internal DriveChangedEventArgs(string drive) => this.Drive = drive;
    }
}
