using KTA_Visor.kernel.module.HttpClientHelper.events;
using KTA_Visor.kernel.sharedKernel.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.kernel.sharedKernel.bootstrap.watcher.watchers
{
    public class UnauthorizedWatcher
    {
        public void Watch()
        {
            HttpClientUtil.securedClient.OnUnauthorized += SecuredClient_OnUnauthorized;
            HttpClientUtil.httpClient.OnUnauthorized += HttpClient_OnUnauthorized;
        }

        private void HttpClient_OnUnauthorized(object sender, HttpUnauthorizedInterceptorEvent e)
        {
            Console.WriteLine("intercepted anon client");
        }

        private void SecuredClient_OnUnauthorized(object sender, HttpUnauthorizedInterceptorEvent e)
        {
            Console.WriteLine("intercepted secured client");
        }
    }
}
