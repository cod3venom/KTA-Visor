using KTA_Visor.install.settings.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.install.settings
{
    public class Settings
    {
        private SettingsFileTObject settingsFileTObject;

        private FileInfo settingsFile;

        public Settings()
        {
            this.loadSettings();
        }


        public SettingsFileTObject SettingsObj
        { get { return this.settingsFileTObject; } }

        public FileInfo SettingsFile
        { get { return this.settingsFile; } }

        private void loadSettings()
        {
            this.settingsFile = new FileInfo(
                string.Format("{0}/settings/settings.json", Directory.GetCurrentDirectory())
            );

            string jsonSettings = File.ReadAllText(this.settingsFile.FullName);
            this.settingsFileTObject = JsonConvert.DeserializeObject<SettingsFileTObject>(jsonSettings);
        }


        public SettingsFileTObject Save(SettingsFileTObject settings, bool restart = false)
        {
            string jsonSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(this.settingsFile.FullName, jsonSettings);

            this.loadSettings();

            if (restart)
            {
                Application.Restart();
            }

            return this.settingsFileTObject;
        }

        public SettingsFileTObject Save(bool restart = false)
        {
            string jsonSettings = JsonConvert.SerializeObject(this.settingsFileTObject, Formatting.Indented);
            File.WriteAllText(this.settingsFile.FullName, jsonSettings);

            this.loadSettings();

            if (restart)
            {
                Application.Restart();
            }
            return this.settingsFileTObject;
        }
    }
}
