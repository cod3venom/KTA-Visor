using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.service;
using System;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.memory
{
    public class AddCamerasToTheGlobalMemory
    {
        public static bool Execute(USBCameraDevice camera, ClientTunnel client)
        {

             
            if (Globals.CAMERAS_LIST.Count == 0)
            {
                Globals.CAMERAS_LIST.Add(camera);
                camera.Index = Globals.CAMERAS_LIST.Count;

                AddCamerasToTheGlobalMemory.storeOnBackendAsActive(camera, client);
                return true;
            }
            
            foreach(USBCameraDevice existedCamera in Globals.CAMERAS_LIST)
            {
                if ((existedCamera.Drive == camera.Drive) && (existedCamera.BadgeId == camera.BadgeId))
                    continue;
 
                Globals.CAMERAS_LIST.Add((camera));
                camera.Index = Globals.CAMERAS_LIST.Count;

                AddCamerasToTheGlobalMemory.storeOnBackendAsActive(camera, client);
                Globals.Logger.success(String.Format("Successfully Added Camera {0} from the global CAMERAS_LIST", camera.BadgeId));

                return true;
            }

            return false;
        }

        private static void storeOnBackendAsActive(USBCameraDevice camera, ClientTunnel client)
        {
            _ = new CameraService().create(new CreateCameraRequestTObject(
                  camera.Index,
                  camera.ID,
                  Globals.STATION.data.stationId,
                  camera.BadgeId
              ));

            client.Emit(new Request(
                "response://cameras/refresh"    
            ));
            
        }
    }
}
