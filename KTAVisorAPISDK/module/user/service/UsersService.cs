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
    public class UsersService
    {
        private readonly UsersRepository usersRepository;

        public UsersService()
        {
            this.usersRepository = new UsersRepository();
        }

        public async Task<UserEntity> allUsers(string[] parameters = null)
        {
            HttpResponseMessage result = await this.usersRepository.allUsers(parameters);
            string responseBody = await result.Content.ReadAsStringAsync();
            UserEntity user = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return user;
        }
    }
}
