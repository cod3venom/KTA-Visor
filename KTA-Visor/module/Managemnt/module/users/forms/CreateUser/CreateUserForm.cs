using KTA_Visor.module.Managemnt.module.users.forms.CreateUser.events;
using KTAVisorAPISDK.module.user.consts;
using KTAVisorAPISDK.module.user.dto.request;
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

namespace KTA_Visor.module.Managemnt.module.users.forms.CreateUser
{
    public partial class CreateUserForm : MetroForm
    {
        public event EventHandler<OnCreateNewUserEvent> OnCreateNewUser;
        public CreateUserForm()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#222222")))
            {
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            this.createBtn.Click += onCreateUser;
        }

        private void onCreateUser(object sender, EventArgs e)
        {
            CreateUserRequestTObject request = new CreateUserRequestTObject(
                this.FirstName,
                this.LastName,
                this.Email,
                this.Password,
                this.RepeatedPassword,
                UserRole.ROLE_USER,
                this.CamCustomId,
                this.BadgeId,
                this.CardId
            );
            this.OnCreateNewUser?.Invoke(this, new OnCreateNewUserEvent(request));
        }

 

        public string FirstName
        {
            set { this.nameTxt.Text = value; }
            get { return this.nameTxt.Text; }
        }

        public string LastName
        {
            set { this.lastNameTxt.Text = value; }
            get { return this.lastNameTxt.Text; }
        }


        public string Email
        {
            set { this.emailTxt.Text = value; }
            get { return this.emailTxt.Text; }
        }


        public string CamCustomId
        {
            set { this.camCustomIdTxt.Text = value; }
            get { return this.camCustomIdTxt.Text; }
        }


        public string BadgeId
        {
            set { this.badgeIdTxt.Text = value; }
            get { return this.badgeIdTxt.Text; }
        }


        public string CardId
        {
            set { this.cardIdTxt.Text = value; }
            get { return this.nameTxt.Text; }
        }


        public string Password
        {
            set { this.passwordTxt.Text = value; }
            get { return this.passwordTxt.Text; }
        }

        public string RepeatedPassword
        {
            set { this.repeatPasswordTxt.Text = value; }
            get { return this.repeatPasswordTxt.Text; }
        }
    }
}
