using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.cardReader.form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.cardReader
{
    public class CardReaderModule : CardModeWindow, ISharedKernelInterface, IModuleInterface
    {
        public static string ModuleName = "CardReaderModule";

        public string GetModuleName()
        {
            return CardReaderModule.ModuleName;
        }

        void IModuleInterface.ShowDialog()
        {
            this.ShowDialog();
        }
    }
}
