using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.auth.dto.request;
using KTAVisorAPISDK.module.auth.entity;
using KTAVisorAPISDK.module.auth.service;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.auth.view.SignUpView
{
    public partial class SignUpView : Form
    {
        private readonly AuthService authService;
        public SignUpView()
        {
            InitializeComponent();
            this.authService = new AuthService();
            this.topBar1.Parent = this;
         }

        private void SignUpView_Load(object sender, EventArgs e)
        {
            this.topBar1.onClose += onClose;
            this.topBar1.ResizeButton.Visible = false;
            this.topBar1.MinimizeButton.Visible = false;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.centerisePanel();

            this.signInLink.Click += onShowSignInView;
            this.signUpBtn.Click += onSignUp;
        }

        private void centerisePanel()
        {
            this.signupPanel.Location = new Point(
                this.ClientSize.Width / 2 - this.signupPanel.Size.Width / 2,
                this.ClientSize.Height / 2 - this.signupPanel.Size.Height / 2);

            this.signupPanel.Anchor = AnchorStyles.None;
        }


        private async void onSignUp(object sender, EventArgs e)
        {
           try
            {
               SignUpEntity user = await this.authService.signUp(new SignUpRequestTObject(
                   this.firstNameTxt.Text,
                   this.lastNameText.Text,
                   this.emailTxt.Text,
                   this.passwordTxt.Text
               ));

                if (user == null)
                {
                    new AlertWindow("Nie udało się zarejestrować, sprawdż poprawnośc danych lub skontaktuj się z Administratorem");
                    return;
                }
                this.Hide();
                new Management.view.Management(user).Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void onShowSignInView(object sender, EventArgs e)
        {
            this.Hide();
            new SignInView.SignInView().Show();
        }

        private void onClose(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
