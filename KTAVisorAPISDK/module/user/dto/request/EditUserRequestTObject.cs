
namespace KTAVisorAPISDK.module.user.dto.request
{
    public class EditUserRequestTObject
    {

        public EditUserRequestTObject(
            string firstName = "",
            string lastName = "",
            string email = "",
            string password = "",
            string repeatedPassword = "",
            string role = "",
            string camCustomid = "",
            string badgeId = "",
            string cardId = ""
        )
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.repeatedPassword = repeatedPassword;
            this.role = role;
            this.camCustomId = camCustomid;
            this.badgeId = badgeId;
            this.cardId = cardId;
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string repeatedPassword { get; set; }
        public string role { get; set; }
        public string camCustomId { get; set; }
        public string badgeId { get; set; }
        public string cardId { get; set; }
    }
}
