using KTA_Visor_DSClient.module.Management.module.Camera.dto;
using KTA_Visor_DSClient.module.Shared.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.repository
{
    public class CameraRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.httpClient.GET("/api/hidden/cameras");
        }

        public async Task<HttpResponseMessage> findById(string id)
        {
            return await HttpClientUtil.httpClient.GET(string.Format("/api/hidden/cameras/{0}", id));
        }


        public async Task<HttpResponseMessage> create(CreateCameraRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/hidden/cameras", payload);
        }
    }
}
