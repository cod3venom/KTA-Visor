using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice
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
            return this;
        }
    }
}
