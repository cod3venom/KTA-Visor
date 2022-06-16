using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.module.server.extensions.messenger;

namespace TCPTunnel.module.server
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
