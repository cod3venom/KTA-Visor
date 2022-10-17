using KTAVisorAPISDK.kernel.sharedKernel.util;
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
    public class CameraCardRepository
    {
        public async Task<HttpResponseMessage> hasDuplicates(string cardId)
        {
            return await HttpClientUtil.securedClient.GET(String.Format("/api/cameras/card/{0}/has-duplicaates", cardId));
        }
 
    }
}
