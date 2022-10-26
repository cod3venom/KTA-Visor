using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.kernel.interfaces
{
    public interface IControllerInterface
    {
        void Watch(Request request);
    }
}
