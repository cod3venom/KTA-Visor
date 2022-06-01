using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device.dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.helpers
{
    public class CameraHelper
    {
        public  static CameraUSBDeviceTObject convertDeviceToFalconCamera(DriveInfo device)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(device + @"\DCIM\100MEDIA\");
            if (directoryInfo.Exists) return new CameraUSBDeviceTObject(device);

            return null;
        }
    }
}
