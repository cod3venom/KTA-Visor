using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.helper
{
    public class ExecutionWaiter : Timer
    {
        
        
        public void start()
        {
            if (this.AutoReset) {
                this.Start();
            }

            this.Start();
        }
        
    }
}
