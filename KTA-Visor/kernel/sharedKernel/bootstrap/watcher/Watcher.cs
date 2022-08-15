using KTA_Visor.kernel.sharedKernel.bootstrap.watcher.watchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.kernel.sharedKernel.bootstrap.watcher
{
    public class Watcher
    {
        public UnauthorizedWatcher unAuthorizedWatcher()
        {
            return new UnauthorizedWatcher();

        }
    }
}
