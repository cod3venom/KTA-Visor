using KTA_Visor.kernel.sharedKernel.helper.DTOHelper.util;

namespace KTA_Visor.module.Managemnt.module.auth.entity
{
    public class SignInEntity : DTOHelperStruct
    {
        public Data data { get; set; }

        public class Data
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string jwt { get; set; }
            public string[] roles { get; set; }
        }
    }
}