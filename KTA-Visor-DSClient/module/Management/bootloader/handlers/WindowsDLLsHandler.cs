using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class WindowsDLLsHandler : IBootLoaderHandler
    {
        public static string HandlerName = "WindowsDLLsHandler";

        private KTALogger.Logger _logger;
        public WindowsDLLsHandler(KTALogger.Logger logger)
        {
            this._logger = logger;
        }

        public string GetName()
        {
            return WindowsDLLsHandler.HandlerName;
        }

        public void Handle()
        {
            this.copyDllsToSysWow64();
        }

        private void copyDllsToSysWow64()
        {
            
            string syswow64 = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86);
            FileInfo ucrtbasedDLL = new FileInfo(string.Format("{0}\\dll\\ucrtbased.dll", Environment.CurrentDirectory));
            string ucrtDestPath = string.Format("{0}\\{1}", syswow64, ucrtbasedDLL.Name);
            
            FileInfo vcRuntime140 = new FileInfo(string.Format("{0}\\dll\\vcruntime140.dll", Environment.CurrentDirectory));
            string vcRuntime140DestPath = string.Format("{0}\\{1}", syswow64, vcRuntime140.Name);
           
            FileInfo vcruntime140d = new FileInfo(string.Format("{0}\\dll\\vcruntime140d.dll", Environment.CurrentDirectory));
            string vcRuntime140DDestPath = string.Format("{0}\\{1}", syswow64, vcruntime140d.Name);

            ucrtbasedDLL.CopyTo(ucrtDestPath,  true);
            vcRuntime140.CopyTo(vcRuntime140DestPath, true);
            vcruntime140d.CopyTo(vcRuntime140DDestPath, true);
        }
    }
}
