using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice
{
    public class USBCameraDeviceList<T> : List<T>
    {
        public USBCameraDeviceList(): base()
        {
            
        }

        public USBCameraDeviceList<T> refresh()
        {
            this.loadCameras();

            return this;
        }

        public USBCameraDeviceList<T> loadCameras()
        {
            IEnumerable<DriveInfo> allDevices = ((IEnumerable<DriveInfo>)DriveInfo.GetDrives()).Where<DriveInfo>((Func<DriveInfo, bool>)(d => d.DriveType == DriveType.Removable && d.IsReady));

            foreach (DriveInfo device in allDevices)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(device + @"\DCIM\100MEDIA\");
                if (directoryInfo.Exists) continue ;

                
                USBCameraDevice camera = new USBCameraDevice(device);
                if (camera == null) continue;
            }

            return this;
        }

    }
}
