using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace TCPTunnel.kernel.extensions.router.interfaces
{
   public interface IRouteController
   {
        void StartWatching(Request request);
    }

}
