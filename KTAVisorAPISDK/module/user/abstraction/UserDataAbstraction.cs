using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.user.abstraction
{
    public class UserDataAbstraction
    {
        public class User
        {
            public string id { get; set; }
            public string jwt { get; set; }
            public string token { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public List<string> roles { get; set; }
            public string camCustomId { get; set; }
            public string badgeId { get; set; }
            public string cardId { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
            public string userIdentifier { get; set; }
        }

        public User data { get; set; }
        public List<User> datas { get; set; }
    }
}
