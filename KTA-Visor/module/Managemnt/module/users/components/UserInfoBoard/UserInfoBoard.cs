using KTA_Visor.module.Managemnt.module.users.components.UserInfoBoard.events;
using KTAVisorAPISDK.module.user.consts;
using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.users.components.UserInfoBoard
{
    public partial class UserInfoBoard : UserControl
    {
        public event EventHandler<OnSaveUserFromBoardEvent> OnSaveUserChanges;
        private UserEntity.User _user;
        public UserInfoBoard()
        {
            InitializeComponent();
            this._user = new UserEntity.User();
        }

        private void UserInfoBoard_Load(object sender, EventArgs e)
        {
            this.hookEvents();
        }

        private void hookEvents()
        {
            this.saveBtn.Click += onSaveChanges;
        }

        private void onSaveChanges(object sender, EventArgs e)
        {
            EditUserRequestTObject request = new EditUserRequestTObject(
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
            this.OnSaveUserChanges?.Invoke(this, new OnSaveUserFromBoardEvent(request));
        }

        public string ID
        {
            set { this.idTxt.Text = value; }
            get { return this.idTxt.Text; }
        }


        public string FirstName 
        {
            set { this.nameTxt.Text = value; }
            get { return this.nameTxt.Text;  }
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

        public string UpdatedAt
        {
            set { this.createdAtTxt.Text = value; }
            get { return this.createdAtTxt.Text; }
        }

        public string CreatedAt
        {
            set { this.updatedAtTxt.Text = value; }
            get { return this.updatedAtTxt.Text; }
        }

        public void FromUser(UserEntity.User user)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this._user = user;

                this.ID = user.id.ToString();
                this.FirstName = user.firstName;
                this.LastName = user.lastName;
                this.Email = user.email;
                this.Password = "";
                this.RepeatedPassword = "";
                this.CamCustomId = user.camCustomId;
                this.BadgeId = user.badgeId;
                this.CardId = user.cardId;
                this.UpdatedAt = user.updatedAt;
                this.CreatedAt = user.createdAt;
            });
        }
    }
}
