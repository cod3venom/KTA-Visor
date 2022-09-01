using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge
{
    public class FalconBridge : AbstractResource
    {
        public FalconBridge(DeviceWatcher deviceWatcher, KTALogger.Logger logger):base(deviceWatcher, logger)
        {
            
        }
 
    }
}
