using Bunifu.Framework.UI;
using KTAVisorAPISDK.module.user.consts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.module.users.component.UserSidebarCard
{
    public partial class UserSidebarCard : UserControl
    {
       

        public enum Status
        {
            OFFLINE = 0,
            ONLINE = 1
        }

        private string _userRole;
        private readonly List<BunifuFlatButton> _adminButtons;
        private readonly List<BunifuFlatButton> _userButton;

        public event EventHandler<EventArgs> OnStationsClick;
        public event EventHandler<EventArgs> OnRecordingsClick;
        public event EventHandler<EventArgs> OnLogsClick;

        public event EventHandler<EventArgs> OnProfileClick;
        public event EventHandler<EventArgs> OnUsersClick;

        public event EventHandler<EventArgs> OnSettingsClick;
        public event EventHandler<EventArgs> OnLogOutclick;
        public UserSidebarCard()
        {
            InitializeComponent();
        }

        public UserSidebarCard(string userRole)
        {
            InitializeComponent();
            this._userRole = userRole;
            this._adminButtons = new List<BunifuFlatButton>()
            {
                this.profileBtn,
                this.usersBtn,
                this.stationBtn,
                this.logsBtn,
                this.recordingsBtn,
                this.settingsBtn,
                this.logoutBtn
            };

            this._userButton = new List<BunifuFlatButton>()
            {
                this.profileBtn,
                this.recordingsBtn,
                this.logoutBtn,
            };
        }


        private void UserProfileCard_Load(object sender, EventArgs e)
        {
            this.initializeAccessRules();
            if (this._userRole == UserRole.ROLE_ADMIN){
                this.OnStationsClick?.Invoke(this, e);
            } else {
                this.OnRecordingsClick?.Invoke(this, e);
            }
        }

        private void initializeAccessRules()
        {
            if (this._userRole == UserRole.ROLE_ADMIN) 
            {
                this.configureAdminButtons();
            }
            if (this._userRole == UserRole.ROLE_USER)
            {
                this.configureUserButtons();
            }
        }

 
        private void configureAdminButtons()
        {
            this._adminButtons.ForEach((button) => button.Enabled = true);
        }

        private void configureUserButtons()
        {
            this._adminButtons.ForEach((button) => {
                button.Enabled = false;
            });
            this._userButton.ForEach((button) => button.Enabled = true);
        }

        public string FirstAndLastName
        {
            get { return this.firstAndLastNameLbl.Text;  }
            set { this.firstAndLastNameLbl.Text = value; }
        }

        public string Version
        {
            get { return this.versionLbl.Text; }
            set { this.versionLbl.Text = value; }
        }
 

        private void stationBtn_Click(object sender, EventArgs e)
        {
            this.OnStationsClick?.Invoke(this, e);
        }

        private void recordingsBtn_Click(object sender, EventArgs e)
        {
            this.OnRecordingsClick?.Invoke(this, e);
        }
 

        private void logsBtn_Click(object sender, EventArgs e)
        {
            this.OnLogsClick?.Invoke(this, e);
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            this.OnProfileClick?.Invoke(this, e);
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            this.OnUsersClick?.Invoke(this, e);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            this.OnSettingsClick?.Invoke(this, e);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.OnLogOutclick?.Invoke(sender, e);
        }

        public void setStatus(int status)
        {
            if (status == (int)Status.OFFLINE)
            {
                this.statusPicBox.Image = Properties.Resources.red_circle;  
            }  else
            {
                this.statusPicBox.Image = Properties.Resources.green_circle;
            }
        }
    }
}
