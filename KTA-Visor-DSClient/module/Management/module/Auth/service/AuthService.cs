using KTA_Visor_DSClient.module.Management.module.auth.entity;
using KTA_Visor_DSClient.module.Management.module.Auth.command;
using KTA_Visor_DSClient.module.Management.module.Auth.dto.request;
using KTA_Visor_DSClient.module.Management.module.Auth.exception;
using KTA_Visor_DSClient.module.Management.module.Auth.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Auth.service
{
    public class AuthService
    {
        private readonly AuthRepository authRepository;

        public AuthService()
        {
            this.authRepository = new AuthRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<SignInEntity> signIn(SignInRequestTObject request)
        {
            try
            {
                HttpResponseMessage result = await this.authRepository.signIn(request);
                string responseBody = await result.Content.ReadAsStringAsync();
                SignInEntity sisgnIn = JsonConvert.DeserializeObject<SignInEntity>(responseBody);

                if (sisgnIn == null || sisgnIn?.data?.jwt == null)
                {
                    throw new WrongCredentialsException("Unable to sign-in, please try later");
                }

                SaveSessionCommand.Execute(sisgnIn.data.jwt);

                return sisgnIn;

            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong");
            }

        }
    }
}
