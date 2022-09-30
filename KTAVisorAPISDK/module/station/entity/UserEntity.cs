using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.entity
{
    public class UserEntity : DTOHelperStruct
    {

        public class User
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public List<object> roles { get; set; }
            public object ownerId { get; set; }
            public string id { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
            public string userIdentifier { get; set; }
        }

        public User data { get; set; }
        public List<User> datas { get; set; }

    }
}
