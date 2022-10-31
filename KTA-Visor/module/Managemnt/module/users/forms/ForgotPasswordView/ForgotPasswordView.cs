using KTA_Visor_UI.component.custom.MessageWindow;
using KTAVisorAPISDK.module.user.dto.request;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.users.forms.ForgotPasswordView
{
    public partial class ForgotPasswordView : Form
    {
        public event EventHandler<EventArgs> OnClose;

        private readonly UserAuthService authService;
        public ForgotPasswordView()
        {
            InitializeComponent();
            this.authService = new UserAuthService();
            this.topBar1.Parent = this;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.initialize();
        }

        private void initialize()
        {
            this.hookEvents();
            this.centerisePanel();
        }

        private void hookEvents()
        {
            this.sendRecoveryCodeBtn.Click += onSendRecoveryCode;
            this.loginBtn.Click += onShowSignInView;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
 
        private void centerisePanel()
        { 
            this.signInPanel.Location = new Point(
              this.ClientSize.Width / 2 - this.signInPanel.Size.Width / 2,
              this.ClientSize.Height / 2 - this.signInPanel.Size.Height / 2
            );
        }


        private async void onSendRecoveryCode(object sender, EventArgs e)
        {
            try
            {
                 
            }
            catch (Exception ex)
            {
                new AlertWindow(ex.Message);
            }
        }
 
        private void onShowSignInView(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new SignInView.SignInView();
            form.FormClosing += onClosing;
            form.ShowDialog();
        }


        private void onClosing(object sender, FormClosingEventArgs e)
        {
            this.OnClose?.Invoke(this, e);
        }
 
    }
}
