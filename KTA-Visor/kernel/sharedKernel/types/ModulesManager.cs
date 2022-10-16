using KTA_Visor.kernel.sharedKernel.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.kernel.sharedKernel.types
{
    public class ModulesManager: List<IModuleInterface>
    {
        public void Sync(object control)
        {
            if (control is IModuleInterface module)
            {
                module = this.Get(module.GetModuleName());

                if (module == null){
                    return;
                }

                this.Remove(module);
                this.Add(module);
            }
        }

        public IModuleInterface Get(string moduleName)
        {
            foreach(IModuleInterface module in this)
            {
                if (module.GetModuleName() != moduleName) continue;
                return module;
            }
            return null;
        }
    }
}
