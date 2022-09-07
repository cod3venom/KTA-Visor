using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.kernel.module.HttpClientHelper.interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GET(string address);
        Task<HttpResponseMessage> POST(string address, string data);
        Task<HttpResponseMessage> PUT(string address, string data);
        Task<HttpResponseMessage> DELETE(string address);

    }
}
