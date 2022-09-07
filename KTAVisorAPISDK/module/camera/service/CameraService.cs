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
    public class CameraService
    {
        private readonly CameraRepository cameraRepository;

        public CameraService()
        {
            this.cameraRepository = new CameraRepository();
        }


        public async Task<CameraEntity> all()
        {
            HttpResponseMessage result = await this.cameraRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity cameras = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return cameras;
        }

        public async Task<CameraEntity> findById(string id)
        {
            HttpResponseMessage result = await this.cameraRepository.findById(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity camera = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return camera;
        }

        public async Task<CameraEntity> findByStationId(string stationId)
        {
            HttpResponseMessage result = await this.cameraRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity cameras = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return cameras;
        }

        public async Task<CameraEntity> create(CreateCameraRequestTObject request)
        {
            HttpResponseMessage result = await this.cameraRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity camera = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return camera;
        }


        public async Task<CameraEntity> edit(string id, EditCameraRequestTObject request)
        {
            HttpResponseMessage result = await this.cameraRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            CameraEntity camera = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

            return camera;
        }

        public async Task<HttpResponseMessage> delete(string id)
        {
            HttpResponseMessage response = await this.cameraRepository.delete(id);

            if (response.StatusCode!= System.Net.HttpStatusCode.OK)
            {
                throw new UnableToRemoveRecordException();
            }

            return response;
        }

    }
}
