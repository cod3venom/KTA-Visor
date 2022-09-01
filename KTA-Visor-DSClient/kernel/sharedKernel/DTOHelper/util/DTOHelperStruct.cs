using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.sharedKernel.DTOHelper.util
{
    abstract public class DTOHelperStruct
    {
        public string type { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        
    }
}
