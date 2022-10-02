using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.dto.request
{
    public class UserPasswordRecoveryChangePasswordRequestTObject
    {
        public string recoveryId { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }
    }
}
