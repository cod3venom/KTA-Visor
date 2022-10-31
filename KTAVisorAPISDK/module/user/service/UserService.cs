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
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public async Task<UserEntity> findUserById(int id)
        {
            HttpResponseMessage result = await this.userRepository.findUserById(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }

        public async Task<UserEntity> create(CreateUserRequestTObject request)
        {
            HttpResponseMessage result = await this.userRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }

        public async Task<UserEntity> edit(int id, EditUserRequestTObject request)
        {
            HttpResponseMessage result = await this.userRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }

        public async Task<dynamic> delete(int id)
        {
            HttpResponseMessage result = await this.userRepository.delete(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }
    }
}
