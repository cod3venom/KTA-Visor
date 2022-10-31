using KTAVisorAPISDK.module.user.consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.dto.request
{
    public class SignUpRequestTObject
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public SignUpRequestTObject(string firstName, string lastName, string email, string password, string role = UserRole.ROLE_ADMIN)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.role = role;
        }
    }
}
