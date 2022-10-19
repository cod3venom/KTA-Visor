using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.factory
{
    public class USBCameraDeviceFactory
    {
        public static USBCameraDevice create(string driveLetter, int index = 0)
        {

            return new USBCameraDevice(new DriveInfo(driveLetter), index);
        }

        public static USBCameraDevice create(DriveInfo driveInfo, string serialNumber, int index = 0)
        {

            return new USBCameraDevice(driveInfo, serialNumber, index);
        }
 
    }
}
