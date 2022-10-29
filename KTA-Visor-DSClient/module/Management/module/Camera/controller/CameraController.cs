using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.controller
{
    public class CameraController : IControllerInterface
    {
        private readonly CameraService _cameraService;
        private readonly CameraDeviceSettingsService _cameraDeviceSettingsService;
        private readonly service.CameraCardService _cameraPowerService;

        public CameraController()
        {
            this._cameraService = new CameraService();
            this._cameraDeviceSettingsService = new CameraDeviceSettingsService();
            this._cameraPowerService = new service.CameraCardService();
        }

        public void Watch(Request request)
        {
            switch(request.Endpoint)
            {
                case "command://cameras/settings/change":
                    this.onChangeSettings(request);
                    break;

                case "command://cameras/card/blink":
                    this.onBlinkCamera(request);
                    break;
            }
        }
 

        private async void onChangeSettings(Request request)
        {
            string json = JsonConvert.SerializeObject(request.Body).ToString();
            CameraEntity.Camera cameraEntityFromTunnel = JsonConvert.DeserializeObject<CameraEntity.Camera>(json);
            CameraEntity camera = await this._cameraService.findByCustomId(cameraEntityFromTunnel.cameraCustomId);

            this._cameraDeviceSettingsService.SaveSettings(camera.data);
        }

        private void onBlinkCamera(Request request)
        {
            string json = JsonConvert.SerializeObject(request.Body).ToString();
            CameraEntity cameraEntityFromTunnel = JsonConvert.DeserializeObject<CameraEntity>(json);
            this._cameraPowerService.Blink(cameraEntityFromTunnel);
        }
    }
}
