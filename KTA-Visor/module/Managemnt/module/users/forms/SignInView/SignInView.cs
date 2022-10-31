using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.users.forms.SignInView
{
    public partial class SignInView : Form
    {
        public event EventHandler<EventArgs> OnClose;

        private readonly UserAuthService authService;
        public SignInView()
        {
            InitializeComponent();
            this.authService = new UserAuthService();
            this.topBar1.Parent = this;
        }

        private void SignInView_Load(object sender, EventArgs e)
        {
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.initialize();
            this.enterFullScreenMode();
        }

        private void initialize()
        {
            this.hookEvents();
            this.centerisePanel();
        }

        private void hookEvents()
        {
            this.signInBtn.Click += onSignIn;
            this.signUpLink.Click += onShowSignUpView;
            this.forgotPasswordLbl.Click += onShowForgotPasswordForm;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

      

        private void enterFullScreenMode()
        {
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
       
        private void centerisePanel()
        { 
            this.signInPanel.Location = new Point(
              this.ClientSize.Width / 2 - this.signInPanel.Size.Width / 2,
              this.ClientSize.Height / 2 - this.signInPanel.Size.Height / 2
            );
        }


        private async void onSignIn(object sender, EventArgs e)
        {
            try
            {
                SignInRequestTObject request = new SignInRequestTObject(this.emailTxt.Text, this.passwordTxt.Text);
                SignInEntity signInEntity = await this.authService.signIn(request);

                if (signInEntity.data == null)
                {
                    new AlertWindow("Coś poszło nie tak, upewnij się że wporwadzasz poprawne dane do logowania");
                    return;
                }

                this.Hide();
                Form form = new Management.view.Management(signInEntity);
                form.FormClosing += onClosing;
                form.ShowDialog();

            }
            catch (Exception ex)
            {
                new AlertWindow(ex.Message);
            }
        }
 
        private void onShowSignUpView(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new SignUpView.SignUpView();
            form.FormClosing += onClosing;
            form.ShowDialog();
        }


        private void onShowForgotPasswordForm(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new ForgotPasswordView.ForgotPasswordView();
            form.FormClosing += onClosing;
            form.ShowDialog();
        }

        private void onClosing(object sender, FormClosingEventArgs e)
        {
            this.OnClose?.Invoke(this, e);
        }
 
    }
}
