using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.Camera.component.CameraItem;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command
{
    public class RemoveCamerasFromTheGlobalMemory
    {
        public static bool Execute(string badgeId)
        {
            foreach(USBCameraDevice camera in Globals.CAMERAS_LIST)
            {
                if (camera.BadgeId == badgeId)
                {

                    Globals.CAMERAS_LIST.Remove(camera);

                    Program.logger.success(String.Format("Successfully Removed Camera {0} from the global CAMERAS_LIST", camera.BadgeId));
                    return true;
                }
                    
            }
            return false;
        }
    }
}
