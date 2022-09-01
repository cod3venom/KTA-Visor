using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.factory
{
    public class USBCameraDeviceFactory
    {
        public static USBCameraDevice create(string driveLetter)
        {

            return new USBCameraDevice(new DriveInfo(driveLetter));
        }

        public static USBCameraDevice create(DriveInfo driveInfo, string serialNumber)
        {

            return new USBCameraDevice(driveInfo, serialNumber);
        }
 
    }
}
