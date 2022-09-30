using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.repository;
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
        private readonly UserRepository stationRepository;
        public UserService()
        {
            this.stationRepository = new UserRepository();
        }
        public async Task<UserEntity> me()
        {
            HttpResponseMessage result = await this.stationRepository.me();
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity stations = JsonConvert.DeserializeObject<UserEntity>(responseBody);

            return stations;
        }
         
    }
}
