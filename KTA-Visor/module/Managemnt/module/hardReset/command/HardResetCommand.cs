using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.hardReset.command
{
    public class HardResetCommand
    {
        public static void Execute()
        {

            Application.Restart();
        }
    }
}
