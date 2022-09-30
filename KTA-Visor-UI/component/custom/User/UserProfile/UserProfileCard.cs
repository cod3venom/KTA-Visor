using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_UI.component.custom.User.UserProfile
{
    public partial class UserProfileCard : UserControl
    {
        public enum Status
        {
            OFFLINE = 0,
            ONLINE = 1
        }

        public event EventHandler<EventArgs> OnStationsClick;
        public event EventHandler<EventArgs> OnTunnelClick;
        public event EventHandler<EventArgs> OnFileHistoryClick;
        public event EventHandler<EventArgs> OnFileExplorerClick;
        public event EventHandler<EventArgs> OnLogsClick;

        public event EventHandler<EventArgs> OnProfileClick;
        public event EventHandler<EventArgs> OnAccountSecurityClick;

        public event EventHandler<EventArgs> OnSettingsClick;
        public event EventHandler<EventArgs> OnLogOutclick;

        public UserProfileCard()
        {
            InitializeComponent();
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

        private void UserProfileCard_Load(object sender, EventArgs e)
        {
            this.OnStationsClick?.Invoke(this, e);
        }

        private void stationBtn_Click(object sender, EventArgs e)
        {
            this.OnStationsClick?.Invoke(this, e);
        }

        private void fileHistoryBtn_Click(object sender, EventArgs e)
        {
            this.OnFileHistoryClick?.Invoke(this, e);
        }

        private void tunnelBtn_Click(object sender, EventArgs e)
        {
            this.OnTunnelClick?.Invoke(this, e);
        }

        private void logsBtn_Click(object sender, EventArgs e)
        {
            this.OnLogsClick?.Invoke(this, e);
        }

        private void profileBtn_Click(object sender, EventArgs e)
        {
            this.OnProfileClick?.Invoke(this, e);
        }

        private void accountSecurityBtn_Click(object sender, EventArgs e)
        {
            this.OnAccountSecurityClick?.Invoke(this, e);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            this.OnSettingsClick?.Invoke(this, e);
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.OnLogOutclick.Invoke(sender, e);
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

 
        private void fileExplorerBtn_Click(object sender, EventArgs e)
        {
            this.OnFileExplorerClick?.Invoke(this, e);
        }
    }
}
