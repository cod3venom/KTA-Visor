using KTAVisorAPISDK.kernel.module.HttpClientHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.kernel.sharedKernel.util
{
    public class HttpClientUtil
    {
        public static HttpClientHelper securedClient = new HttpClientHelper();
        public static HttpClientHelper httpClient = new HttpClientHelper();


        public static void initializeSecuredClient(string baseAddress)
        {
            HttpClientUtil.securedClient.BaseAddress = new Uri(baseAddress);
        }

        public static void initializeHttpClient(string baseAddress)
        {
            HttpClientUtil.httpClient.BaseAddress = new Uri(baseAddress);
        }

        public static void addHeaderToSecuredClient(string key, string value)
        {
            HttpClientUtil.securedClient.DefaultRequestHeaders.Add(key, value);
        }

        public static void addHeaderToHttpClient(string key, string value)
        {
            HttpClientUtil.httpClient.DefaultRequestHeaders.Add(key, value);
        }

    }
}
