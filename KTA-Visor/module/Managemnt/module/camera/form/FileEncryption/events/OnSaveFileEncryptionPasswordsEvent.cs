using System;

namespace KTA_Visor.module.Managemnt.module.camera.form.FileEncryption.events
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
