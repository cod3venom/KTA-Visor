using KTA_Visor.kernel.sharedKernel.util;
using KTA_Visor.module.Managemnt.module.camera.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.repository
{
    public class CameraRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/me/cameras");
        }

        public async Task<HttpResponseMessage> findById(string id)
        {
            return await HttpClientUtil.securedClient.GET("/api/me/cameras/"+id);
        }

        public async Task<HttpResponseMessage> create(CreateCameraRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/me/cameras", payload);
        }

        public async Task<HttpResponseMessage> edit(string id, EditCameraRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT("/api/me/cameras/" + id, payload);
        }
        
        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.securedClient.DELETE("/api/me/cameras/" + id);
        }
    }
}
