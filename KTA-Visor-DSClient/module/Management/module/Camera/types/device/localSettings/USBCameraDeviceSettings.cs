using KTA_Visor_DSClient.kernel.generator;
using Newtonsoft.Json;
using System;
using System.IO;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device.localSettings
{
    public class USBCameraDeviceSettings
    {

      

        private readonly DriveInfo driveInfo;
      
        private string settingsFilePath;
        public USBCameraDeviceSettings(DriveInfo drive)
        {
            this.driveInfo = drive;
            this.Settings = new LocalSettingsTObject();
            this.initialize();
        }

        public LocalSettingsTObject Settings { get; set; }
        
        private void initialize()
        {
            this.initializeSettingsFile();
        }

        private void initializeSettingsFile()
        {
            try
            {
                this.settingsFilePath = string.Format(@"{0}LocalSettings.json", this.driveInfo.Name);
                if (!File.Exists(this.settingsFilePath))
                {
                    File.WriteAllText(this.settingsFilePath, "");
                    this.Settings.ID = 0;
                    this.Settings.CustomId = RandomData.RandomString(15);
                    this.Settings.BadgeId = RandomData.RandomString(15);
                    this.Settings.CardId = "0000000000";
                    this.Settings.MarkerId = RandomData.RandomString(15);
                    this.SaveSettings();
                }
                else
                {
                    this.loadSettings();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void loadSettings()
        {
            if (!File.Exists(this.settingsFilePath)){
                this.initializeSettingsFile();
            }

            string settingsFromFile = File.ReadAllText(this.settingsFilePath);
            this.Settings = JsonConvert.DeserializeObject<LocalSettingsTObject>(settingsFromFile);
        }

        public void SaveSettings(LocalSettingsTObject settings = null)
        {
            if (settings == null) {
                settings = this.Settings;
            }

            if (!File.Exists(this.settingsFilePath)){
                return;
            }

            string settingsContent = JsonConvert.SerializeObject(settings);
            FileStream fs = File.Open(this.settingsFilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(settingsContent);
                writer.Close();
                fs.Close();
            }
        }
    }
}
