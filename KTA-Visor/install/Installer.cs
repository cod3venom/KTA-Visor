using KTA_Visor.kernel.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.install
{
    public class Installer
    {
        private string currentPath;

        public Installer()
        {
            this.currentPath = Directory.GetCurrentDirectory();
        }

        private DirectoryInfo SettingsDirectory
        {
            get { return new DirectoryInfo(string.Format("{0}/settings", this.currentPath)); }
        }

        private FileInfo SettingsFile
        {
            get { return new FileInfo(string.Format("{0}/settings/Settings.json", this.currentPath)); }
        }

        private DirectoryInfo LogsDirectory
        {
            get { return new DirectoryInfo(string.Format("{0}/logs", this.currentPath)); }
        }


        private void writeSettingsFile()
        {
            
            if (!this.SettingsDirectory.Exists)
                this.SettingsDirectory.Create();

            if (!this.SettingsFile.Exists)
            {
                string settingsContent = EmbededFileHelper.Read("KTA_Visor.install.settings.Settings.json", true);
                File.WriteAllText(this.SettingsFile.FullName, settingsContent);
            }
        }

        private void createLogsDir()
        {
            if (this.LogsDirectory.Exists)
                return;

            this.LogsDirectory.Create();
        }

    
        public void FullInstall()
        {
            this.writeSettingsFile();
            this.createLogsDir();
        }
    }
}
