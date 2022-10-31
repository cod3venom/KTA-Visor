using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.users.components.UserInfoBoard.events
{
    public class OnSaveUserFromBoardEvent : EventArgs
    {
        public OnSaveUserFromBoardEvent(EditUserRequestTObject request)
        {
            this.Request = request;
        }

        public EditUserRequestTObject Request { get; set; }
    }
}
