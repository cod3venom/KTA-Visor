using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.interfaces
{
    public interface IBootLoaderHandler
    {
        void Handle();
        string GetName();
    }
}
