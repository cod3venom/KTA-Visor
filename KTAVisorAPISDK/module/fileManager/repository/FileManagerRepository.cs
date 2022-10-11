using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.fileManager.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileManager.repository
{
    public class FileManagerRepository
    {
        public async Task<HttpResponseMessage> all()
        {
            return await HttpClientUtil.securedClient.GET("/api/me/file-manager");
        }

        public async Task<HttpResponseMessage> findByid(string id)
        {
            return await HttpClientUtil.securedClient.GET(string.Format("/api/me/file-manager/{0}", id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> create(CreateFileHistoryRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.httpClient.POST("/api/hidden/file-manager", payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> edit(string id, EditFileHistoryRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT(string.Format("/api/me/file-manager/{0}", id), payload);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> delete(string id)
        {
            return await HttpClientUtil.securedClient.DELETE(string.Format("/api/me/file-manager/{0}", id));
        }
    }
}
