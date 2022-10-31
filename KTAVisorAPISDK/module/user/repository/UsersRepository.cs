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
    public class UsersRepository
    {
   
        public async Task<HttpResponseMessage> allUsers(string[] parameters = null)
        {
            string endpoint = "/api/users";
            if (parameters != null)
            {
                endpoint += "?";
                endpoint += string.Join("&", parameters);
            }
            return await HttpClientUtil.securedClient.GET(endpoint);
        }
    }
}
