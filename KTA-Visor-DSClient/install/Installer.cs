using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.install
{
    public class Installer
    {
        private string currentPath;

        public Installer()
        {
            this.currentPath = Directory.GetCurrentDirectory();
        }
        private void writeSettingsFile()
        {
            
            DirectoryInfo dirInfo = new DirectoryInfo(string.Format("{0}/settings", this.currentPath));
            FileInfo fileInfo = new FileInfo(string.Format("{0}/settings/settings.json", this.currentPath));
            if (!dirInfo.Exists)
                dirInfo.Create();

            if (!fileInfo.Exists)
            {
                string settingsContent = EmbededFileHelper.Read("KTA_Visor_DSClient.install.settings.Settings.json", true);
                File.WriteAllText(fileInfo.FullName, settingsContent);
            }
        }

        private void createLogsDir()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(string.Format("{0}/logs", this.currentPath));
            if (dirInfo.Exists)
                return;

            dirInfo.Create();
        }

        public void FullInstall()
        {
            this.writeSettingsFile();
            this.createLogsDir();
        }
    }
}
