using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.flags
{
    public class WMQuery
    {
        public  enum WM_DEVICECHANGE
        {
            DBT_DEVNODES_CHANGED = 0x0007,
            DBT_DEVICEARRIVAL = 0x8000,
            DBT_DEVICEREMOVECOMPLETE = 0x8004,
        }

    }
}
