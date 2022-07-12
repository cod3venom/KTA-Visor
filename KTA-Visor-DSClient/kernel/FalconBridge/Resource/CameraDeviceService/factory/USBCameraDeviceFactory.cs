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
        public static USBCameraDevice create(string driveLetter, string serialNumber)
        {

            return new USBCameraDevice(new DriveInfo(driveLetter), serialNumber);
        }

        public static USBCameraDevice create(DriveInfo driveInfo, string serialNumber)
        {

            return new USBCameraDevice(driveInfo, serialNumber);
        }

        public static USBCameraDevice create(DriveInfo driveInfo)
        {
            return new USBCameraDevice(driveInfo, "");
        }

        public static USBCameraDevice create(string serialNumber)
        {
            return new USBCameraDevice(serialNumber);
        }
    }
}
