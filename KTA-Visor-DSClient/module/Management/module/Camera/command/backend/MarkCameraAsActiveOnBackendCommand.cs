using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.backend
{
    public class MarkCameraAsActiveOnBackendCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        /// <returns></returns>
        public static async  Task<bool> Execute(USBCameraDevice camera)
        {
            try
            {

                CameraService cameraService = new CameraService();
                StationService stationService = new StationService();

                CameraEntity cameraEntity = await cameraService.create(new CreateCameraRequestTObject(
                    camera.Index,
                    camera.ID,
                    Globals.STATION.data.stationId,
                    camera.BadgeId,
                    camera.Drive.Name,
                    true
                ));

                if (cameraEntity.data.id == null){
                    throw new Exception("Nie udało się utworzyć kamerę");
                }

               
                AddActiveCameraToStationRequestTObject payload = new AddActiveCameraToStationRequestTObject(
                     new List<string>() { cameraEntity.data.id }
                );

                Globals.STATION = await stationService.addActiveCamerasToStation(
                    Globals.STATION?.data?.id,
                    payload
                );
                return true;
            }
            catch (Exception ex)
            {
                Program.logger.error(ex.Message);
                return false;
            }
        }
    }
}
