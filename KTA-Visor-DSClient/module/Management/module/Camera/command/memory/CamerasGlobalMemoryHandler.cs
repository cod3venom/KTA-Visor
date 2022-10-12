using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
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

        public CamerasGlobalMemoryHandler(CameraService cameraService)
        {
            this.cameraService = new CameraService();
        }

        public void Add(USBCameraDevice camera, ClientTunnel client)
        {

            USBCameraDevice existedCameraDevice = Globals.CAMERAS_LIST.Find(
                (USBCameraDevice device) => (device.Drive == camera.Drive) && (device.BadgeId == camera.BadgeId)
            );

            if (existedCameraDevice == null)
            {
                camera.Index = Globals.CAMERAS_LIST.Count + 1;
                Globals.CAMERAS_LIST.Add(camera);
                Globals.Logger.success(String.Format("Successfully Added Camera {0} from the global CAMERAS_LIST", camera.BadgeId));

                new Thread(() => this.createOnBackend(camera, client)).Start();
            }
        }

        public void Remove(string badgeId, ClientTunnel client)
        {
            USBCameraDevice camera = Globals.CAMERAS_LIST.Find((USBCameraDevice device) => device.BadgeId == badgeId);

            if (camera == null){
                return;
            }

            Globals.CAMERAS_LIST.Remove(camera);
            Globals.Logger.success(String.Format("Successfully Removed Camera {0} from the global CAMERAS_LIST", camera.BadgeId));
            new Thread(() => this.editOnBackend(camera, client)).Start();
        }


        private void createOnBackend(USBCameraDevice camera, ClientTunnel client = null)
        {
            _ = this.cameraService.create(new CreateCameraRequestTObject(camera.Index, camera.ID, camera.BadgeId,"",
                Globals.STATION.data.stationId,
                camera.Drive?.Name
             ));

            this.notifyMaster(client);
        }

        private async void editOnBackend(USBCameraDevice camera, ClientTunnel client)
        {
            var result = await this.cameraService.editByCustomId(camera.ID, new EditCameraRequestTObject(camera.Index, camera.ID, camera.BadgeId, "",
                Globals.STATION.data.stationId,
                camera.Drive.Name,
                false
            ));

            this.notifyMaster(client);
        }

        private void notifyMaster(ClientTunnel client)
        {
            if (client == null)
            {
                return;
            }

            client.Emit(new Request(
               "response://cameras/refresh",
               null,
               client.ClientObject
           ));
        }
    }
}
