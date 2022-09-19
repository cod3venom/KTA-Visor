using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.backend
{
    public class MarkCameraAsInactiveOnBackendCommand
    {
        public static async  Task<bool> Execute(USBCameraDevice usbCamera)
        {
            try
            {

                CameraService cameraService = new CameraService();
                StationService stationService = new StationService();

                CameraEntity camera = await cameraService.findByCustomId(usbCamera.ID);
                CameraEntity cameraEntity = await cameraService.edit(camera.data.id, new EditCameraRequestTObject(
                    camera.data.index,
                    usbCamera.ID,
                    Globals.STATION.data.stationId,
                    usbCamera.BadgeId,
                    usbCamera.Drive.Name,
                    false
                ));

                if (cameraEntity.data.id == null)
                {
                    throw new Exception("Nie udało się uaktualizowac kamerę");
                }
                return true;
            }
            catch (Exception ex)
            {
                Globals.Logger.error(ex.Message);
                return false;
            }
        }
    }
}
