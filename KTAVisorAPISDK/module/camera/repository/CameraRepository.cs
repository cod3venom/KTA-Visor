using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.repository
{
    public class CameraRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/cameras");
        }

        public async Task<HttpResponseMessage> findById(string id)
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/cameras/"+id);
        }


        public async Task<HttpResponseMessage> findByStationId(string stationId)
        {
            return await HttpClientUtil.securedClient.GET(string.Format("/api/hidden/cameras/station/{0}", stationId));
        }

        public async Task<HttpResponseMessage> create(CreateCameraRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/hidden/cameras", payload);
        }

        public async Task<HttpResponseMessage> edit(string id, EditCameraRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT("/api/hidden/cameras/" + id, payload);
        }
        
        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.securedClient.DELETE("/api/hidden/cameras/" + id);
        }
    }
}
