using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USBKitcs;
using USBKitcs.Main;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.repository
{
    public class CameraServiceRepository
    {
        public List<UsbRegistry> allVisionDevices()
        {
            return UsbDevice.AllLibUsbDevices.ToList();
        }
    }
}
