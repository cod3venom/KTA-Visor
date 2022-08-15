using KTA_Visor.kernel.sharedKernel.helper.LocalStorage;
using KTA_Visor.kernel.sharedKernel.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.auth.command
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
