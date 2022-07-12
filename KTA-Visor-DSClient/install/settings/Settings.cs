using KTA_Visor_DSClient.install.settings.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.install.settings
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
            this.settingsFileTObject= JsonConvert.DeserializeObject<SettingsFileTObject>(jsonSettings);
        }


        public SettingsFileTObject Save(SettingsFileTObject settings)
        {
            string jsonSettings = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(this.settingsFile.FullName, jsonSettings);
            
            this.loadSettings();

            return this.settingsFileTObject;
        }
    }
}
