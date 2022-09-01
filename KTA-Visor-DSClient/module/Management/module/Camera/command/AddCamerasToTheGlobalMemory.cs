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
    public class AddCamerasToTheGlobalMemory
    {
        public static bool Execute(USBCameraDevice camera)
        {
            if (Globals.CAMERAS_LIST.Count == 0)
            {

                Globals.CAMERAS_LIST.Add(camera);
                return true;
            }
            
            foreach(USBCameraDevice existedCamera in Globals.CAMERAS_LIST)
            {
                if ((existedCamera.Drive == camera.Drive) && (existedCamera.BadgeId == camera.BadgeId))
                    continue;
 
                Globals.CAMERAS_LIST.Add((camera));
                Program.logger.success(String.Format("Successfully Added Camera {0} from the global CAMERAS_LIST", camera.BadgeId));

                return true;
            }

            return false;
        }
    }
}
