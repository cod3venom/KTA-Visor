using KTA_Visor.module.Managemnt.module.station.dto;
using KTA_Visor.module.Managemnt.module.station.entity;
using KTA_Visor.module.Managemnt.module.station.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.station.service
{
    public class StationService
    {
        private readonly StationRepository stationRepository;
        public StationService()
        {
            this.stationRepository = new StationRepository();
        }
        public async Task<StationsEntity> all()
        {
            HttpResponseMessage result = await this.stationRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            StationsEntity stations = JsonConvert.DeserializeObject<StationsEntity>(responseBody);

            return stations;
        }

        public async Task<StationEntity> findById(string id)
        {
            HttpResponseMessage result = await this.stationRepository.findById(id);
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
                MessageBox.Show(ex.Message);
            }

        }
    }
}
