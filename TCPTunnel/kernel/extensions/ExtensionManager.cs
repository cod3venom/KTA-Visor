using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router;

namespace TCPTunnel.kernel.extensions
{
    public abstract class ExtensionManager
    {
        private readonly Router router;
        public ExtensionManager()
        {
            this.router = new Router();
        }

        public Router Router
        {
            get { return this.router; }
        }
    }
}
