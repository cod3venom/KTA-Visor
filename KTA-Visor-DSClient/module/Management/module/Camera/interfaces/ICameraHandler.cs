using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.interfaces
{
    public interface ICameraHandler
    {
        void Handle(USBCameraDevice camera);
    }
}
