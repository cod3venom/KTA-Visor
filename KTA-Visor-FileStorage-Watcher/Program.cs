using KTAVisorAPISDK.kernel.sharedKernel.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_FileStorage_Watcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            HttpClientUtil.initializeHttpClient("http://localhost:8000/api");
            HttpClientUtil.initializeSecuredClient("http://localhost:8000/api");
#if DEBUG
            FileWatcherService service = new FileWatcherService();
           service.onDebug();
#else
             ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FileWatcherService()
            };
            ServiceBase.Run(ServicesToRun);
#endif
         
        }
    }
}
