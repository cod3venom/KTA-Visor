using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.kernel.sharedKernel.interfaces
{
    public interface IModuleInterface
    {
        void Watch(Request request);
    }
}
