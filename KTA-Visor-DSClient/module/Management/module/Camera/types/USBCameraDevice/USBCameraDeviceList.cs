using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice
{
    public class USBCameraDeviceList<USBCameraDevice> : List<USBCameraDevice>
    {
        public USBCameraDeviceList(): base()
        {
            
        }

        public USBCameraDeviceList<USBCameraDevice> refresh()
        {
            this.loadCameras();

            return this;
        }

        public USBCameraDeviceList<USBCameraDevice> loadCameras()
        {
            return this;
        }
    }
}
