using KTAVisorAPISDK.module.user.dto.request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.users.forms.CreateUser.events
{
    public class OnCreateNewUserEvent : EventArgs
    {
        public OnCreateNewUserEvent(CreateUserRequestTObject request)
        {
            this.Request = request;
        }

        public CreateUserRequestTObject Request { get; set; }
    }
}
