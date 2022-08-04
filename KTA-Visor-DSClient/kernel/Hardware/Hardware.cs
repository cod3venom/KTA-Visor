using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
namespace KTA_Visor_DSClient.kernel.Hardware
{
    public class Hardware
    {
        public DeviceWatcher.DeviceWatcher deviceWatcher()
        {
            return new DeviceWatcher.DeviceWatcher();
        }

        public USBDeviceRelay.USBDeviceRelay Relay()
        { 
            return new USBDeviceRelay.USBDeviceRelay();
        }
    }
}
