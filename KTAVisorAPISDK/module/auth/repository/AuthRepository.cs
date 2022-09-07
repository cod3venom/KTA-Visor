using KTAVisorAPISDK.module.auth.dto.request;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.auth.repository
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
