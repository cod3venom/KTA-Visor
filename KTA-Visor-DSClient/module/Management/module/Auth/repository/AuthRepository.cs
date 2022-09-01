using KTA_Visor_DSClient.module.Management.module.Auth.dto.request;
using KTA_Visor_DSClient.module.Shared.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Auth.repository
{
    public class AuthRepository
    {
        public async Task<HttpResponseMessage> signIn(SignInRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/sign-in", payload);
        }

    }
}
