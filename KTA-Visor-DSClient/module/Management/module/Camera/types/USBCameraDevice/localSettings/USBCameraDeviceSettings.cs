using KTA_Visor_DSClient.kernel.generator;
using Newtonsoft.Json;
using System;
using System.IO;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice.localSettings
{
    public class USBCameraDeviceSettings
    {

        protected string cameraId = "";
        protected string cameraBadgeId = "";
        private string settingsFilePath;

        public LocalSettingsTObject Settings { get; set; }
        private readonly DriveInfo driveInfo;
        public USBCameraDeviceSettings(DriveInfo drive)
        {
            this.driveInfo = drive;
            this.Settings = new LocalSettingsTObject();

            this.initialize();
        }

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
                    this.Settings.ID = RandomData.RandomString(20);
                    this.Settings.BadgeId = RandomData.RandomString(15);
                    this.Settings.IsSelected = false;

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
            File.WriteAllText(this.settingsFilePath, settingsContent);
        }
    }
}
