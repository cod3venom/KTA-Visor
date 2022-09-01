using KTA_Visor_DSClient.module.Management.module.Station.dto.request;
using KTA_Visor_DSClient.module.Shared.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.repository.service
{
    public class StationRepository
    {

        public async Task<HttpResponseMessage> findStationById(string stationId)
        {
            return await HttpClientUtil.httpClient.GET(string.Format("/api/hidden/stations/{0}", stationId));
        }

        public async Task<HttpResponseMessage> create(CreateStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/hidden/stations", payload);
        }

        public async Task<HttpResponseMessage> addActiveCamerasToStation(string stationId, AddActiveCameraToStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.PUT(string.Format("/api/hidden/stations/{0}/active-cameras", stationId), payload);
        }

        public async Task<HttpResponseMessage> removeInactiveCamerasFromStation(string stationId, RemoveInactiveCameraToStationRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST(string.Format("/api/hidden/stations/{0}/inactive-cameras", stationId), payload);
        }
    }
}
