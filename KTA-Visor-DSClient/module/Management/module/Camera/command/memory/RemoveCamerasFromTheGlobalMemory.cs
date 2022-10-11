using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using System;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.memory
{
    public class RemoveCamerasFromTheGlobalMemory
    {
        public static bool Execute(string badgeId, ClientTunnel client)
        {
            foreach(USBCameraDevice camera in Globals.CAMERAS_LIST)
            {
                if (camera.BadgeId == badgeId)
                {

                    Globals.CAMERAS_LIST.Remove(camera);
                    RemoveCamerasFromTheGlobalMemory.storeOnBackendAsInActive(camera, client);

                    Globals.Logger.success(String.Format(
                        "Successfully Removed Camera {0} from the global CAMERAS_LIST",
                        camera.BadgeId
                    ));
                    return true;
                }
                    
            }
            return false;
        }

        private static async void storeOnBackendAsInActive(USBCameraDevice camera, ClientTunnel client)
        {
            CameraService service = new CameraService();
            CameraEntity cameraEntity = await service.findByBadgeId(camera.BadgeId);
            _ = new CameraService().edit(cameraEntity?.data?.id, new EditCameraRequestTObject(
                  camera.Index,
                  camera.ID,
                  camera.BadgeId,
                  "",
                  Globals.STATION.data.stationId,
                  camera.Drive.Name,
                  false
            ));

            if (client == null)
                return;

            client.Emit(new Request(
               "response://cameras/refresh"
           ));
        }
    }
}
