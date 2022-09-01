﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.sharedKernel.HttpClientHelper.interfaces
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GET(string address);
        Task<HttpResponseMessage> POST(string address, string data = "");
        Task<HttpResponseMessage> PUT(string address, string data = "");
        Task<HttpResponseMessage> DELETE(string address, string data = "");

    }
}
