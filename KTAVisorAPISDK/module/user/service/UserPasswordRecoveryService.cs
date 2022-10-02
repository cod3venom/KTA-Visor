using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.dto.response;
using KTAVisorAPISDK.module.user.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.service
{
    public class UserPasswordRecoveryService
    {
        private readonly UserPasswordRecoveryRepository userPasswordRecoveryRepository;
        public UserPasswordRecoveryService()
        {
            this.userPasswordRecoveryRepository = new UserPasswordRecoveryRepository();
        }

        public async Task<UserForgotPasswordResponseTObject> forgotPassword(ForgotPasswordRequestTObject dto)
        {
            HttpResponseMessage result = await this.userPasswordRecoveryRepository.forgotPassword(dto);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserForgotPasswordResponseTObject response = JsonConvert.DeserializeObject<UserForgotPasswordResponseTObject>(responseBody);

            return response;
        }


        public async Task<VerifyUserPasswordRecoveryCodeResponseTObject> verifyCode(VerifyUserPasswordRecoveryCodeRequestTObject dto)
        {
            HttpResponseMessage result = await this.userPasswordRecoveryRepository.verifyCode(dto);
            string responseBody = await result.Content.ReadAsStringAsync();
            VerifyUserPasswordRecoveryCodeResponseTObject response = JsonConvert.DeserializeObject<VerifyUserPasswordRecoveryCodeResponseTObject>(responseBody);

            return response;
        }

        public async Task<UserPasswordRecoveryChangePasswordResponseTObject> changePassword(UserPasswordRecoveryChangePasswordRequestTObject dto)
        {
            HttpResponseMessage result = await this.userPasswordRecoveryRepository.changePassword(dto);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserPasswordRecoveryChangePasswordResponseTObject response = JsonConvert.DeserializeObject<UserPasswordRecoveryChangePasswordResponseTObject>(responseBody);

            return response;
        }
    }
}
