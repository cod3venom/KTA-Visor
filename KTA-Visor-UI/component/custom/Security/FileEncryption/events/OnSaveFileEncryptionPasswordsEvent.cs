using System;

namespace KTA_Visor_UI.component.custom.Security.FileEncryption.events
{
    public class OnSaveFileEncryptionPasswordsEvent: EventArgs
    {
        public OnSaveFileEncryptionPasswordsEvent(string password, string repeatedPassword)
        {
            this.Password = password;
            this.RepeatedPassword = repeatedPassword;
        }

        public string Password { get; set; }    
        public string RepeatedPassword { get; set; }    
    }
}
