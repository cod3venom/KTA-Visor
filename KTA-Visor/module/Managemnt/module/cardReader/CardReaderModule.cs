using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.cardReader.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.module.cardReader
{
    public class CardReaderModule : CardModeWindow, ISharedKernelInterface, IModuleInterface
    {
        public static string ModuleName = "CardReaderModule";

        public string GetModuleName()
        {
            return CardReaderModule.ModuleName;
        }

        public void Watch(Request request)
        {
            throw new NotImplementedException();
        }

        void IModuleInterface.ShowDialog()
        {
            this.ShowDialog();
        }
    }
}
