using KTAVisorAPISDK.kernel.sharedKernel.util;
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
        public async Task<HttpResponseMessage> me()
        {
            return await HttpClientUtil.securedClient.GET("/api/me");
        }

    }
}
