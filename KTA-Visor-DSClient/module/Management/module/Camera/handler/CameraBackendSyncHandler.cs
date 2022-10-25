using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
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
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.handler
{
    public class CameraBackendSyncHandler : ICameraHandler
    {
        private readonly CameraService _cameraService;
        private readonly StationInitializer _stationInitializer;
        private USBCameraDevice _camera;

        public CameraBackendSyncHandler()
        {
            this._cameraService = new CameraService();
            this._stationInitializer = new StationInitializer();
        }
 
        public void Handle(USBCameraDevice camera)
        {
            this._camera = camera;
            this.sync();
        }
 
        private async void sync()
        {

            if (Globals.STATION == null || Globals.STATION.data == null){
                 this._stationInitializer.init();
            }

            bool exists = await this.isCameraAlreadyRegistered();
            if (!exists){
                this.register();
            } else {
                this.update();
            }
        }

        private async Task<bool> isCameraAlreadyRegistered()
        {
            CameraEntity cameraEntity = await this._cameraService.findByCustomId(this._camera.ID);
            return cameraEntity.data != null;
        }

        private async void register()
        {
            var request = new CreateCameraRequestTObject(
                this._camera.Index,
                this._camera.ID,
                this._camera.BadgeId, "",
                Globals.STATION?.data?.stationId,
                this._camera.Drive?.Name
            );
           CameraEntity cameraEntity =  await this._cameraService.create(request);
        }

        private async void update()
        {
            var request = new EditCameraRequestTObject(
                this._camera.Index,
                this._camera.ID,
                this._camera.BadgeId,
                "",
                Globals.STATION.data.stationId,
                this._camera.Drive.Name,
                this._camera.Active
            );
           CameraEntity cameraEntity = await this._cameraService.editByCustomId(this._camera.ID, request);
        }
    }
}
