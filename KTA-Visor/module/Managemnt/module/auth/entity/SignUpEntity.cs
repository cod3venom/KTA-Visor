using KTA_Visor.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.auth.entity
{
    public class SignUpEntity : DTOHelperStruct
    {
        public Data data { get; set; }

        public class Data
        {
            public string token { get; set; }
        }
    }
}
