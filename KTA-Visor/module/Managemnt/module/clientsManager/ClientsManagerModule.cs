using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.clientsManager.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.clientsManager
{
    public class ClientsManagerModule : ClientsManagerView, ISharedKernelInterface, IModuleInterface
    {

        public static string ModuleName = "ClientsManagerModule";

        public string GetModuleName()
        {
            return ClientsManagerModule.ModuleName;
        }

        public void ShowDialog()
        {
        }
    }
}
