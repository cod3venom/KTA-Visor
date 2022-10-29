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
    public class CameraSyncService
    {
        private readonly CameraSyncRepository cameraSyncRepository;

        public CameraSyncService()
        {
            this.cameraSyncRepository = new CameraSyncRepository();
        }

        public async Task<CameraEntity> sync(SyncCamerasRequestTObject request)
        {
            HttpResponseMessage result = await this.cameraSyncRepository.sync(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity camera = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return camera;
        }
    }
}
