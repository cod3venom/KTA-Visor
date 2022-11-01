using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager.view;
using KTAVisorAPISDK.module.user.abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.fileManager
{
    public class FileManagerModule : FileManagerView, ISharedKernelInterface, IModuleInterface
    {
        public static string ModuleName = "FileManager";

        public FileManagerModule(UserDataAbstraction user):base(user)
        {

        }
        public string GetModuleName()
        {
            return FileManagerModule.ModuleName;
        }

        public void ShowDialog()
        {
        }
    }
}