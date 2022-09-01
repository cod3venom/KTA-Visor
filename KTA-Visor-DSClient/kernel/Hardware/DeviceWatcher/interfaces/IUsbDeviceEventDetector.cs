using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher.interfaces
{
    public interface IUsbDeviceEventDetector
    {
        event EventHandler<EventArgs> DeviceInsertedOrRemoved;

        event EventHandler<DriveChangedEventArgs> DriveInserted;

        event EventHandler<DriveChangedEventArgs> DriveRemoved;
    }
}
