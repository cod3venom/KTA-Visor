using KTA_Visor_DSClient.module.Management.module.repository.service;
using KTA_Visor_DSClient.module.Management.module.Station.bootloader;
using KTA_Visor_DSClient.module.Management.module.Station.dto.request;
using KTA_Visor_DSClient.module.Management.module.Station.entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Station.service
{
    public class StationService
    {
        public StationBootLoader StationBootLoader;
        private readonly StationRepository stationRepository;

        public StationService()
        {
            this.stationRepository = new StationRepository();
            this.StationBootLoader = new StationBootLoader();
        }

        public async Task<StationEntity> findStationById(string stationId, RemoveInactiveCameraToStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.findStationById(stationId);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity stationEntity = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return stationEntity;
        }

        public async Task<StationEntity> create( CreateStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity stationEntity = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return stationEntity;
        }

        public async Task<StationEntity> addActiveCamerasToStation(string stationId, AddActiveCameraToStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.addActiveCamerasToStation(stationId, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity stationEntity = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return stationEntity;
        }

        public async Task<StationEntity> removeInctiveCamerasToStation(string stationId, RemoveInactiveCameraToStationRequestTObject request)
        {
            HttpResponseMessage result = await this.stationRepository.removeInactiveCamerasFromStation(stationId, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            StationEntity stationEntity = JsonConvert.DeserializeObject<StationEntity>(responseBody);

            return stationEntity;
        }

    }
}
