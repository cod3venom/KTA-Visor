using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.auth.dto.request
{
    public class SignInRequestTObject
    {
        public string email { get; set; }
        public string password { get; set; }

        public SignInRequestTObject(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
