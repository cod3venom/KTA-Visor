using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.user.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.repository
{
    public class UserPasswordRecoveryRepository
    {
        public async Task<HttpResponseMessage> forgotPassword(ForgotPasswordRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/help/forgot-password", payload);
        }

        public async Task<HttpResponseMessage> verifyCode(VerifyUserPasswordRecoveryCodeRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/help/forgot-password/verify-code", payload);
        }

        public async Task<HttpResponseMessage> changePassword(UserPasswordRecoveryChangePasswordRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/help/forgot-password/change", payload);
        }
    }
}
