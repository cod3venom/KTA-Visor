﻿
namespace KTAVisorAPISDK.module.user.dto.request
{
    public class EditUserRequestTObject
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string repeatedPassword { get; set; }
    }
}
