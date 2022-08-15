using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.kernel.sharedKernel.bootstrap
{
    public class Bootstrap
    {
        public  watcher.Watcher _Watcher;

        public Bootstrap()
        {
            this._Watcher = new watcher.Watcher();
        }
    }
}
