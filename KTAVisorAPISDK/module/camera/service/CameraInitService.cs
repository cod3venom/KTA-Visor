using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.repository;
using KTAVisorAPISDK.Shared.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.service
{
    public class CameraInitService
    {
        private readonly CameraInitRepository cameraInitRepository;

        public CameraInitService()
        {
            this.cameraInitRepository = new CameraInitRepository();
        }

        public async Task<CameraEntity> init(InitCameraRequestTObject request)
        {
            HttpResponseMessage result = await this.cameraInitRepository.init(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity camera = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return camera;
        }
    }
}
