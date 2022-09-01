using KTA_Visor_DSClient.kernel.sharedKernel.HttpClientHelper.events;
using KTA_Visor_DSClient.kernel.sharedKernel.HttpClientHelper.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.kernel.sharedKernel.HttpClientHelper
{
    public class HttpClientHelper : HttpClient, IHttpClient
    {
        public event EventHandler<HttpUnauthorizedInterceptorEvent> OnUnauthorized;

        public Task<HttpResponseMessage> DELETE(string address, string data = "")
        {
            return this._call("DELETE", address);
        }

        public Task<HttpResponseMessage> GET(string address)
        {
            return this._call("GET", address);
        }

        public Task<HttpResponseMessage> POST(string address, string data = "")
        {
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            return this._call("POST", address, content);
        }

        public Task<HttpResponseMessage> PUT(string address, string data = "")
        {
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            return this._call("PUT", address, content);
        }

        private Task<HttpResponseMessage> _call(string method, string address, StringContent content = null)
        {
            Task<HttpResponseMessage> result = null;
            switch(method)
            {
                case "GET":
                    result = this.GetAsync(address);
                    break;

                case "POST":
                    result = this.PostAsync(address, content);
                    break;

                case "PUT":
                    result = this.PutAsync(address, content);;
                    break;

                case "DELETE":
                    result = this.DeleteAsync(address);
                    break;
            }

            if (result == null)
            {
                throw new Exception("Unable to make http request");
            }

            if (result.Result.StatusCode == HttpStatusCode.Unauthorized)
            {
                this.OnUnauthorized?.Invoke(this, new HttpUnauthorizedInterceptorEvent());
                Application.DoEvents();
            }

            return result;
        }

        private void interceptUnathorized()
        {

        }
    }
}
