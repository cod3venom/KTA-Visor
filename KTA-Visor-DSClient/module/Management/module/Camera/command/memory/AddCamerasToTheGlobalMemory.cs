using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;



namespace KTA_Visor_DSClient.module.Management.module.Camera.command.memory
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
                Globals.Logger.success(String.Format("Successfully Added Camera {0} from the global CAMERAS_LIST", camera.BadgeId));

                return true;
            }

            return false;
        }
    }
}
