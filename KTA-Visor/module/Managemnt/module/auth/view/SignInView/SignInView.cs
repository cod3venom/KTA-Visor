using KTAVisorAPISDK.module.auth.dto.request;
using KTAVisorAPISDK.module.auth.entity;
using KTAVisorAPISDK.module.auth.service;
using KTAVisorAPISDK.module.user.entity;
using KTAVisorAPISDK.module.user.service;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.auth.view.SignInView
{
    public partial class SignInView : Form
    {
        private readonly AuthService authService;
        private readonly UserService userService;
        public SignInView()
        {
            InitializeComponent();
            this.authService = new AuthService();
            this.userService = new UserService();
            this.topBar1.Parent = this;
        }

        private async void SignInView_Load(object sender, EventArgs e)
        {
            this.initialize();
        }

        private void initialize()
        {
            this.hookEvents();
            this.centerisePanel();
        }

        private void hookEvents()
        {
            this.topBar1.onClose += onClose;
            this.topBar1.ResizeButton.Visible = false;
            this.topBar1.MinimizeButton.Visible = false;
            this.signInBtn.Click += onSignIn;
            this.signUpLink.Click += onShowSignUpView;
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.fullScreenLoader.OnProgressEnd += onLoaderFinished;
        }

      

        private void centerisePanel()
        {
            this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.signInPanel.Location = new Point(
              this.ClientSize.Width / 2 - this.signInPanel.Size.Width / 2,
              this.ClientSize.Height / 2 - this.signInPanel.Size.Height / 2);
            this.signInPanel.Anchor = AnchorStyles.None;
        }


        private async void onSignIn(object sender, EventArgs e)
        {
            try
            {
                this.signInPanel.Visible = false;
                await this.fullScreenLoader.Start(10000, 1);
                SignInRequestTObject request = new SignInRequestTObject(this.emailTxt.Text, this.passwordTxt.Text);
                SignInEntity signIn = await this.authService.signIn(request);
                
                await this.fullScreenLoader.Stop(1000);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        
        private async void onLoaderFinished(object sender, EventArgs e)
        {
            UserEntity userEntity = await this.userService.me();
            new Management.view.Management(userEntity).Show();
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
