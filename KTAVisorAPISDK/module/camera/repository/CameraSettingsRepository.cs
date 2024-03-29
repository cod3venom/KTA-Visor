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
    public class CameraSettingsRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/cameras");
        }

        public async Task<HttpResponseMessage> findById(int id)
        {
            return await HttpClientUtil.securedClient.GET("/api/hidden/cameras/{id}/settings"+id);
        }

        public async Task<HttpResponseMessage> create(int id, CreateCameraSettingsTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST(String.Format("/api/hidden/cameras/{0}/settings", id), payload);
        }

        public async Task<HttpResponseMessage> edit(int id, EditCameraSettingsTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT(String.Format("/api/hidden/cameras/{0}/settings", id), payload);
        }

    }
}
