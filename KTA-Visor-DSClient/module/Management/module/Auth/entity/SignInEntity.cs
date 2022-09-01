using KTA_Visor_DSClient.kernel.sharedKernel.DTOHelper.util;

namespace KTA_Visor_DSClient.module.Management.module.auth.entity
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