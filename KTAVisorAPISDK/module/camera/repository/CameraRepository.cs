﻿using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.camera.dto.reques;
using KTAVisorAPISDK.module.camera.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.repository
{
    public class CameraRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/cameras");
        }

        public async Task<HttpResponseMessage> findById(int id)
        {
            return await HttpClientUtil.httpClient.GET("/api/hidden/cameras/"+id);
        }
        
        public async Task<HttpResponseMessage> findByCustomId(string customId)
        {
            return await HttpClientUtil.httpClient.GET(String.Format("/api/hidden/cameras/customid/{0}", customId));
        }

        public async Task<HttpResponseMessage> findByBadgeId(string badgeId)
        {
            return await HttpClientUtil.securedClient.GET(String.Format("/api/hidden/cameras/badgeid/{0}", badgeId));
        }

        public async Task<HttpResponseMessage> findByCardId(string cardID)
        {
            return await HttpClientUtil.securedClient.GET(String.Format("/api/hidden/cameras/cardid/{0}", cardID));
        }

        public async Task<HttpResponseMessage> findByStationId(string stationId)
        {
            return await HttpClientUtil.httpClient.GET(string.Format("/api/hidden/cameras/station/{0}", stationId));
        }

        public async Task<HttpResponseMessage> edit(int id, EditCameraRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.PUT("/api/hidden/cameras/" + id, payload);
        }

        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.httpClient.DELETE("/api/hidden/cameras/" + id);
        }
    }
}
