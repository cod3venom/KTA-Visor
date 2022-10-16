using Falcon_Protocol.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.types
{
    public class ModulesPack : List<IModuleInterface>
    {
        public IModuleInterface Get(string moduleName)
        {
            return this.Find((IModuleInterface module) => module.GetModuleName() == moduleName);
        }
    }
}
