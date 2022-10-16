using KTA_Visor.module.Managemnt.module.camera.form.FileEncryption.events;
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

namespace KTA_Visor.module.Managemnt.module.camera.form.FileEncryption
{
    public partial class FileEncryptionWithPasswordWindow : MetroForm
    {


        public event EventHandler<EventArgs> OnClose;
        public event EventHandler<EventArgs> OnPasswordLengthIsLessThanAllowed;
        public event EventHandler<EventArgs> OnPasswordAndRepeatedPasswordDoesntMatch;
        public event EventHandler<OnSaveFileEncryptionPasswordsEvent> OnSaveFileEncryptionPasswords;

 

        /// <summary>
        /// 
        /// </summary>
        public FileEncryptionWithPasswordWindow()
        {
            InitializeComponent();
        }


        private void FileEncryptionWithPasswordWindow_Load(object sender, EventArgs e)
        {
            this.saveBtn.Click += onSave;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // custom draw the top border
            using (Brush b = new SolidBrush(Color.DarkCyan))
            {
                int borderWidth = 5; // MetroFramework source code
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
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
