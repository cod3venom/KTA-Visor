using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.user.dto.request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.repository
{
    public class UserRepository
    {
        public async Task<HttpResponseMessage> findUserById(int id)
        {
            return await HttpClientUtil.securedClient.GET(String.Format("/api/user/{0}", id.ToString()));
        }

        public async Task<HttpResponseMessage> create(CreateUserRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.POST("/api/user/create", payload);
        }

        public async Task<HttpResponseMessage> edit(int id, EditUserRequestTObject request)
        {
            string payload = JsonConvert.SerializeObject(request);
            return await HttpClientUtil.securedClient.PUT(String.Format("/api/user/edit/{0}", id.ToString()), payload);
        }

        public async Task<HttpResponseMessage> delete(int id)
        {
            return await HttpClientUtil.securedClient.DELETE(String.Format("/api/user/delete/{0}", id.ToString()));
        }
    }
}
