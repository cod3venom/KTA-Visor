using KTA_Visor.module.Managemnt.module.camera.dto.request;
using KTA_Visor.module.Managemnt.module.camera.entity;
using KTA_Visor.module.Managemnt.module.camera.repository;
using KTA_Visor.module.Shared.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.service
{
    public class CameraService
    {
        private readonly CameraRepository cameraRepository;

        public CameraService()
        {
            this.cameraRepository = new CameraRepository();
        }


        public async Task<CamerasEntity> all()
        {
            HttpResponseMessage result = await this.cameraRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            CamerasEntity cameras = JsonConvert.DeserializeObject<CamerasEntity>(responseBody);

            return cameras;
        }

        public async Task<CameraEntity> findById(string id)
        {
            HttpResponseMessage result = await this.cameraRepository.findById(id);
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
