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
    public class CameraController
    {
        private readonly CameraService cameraService;

        private readonly CameraDeviceSettingsService cameraDeviceSettingsService;

        private readonly CameraPowerService cameraPowerService;
        public CameraController()
        {
            this.cameraService = new CameraService();
            this.cameraDeviceSettingsService = new CameraDeviceSettingsService();
            this.cameraPowerService = new CameraPowerService();
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
            CameraEntity camera = await this.cameraService.findByCustomId(cameraEntityFromTunnel.cameraCustomId);

            this.cameraDeviceSettingsService.AssignValues(camera.data);
            this.cameraDeviceSettingsService.SaveSettings();
        }

        private void onBlinkCamera(Request request)
        {
            string json = JsonConvert.SerializeObject(request.Body).ToString();
            CameraEntity cameraEntityFromTunnel = JsonConvert.DeserializeObject<CameraEntity>(json);
            this.cameraPowerService.Blink(cameraEntityFromTunnel);
        }
    }
}
