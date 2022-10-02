using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.dto.response
{
    public class VerifyUserPasswordRecoveryCodeResponseTObject : DTOHelperStruct
    {
        public class Response
        {
            public string recoveryId { get; set; }
            public bool verified { get; set; }
        }

        public Response data { get; set; }
        public List<Response> datas { get; set; }
    }
}
