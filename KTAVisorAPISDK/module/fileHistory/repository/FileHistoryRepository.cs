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
    public class FileHistoryRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/me/file-history");
        }

        public async Task<HttpResponseMessage> findByid(string id)
        {
            return await HttpClientUtil.securedClient.GET(string.Format("/api/me/file-history/{0}", id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> create(CreateFileHistoryRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/hidden/file-history", payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> edit(string id, EditFileHistoryRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT(string.Format("/api/me/file-history/{0}", id), payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.securedClient.DELETE(string.Format("/api/me/file-history/{0}", id));
        }
    }
}
