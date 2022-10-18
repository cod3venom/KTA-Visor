using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
using KTA_Visor_DSClient.module.Management.module.Station;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.memory
{
    public class CamerasGlobalMemoryHandler
    {
        private readonly CameraService cameraService;
        private readonly StationInitializer stationInitializer;

        public CamerasGlobalMemoryHandler(CameraService cameraService)
        {
            this.cameraService = new CameraService();
            this.stationInitializer = new StationInitializer();
        }

        public async Task<CameraEntity> Add(USBCameraDevice camera, ClientTunnel client)
        {

            USBCameraDevice existedCameraDevice = Globals.CAMERAS_LIST.Find((USBCameraDevice device) => (device.Drive?.Name == camera.Drive?.Name));

            if (existedCameraDevice == null)
            {
                camera.Index = Globals.CAMERAS_LIST.Count + 1;
                Globals.CAMERAS_LIST.Add(camera);
                Globals.Logger.success(String.Format("Successfully Added Camera {0} from the global CAMERAS_LIST", camera.BadgeId));

                return await this.createOnBackend(camera, client); ;
            }
            return null;
        }

        public async Task<CameraEntity> Remove(string badgeId, ClientTunnel client)
        {
            USBCameraDevice camera = Globals.CAMERAS_LIST.Find((USBCameraDevice device) => device.Drive?.Name == device.Drive?.Name);

            if (camera == null){
                return null;
            }

            Globals.CAMERAS_LIST.Remove(camera);
            Globals.Logger.success(String.Format("Successfully Removed Camera {0} from the global CAMERAS_LIST", camera.BadgeId));
            return await this.editOnBackend(camera, client);
        }


        private async Task<CameraEntity> createOnBackend(USBCameraDevice camera, ClientTunnel client = null)
        {
            if (Globals.STATION == null || Globals.STATION.data == null){
                _ = this.stationInitializer.Initialize();
            }

           return await this.cameraService.create(new CreateCameraRequestTObject(camera.Index, camera.ID, camera.BadgeId, "",
                Globals.STATION?.data?.stationId,
                camera.Drive?.Name
            ));

        }

        private async Task<CameraEntity> editOnBackend(USBCameraDevice camera, ClientTunnel client)
        {
            return await this.cameraService.editByCustomId(camera.ID, new EditCameraRequestTObject(camera.Index, camera.ID, camera.BadgeId, "",
                Globals.STATION.data.stationId,
                camera.Drive.Name,
                false
            ));

        }
    }
}
