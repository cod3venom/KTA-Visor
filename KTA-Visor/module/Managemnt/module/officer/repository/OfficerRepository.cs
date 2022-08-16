using KTA_Visor.kernel.sharedKernel.util;
using KTA_Visor.module.Managemnt.module.officer.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.officer.repository
{
    public class OfficerRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/me/officers");
        }

        public async Task<HttpResponseMessage> create(CreateOfficerRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/me/officers", payload);
        }

        public async Task<HttpResponseMessage> edit(EditOfficerRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT("/api/me/officers", payload);
        }
    }
}
