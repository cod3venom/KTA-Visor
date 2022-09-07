using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.officer.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.officer.repository
{
    public class OfficerRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/me/officers");
        }

        public async Task<HttpResponseMessage> findById(string id)
        {
            return await HttpClientUtil.securedClient.GET("/api/me/officers/"+id);
        }

        public async Task<HttpResponseMessage> create(CreateOfficerRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/me/officers", payload);
        }

        public async Task<HttpResponseMessage> edit(string id, EditOfficerRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT("/api/me/officers/"+id, payload);
        }
        
        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.securedClient.DELETE("/api/me/officers/"+id);
        }
    }
}
