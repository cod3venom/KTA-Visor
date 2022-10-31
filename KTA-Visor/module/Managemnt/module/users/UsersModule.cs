using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.users.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.users
{
    public class UsersModule : UsersView, ISharedKernelInterface, IModuleInterface
    {
        public static string ModuleName = "Users";

        public string GetModuleName()
        {
            return UsersModule.ModuleName;
        }

        public void ShowDialog()
        {
        }

        public void Watch(Request request)
        {
            
        }
    }
}
