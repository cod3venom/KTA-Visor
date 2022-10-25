using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer
{
    public abstract class AbstractResource
    {
        protected FileSystem _fileSystem { get; set; }
        protected Reporter _reporter { get; set; }
 
    }
}
