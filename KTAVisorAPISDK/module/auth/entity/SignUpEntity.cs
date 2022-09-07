using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.auth.entity
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
