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
    public class CameraSettingsService
    {
        private readonly CameraSettingsRepository cameraSettingsRepository;

        public CameraSettingsService()
        {
            this.cameraSettingsRepository = new CameraSettingsRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cameraId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CameraSettingsEntity> create(int id, CreateCameraSettingsTObject request)
        {
            HttpResponseMessage result = await this.cameraSettingsRepository.create(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraSettingsEntity settings = JsonConvert.DeserializeObject<CameraSettingsEntity>(responseBody);

            return settings;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cameraId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CameraSettingsEntity> edit(int id, EditCameraSettingsTObject request)
        {
            HttpResponseMessage result = await this.cameraSettingsRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraSettingsEntity settings = JsonConvert.DeserializeObject<CameraSettingsEntity>(responseBody);

            return settings;
        }
    }
}
