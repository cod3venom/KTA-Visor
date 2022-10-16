using KTA_Visor_UI.component.custom.Security.FileEncryption.events;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.Security.FileEncryption
{
    public partial class FileEncryptionWithPasswordWindow : MetroForm
    {


        public event EventHandler<EventArgs> OnClose;
        public event EventHandler<EventArgs> OnPasswordLengthIsLessThanAllowed;
        public event EventHandler<EventArgs> OnPasswordAndRepeatedPasswordDoesntMatch;
        public event EventHandler<OnSaveFileEncryptionPasswordsEvent> OnSaveFileEncryptionPasswords;


        public FileEncryptionWithPasswordWindow()
        {
            InitializeComponent();
        }


        private void FileEncryptionWithPasswordWindow_Load(object sender, EventArgs e)
        {
            this.showHidePasswordBtn.Click += onShowHidepassword;
            this.showHideRepeatedPasswordBtn.Click += onShowHideRepeatedPassword;
        }

        private void onShowHidepassword(object sender, EventArgs e)
        {
           if (this.filePasswordtxt.isPassword)
            {
                this.filePasswordtxt.isPassword = false;
                this.showHidePasswordBtn.BackgroundImage = Properties.Resources.hide;
                return;
            } else
            {
                this.filePasswordtxt.isPassword = true;
                this.showHidePasswordBtn.BackgroundImage = Properties.Resources.show;

                return;
            }
        }

        private void onShowHideRepeatedPassword(object sender, EventArgs e)
        {
            if (this.filePasswordRepeatTxt.isPassword)
            {
                this.filePasswordRepeatTxt.isPassword = false;
                this.showHideRepeatedPasswordBtn.BackgroundImage = Properties.Resources.hide;
                return;
            }
            else
            {
                this.filePasswordRepeatTxt.isPassword = true;
                this.showHideRepeatedPasswordBtn.BackgroundImage = Properties.Resources.show;

                return;
            }
        }


        private void onSave(object sender, EventArgs e)
        {
            if (this.filePasswordtxt.Text != this.filePasswordRepeatTxt.Text)
            {
                this.OnPasswordAndRepeatedPasswordDoesntMatch?.Invoke(sender, e);
                return;
            }

            if (this.filePasswordtxt.Text.Length < 8)
            {
                this.OnPasswordLengthIsLessThanAllowed?.Invoke(sender, e);
                return;
            }

            this.OnSaveFileEncryptionPasswords?.Invoke(sender, new OnSaveFileEncryptionPasswordsEvent(
                this.filePasswordtxt.Text,
                this.filePasswordRepeatTxt.Text
            ));
            this.Close();
        }

        private void onClose(object sender, EventArgs e)
        {
            this.Close();
            this.OnClose?.Invoke(sender, e);
        }
    }
}
