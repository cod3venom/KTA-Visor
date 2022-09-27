using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.fileHistory.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileHistory.repository
{
    public class FileHistoryFileWatcherRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.httpClient.GET("/api/hidden/file-history");
        }

        public async Task<HttpResponseMessage> findByid(string id)
        {
            return await HttpClientUtil.httpClient.GET(string.Format("/api/hidden/file-history/{0}", id));
        }

        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.httpClient.DELETE(string.Format("/api/hidden/file-history/{0}", id));
        }
    }
}
