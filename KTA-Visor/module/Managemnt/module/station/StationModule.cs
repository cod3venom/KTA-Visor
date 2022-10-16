using KTA_Visor.kernel.sharedKernel.interfaces;
using KTA_Visor.module.Managemnt.module.station.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.station
{
    public class StationModule : StationView, ISharedKernelInterface, IModuleInterface
    {
        public static string ModuleName = "Station";

        public string GetModuleName()
        {
            return StationModule.ModuleName;
        }

        public void ShowDialog()
        {
        }
    }
}
