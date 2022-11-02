using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager;
using KTA_Visor.module.Managemnt.module.logs;
using KTA_Visor.module.Managemnt.module.station;
using KTA_Visor.module.Managemnt.module.users;
using KTA_Visor.module.Managemnt.sub_window;
using KTA_Visor.module.Managemnt.view;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Managemnt.uiHandler
{
    public class SideBarUIHandler: IUIHandlerInterface
    {
        private readonly Management.view.Management managementForm;
        public SideBarUIHandler(Management.view.Management managementForm)
        {
            this.managementForm = managementForm;
        }

        public void Handle()
        {
            this.renderUserProfileData();
            this.hookEvents();
            this.initializeUI();
        }

        private void hookEvents()
        {
            this.managementForm.SideBar.OnReportsClick += onReportsClick;
            this.managementForm.SideBar.OnNotificationClick += onNotificationsClick;
            this.managementForm.SideBar.OnProfileClick += onProfileClick;
            this.managementForm.SideBar.OnUsersClick += onUsersClick;
            this.managementForm.SideBar.OnStationsClick += onStationsClick;
            this.managementForm.SideBar.OnRecordingsClick += onRecordingsClick;
            this.managementForm.SideBar.OnLogsClick += onLogsClick;
            this.managementForm.SideBar.OnSettingsClick += onSettingsClick;
            this.managementForm.SideBar.OnLogOutclick += onLogoutClick;
        }

       
        private void onReportsClick(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.managementForm.Settings.SettingsObj.app.fileSystem?.reportsPath))
            {
                MessageBox.Show("Masaz 0 raportów");
                return;
            }

            Process.Start(this.managementForm.Settings.SettingsObj.app.fileSystem?.reportsPath);
        }

        private void onNotificationsClick(object sender, EventArgs e)
        {
            MessageBox.Show("Masaz 0 Powiadomień");
        }

        private void initializeUI()
        {
            this.managementForm.SideBar.DriveMonitoring.Start(this.managementForm.Settings.SettingsObj.app.fileSystem.storageDriveLetter);
        }
        private void renderUserProfileData()
        {
            this.managementForm.SideBar.FirstAndLastName = String.Format("{0} {1}",
                this.managementForm.User.data?.firstName, 
                this.managementForm.User.data?.lastName
            );
        }

        private void onProfileClick(object sender, EventArgs e)
        {
            new UserProfileWindow().ShowDialog();
        }

        private void onUsersClick(object sender, EventArgs e)
        {
            this.displayPanel(this.managementForm.Modules.Get(UsersModule.ModuleName));
        }

        private void onStationsClick(object sender, EventArgs e)
        {
            this.displayPanel(this.managementForm.Modules.Get(StationModule.ModuleName));
        }

        private void onRecordingsClick(object sender, EventArgs e)
        {
            this.displayPanel(this.managementForm.Modules.Get(FileManagerModule.ModuleName));
        }
 
        private void onLogsClick(object sender, EventArgs e)
        {
            if (!this.managementForm.LogsModule.IsHandleCreated || this.managementForm.LogsModule.IsDisposed)
            {
                this.managementForm.LogsModule = new LogsModule();
            }
            this.managementForm.LogsModule.ShowDialog();
        }

        private void onSettingsClick(object sender, EventArgs e)
        {
            new SettingsEntryPoint().ShowDialog();
        }

        private void onLogoutClick(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void displayPanel(object control)
        {
            if (control is Control module)
            {
                this.managementForm.Content.Controls.Clear();
                module.Dock = DockStyle.Fill;
                this.managementForm.Content.Controls.Add(module);
                this.managementForm.Modules.Sync(control);
            }
        }
    }
}
