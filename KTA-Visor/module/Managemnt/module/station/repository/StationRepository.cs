using KTA_Visor.kernel.sharedKernel.util;
using KTA_Visor.module.Managemnt.module.station.dto;
using KTA_Visor.module.Shared.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.station.repository
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

        public async Task<HttpResponseMessage> create(CreateStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/hidden/stations", payload);
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
                throw new UnableToRemoveRecordException();
            }

            return response;
        }
    }
}
