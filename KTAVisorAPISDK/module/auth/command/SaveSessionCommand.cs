
using KTAVisorAPISDK.kernel.sharedKernel.helper.LocalStorage;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using System.Net.Http.Headers;
namespace KTAVisorAPISDK.module.auth.command
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
