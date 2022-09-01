using KTA_Visor_DSClient.module.Management.module.Camera.dto;
using KTA_Visor_DSClient.module.Management.module.Camera.entity;
using KTA_Visor_DSClient.module.Management.module.Camera.repository;
using KTA_Visor_DSClient.module.Shared.Globals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraService
    {
        private readonly CameraRepository repository;

        public CameraService()
        {
            this.repository = new CameraRepository();
        }

        public async Task<CamerasEntity> all()
        {
            try
            {
                HttpResponseMessage result = await this.repository.all();
                string responseBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CamerasEntity>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }


        public async Task<CameraEntity> findById(string id)
        {
            try
            {
                HttpResponseMessage result = await this.repository.findById(id);
                string responseBody = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CameraEntity>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }

        public async Task<CameraEntity> create(CreateCameraRequestTObject request)
        {
            try
            {
                HttpResponseMessage result = await this.repository.create(request);
                string responseBody = await result.Content.ReadAsStringAsync();
                CameraEntity camera = JsonConvert.DeserializeObject<CameraEntity>(responseBody);

                Globals.BACKEND_CURRENT_CAMERAS.Add(camera);
                return camera;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }
        }
    }
}
