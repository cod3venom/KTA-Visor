using System;

namespace KTA_Visor.module.Managemnt.module.fileManager.handlers.form.Zipper.events
{
    public class OnPasswordsAreOkEvent: EventArgs
    {
        public OnPasswordsAreOkEvent(string password, string repeatedPassword)
        {
            this.Password = password;
            this.RepeatedPassword = repeatedPassword;
        }

        public string Password { get; set; }    
        public string RepeatedPassword { get; set; }    
    }
}
