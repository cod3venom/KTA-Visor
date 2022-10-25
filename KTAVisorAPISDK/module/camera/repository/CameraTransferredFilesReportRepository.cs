using KTAVisorAPISDK.kernel.sharedKernel.util;
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
    public class CameraTransferredFilesReportEntity
    {
        public async Task<HttpResponseMessage> create(CreateCameraTransferredFileReportRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/hidden/cameras/transferred-files/report", payload);
        }

    }
}
