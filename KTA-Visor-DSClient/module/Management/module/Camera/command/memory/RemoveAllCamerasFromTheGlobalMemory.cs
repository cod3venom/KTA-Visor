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
    public class RemoveAllCamerasFromTheGlobalMemory
    {
        public static void Execute()
        {
            foreach(USBCameraDevice camera in Globals.CAMERAS_LIST)
            {
                Globals.CAMERAS_LIST.Remove(camera);
                RemoveAllCamerasFromTheGlobalMemory.storeOnBackendAsInActive(camera);

                Globals.Logger.success(String.Format(
                    "Successfully Removed Camera {0} from the global CAMERAS_LIST",
                    camera.BadgeId
                ));
            }
        }

        private static async void storeOnBackendAsInActive(USBCameraDevice camera)
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
        }
    }
}
