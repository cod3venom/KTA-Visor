using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
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
    public class MyUserService
    {
        private readonly MyUserRepository userRepository;

        public MyUserService()
        {
            this.userRepository = new MyUserRepository();
        }

        public async Task<UserEntity> me()
        {
            HttpResponseMessage result = await this.userRepository.me();
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }

        public async Task<UserEntity> edit(EditUserRequestTObject request)
        {
            HttpResponseMessage result = await this.userRepository.edit(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }
    }
}
