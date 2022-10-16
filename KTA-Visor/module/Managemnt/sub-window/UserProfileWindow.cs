using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using MetroFramework;
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

namespace KTA_Visor.module.Managemnt.sub_window
{
    public partial class UserProfileWindow : MetroForm
    {
        private readonly UserService userService;
        public UserProfileWindow()
        {
            InitializeComponent();
            this.userService = new UserService();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Brush b = new SolidBrush(Color.DarkCyan)){
                int borderWidth = 5;
                e.Graphics.FillRectangle(b, 0, 0, Width, borderWidth);
            }
        }

        private void UserProfileWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.hookEvents();
            this.renderData();
        }


        private void hookEvents()
        {
            this.saveBtn.Click += onSave;
            this.cancelBtn.Click += onCancel;
        }

        private async void renderData()
        {
            UserEntity.User user = await this.fetchUser();

            this.nameTxt.Text = user.firstName;
            this.lastNameTxt.Text = user.lastName;
            this.emailTxt.Text = user.email;
        }


        private async void onSave(object sender, EventArgs e)
        {
           UserEntity user = await this.userService.edit(new EditUserRequestTObject
            {
                firstName = this.nameTxt.Text,
                lastName = this.lastNameTxt.Text,
                email = this.emailTxt.Text,
                password = this.passwordTxt.Text,
                repeatedPassword = this.repeatPasswordTxt.Text
            });

            if (user.data == null)
            {
                MetroMessageBox.Show(this, "Coś poszło nie tak, skontaktuj się z Administratorem");
                return;
            }

            this.Close();
        }

        private void onCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private async Task<UserEntity.User> fetchUser()
        {
            UserEntity user = await this.userService.me();
            if (user.data == null)
            {
                MetroMessageBox.Show(this,
                    "Nie  udało się pobrać dane zalogowanego użytkownika, \n " +
                    "ze względu na bezpieczeństwo zostaniesz wylogowany."
                );
            }
            return user.data;
        }
    }
}
