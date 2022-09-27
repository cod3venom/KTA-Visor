using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.logger.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.logger.repository
{
    public class LoggerRepository
    {
        public async Task<HttpResponseMessage> findInRange(GetLogsInRangeRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/me/logs/in-range", payload);
        }

    }
}
