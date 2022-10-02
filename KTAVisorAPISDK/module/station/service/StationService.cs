using KTAVisorAPISDK.module.station.dto;
using KTAVisorAPISDK.module.station.entity;
using KTAVisorAPISDK.module.station.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.service
{
    public class StationService
    {
        private readonly StationRepository stationRepository;
        public StationService()
        {
            this.stationRepository = new StationRepository();
        }
        public async Task<StationEntity> all()
        {
            HttpResponseMessage result = await this.stationRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity stations = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return stations;
        }

        public async Task<StationEntity> findById(string id)
        {
            HttpResponseMessage result = await this.stationRepository.findById(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }

        public async Task<StationEntity> findByStationId(string stationId)
        {
            return await this.findByCustomId(stationId);
        }

        public async Task<StationEntity> findByCustomId(string customId)
        {
            HttpResponseMessage result = await this.stationRepository.findByCustomId(customId);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }

        public async Task<StationEntity> findByIp(string ip)
        {
            HttpResponseMessage result = await this.stationRepository.findByIp(ip);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }

        public async Task<StationEntity> create(CreateStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }


        public async Task<StationEntity> addActiveCamerasToStation(string id, AddActiveCameraToStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.addActiveCamerasToStation(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }

  
        public async Task<StationEntity> deactivateAllCamerasFromTheStation(string id)
        {
            HttpResponseMessage result = await this.stationRepository.deactivateAllCamerasFromTheStation(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }


        public async Task<StationEntity> edit(string id, EditStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity station = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return station;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public async void delete(string id)
        {
            try
            {
                await this.stationRepository.delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
