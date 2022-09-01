using KTA_Visor_DSClient.kernel.sharedKernel.LocalStorage;
using KTA_Visor_DSClient.module.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Auth.command
{
    public class SaveSessionCommand
    {
        public static void Execute(string jwt)
        {
            LocalStorage.set("jwt", jwt);
            HttpClientUtil.securedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }
    }
}
