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
    public class CameraBackendInit : ICameraHandler
    {
        private readonly CameraInitService _cameraInitService;
        private readonly StationInitializer _stationInitializer;
        private USBCameraDevice _camera;

        public CameraBackendInit()
        {
            this._cameraInitService = new CameraInitService();
            this._stationInitializer = new StationInitializer();
        }
 
        public void Handle(USBCameraDevice camera)
        {
            this._camera = camera;
            this.init();
        }
 
        private async void init()
        {

            if (Globals.STATION == null){
                 this._stationInitializer.init();
            }

            CameraEntity camera = await this._cameraInitService.init(new InitCameraRequestTObject(
                this._camera.ID,
                this._camera?.MarkerId,
                this._camera?.CustomId,
                this._camera?.BadgeId,
                this._camera?.CardId,
                Globals.STATION?.data?.stationId,
                this._camera?.Drive?.Name,
                this._camera.Active

            ));

            this._camera.ID = camera.data.id;
            this._camera.SaveSettings();
        }
 
    }
}
