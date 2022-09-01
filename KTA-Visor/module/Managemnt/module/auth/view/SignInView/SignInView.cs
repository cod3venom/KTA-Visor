using KTA_Visor.module.Managemnt.module.auth.dto.request;
using KTA_Visor.module.Managemnt.module.auth.entity;
using KTA_Visor.module.Managemnt.module.auth.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.auth.view.SignInView
{
    public partial class SignInView : Form
    {
        private readonly AuthService authService;
 
        public SignInView()
        {
            InitializeComponent();
            this.authService = new AuthService();
            this.topBar1.Parent = this;
        }

        private void SignInView_Load(object sender, EventArgs e)
        {
            this.topBar1.onClose += onClose;
            this.topBar1.ResizeButton.Visible = false;
            this.topBar1.MinimizeButton.Visible = false;

            this.signInBtn.Click += onSignIn;
            this.signUpLink.Click += onShowSignUpView;

            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.centerisePanel();

        }

        private async void onSignIn(object sender, EventArgs e)
        {
            try
            {

                SignInEntity signIn = await this.authService.signIn(new SignInRequestTObject(
                     this.emailTxt.Text,
                     this.passwordTxt.Text
                 ));

                this.Hide();
                new Management.view.Management().Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void centerisePanel()
        {
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.signInPanel.Location = new Point(
              this.ClientSize.Width / 2 - this.signInPanel.Size.Width / 2,
              this.ClientSize.Height / 2 - this.signInPanel.Size.Height / 2);
            this.signInPanel.Anchor = AnchorStyles.None;
        }

        private void onShowSignUpView(object sender, EventArgs e)
        {
            this.Hide();
            new SignUpView.SignUpView().Show();
        }

        private void onClose(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
