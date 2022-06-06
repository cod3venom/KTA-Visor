using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
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
        public  static USBCameraDevice convertDeviceToFalconCamera(DriveInfo device)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(device + @"\DCIM\100MEDIA\");
            if (directoryInfo.Exists) return new USBCameraDevice(device);

            return null;
        }
    }
}
