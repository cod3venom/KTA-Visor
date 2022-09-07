using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.station.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.station.repository
{
    public class StationRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/stations");
        }

        public async Task<HttpResponseMessage> findById(string id)
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/stations/" + id);
        }

        public async Task<HttpResponseMessage> findByCustomId(string customId)
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/stations/customId/" + customId);
        }
        
        public async Task<HttpResponseMessage> findByIp(string ip)
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/stations/ip/" + ip);
        }

        public async Task<HttpResponseMessage> create(CreateStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/hidden/stations", payload);
        }

        public async Task<HttpResponseMessage> addActiveCamerasToStation(string id, AddActiveCameraToStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT(string.Format("/api/hidden/stations/{0}/active-cameras", id), payload);
        }

        public async Task<HttpResponseMessage> edit(string id, EditStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT("/api/hidden/stations/" + id, payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<HttpResponseMessage> delete(string id)
        {
            HttpResponseMessage response = await HttpClientUtil.securedClient.DELETE("/api/hidden/stations/" + id);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Unable to remeove file");
            }

            return response;
        }
    }
}
