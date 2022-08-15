using KTA_Visor.kernel.sharedKernel.util;
using KTA_Visor.module.Managemnt.module.auth.dto.request;
using KTA_Visor.module.Managemnt.module.auth.entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.auth.repository
{
    public class AuthRepository
    {
         
        public AuthRepository()
        {
            
        }

        public async Task<HttpResponseMessage> signUp(SignUpRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/sign-up", payload);
        }

        public async Task<HttpResponseMessage> signIn(SignInRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/sign-in", payload);
        }
    }
}
