using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.controller
{
    public class CameraController
    {
        private readonly CameraService cameraService;

        private readonly CameraDeviceSettingsService cameraDeviceSettingsService;

        public CameraController()
        {
            this.cameraService = new CameraService();
            this.cameraDeviceSettingsService = new CameraDeviceSettingsService();
        }

        public void Watch(Request request)
        {
            switch(request.Endpoint)
            {
                case "command://cameras/all":
                    this.getAllCameras(request);
                    break;

                case "command://cameras/settings/change":
                    this.changeSettings(request);
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        private void getAllCameras(Request request)
        {
            CameraEntity entity = new CameraEntity();
            entity.datas = new List<CameraEntity.Camera>();
            Globals.CAMERAS_LIST.ToList().ForEach(async delegate (USBCameraDevice cameraDevice)
            {
                CameraEntity cameraEntity = await this.cameraService.findByCustomId(cameraDevice.ID);
                entity.datas.Add(cameraEntity.data);
            });

            request.Client.Send(new Request(
                "response://cameras/all",
                entity
            ));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        private async void changeSettings(Request request)
        {
            string json = JsonConvert.SerializeObject(request.Body).ToString();
            CameraEntity.Camera cameraEntityFromTunnel = JsonConvert.DeserializeObject<CameraEntity.Camera>(json);
            CameraEntity camera = await this.cameraService.findByCustomId(cameraEntityFromTunnel.cameraCustomId);

            this.cameraDeviceSettingsService.SetMenuConfig(camera.data);
        }

    }
}
