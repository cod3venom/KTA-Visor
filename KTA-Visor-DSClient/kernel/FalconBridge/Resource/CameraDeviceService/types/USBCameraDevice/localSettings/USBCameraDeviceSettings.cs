using KTA_Visor_DSClient.kernel.generator;
using KTA_Visor_DSClient.kernel.helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice.localSettings
{
    public class USBCameraDeviceSettings
    {

        private readonly DriveInfo driveInfo;
        private readonly FileInfo settingsFileOnDrive;
        private readonly FileInfo IDFileOnDrive;

        /// <summary>
        /// 
        /// </summary>
        protected string cameraId = "";
        protected string cameraBadgeId = "";
        public LocalSettingsTObject Settings { get; set; }

        public USBCameraDeviceSettings(DriveInfo drive)
        {
            this.driveInfo = drive;
            this.settingsFileOnDrive = new FileInfo(driveInfo.Name + "LocalSettings.json");
            this.IDFileOnDrive = new FileInfo(drive.Name + "ID.txt");
            this.Settings = new LocalSettingsTObject();

            this.initialize();
        }
       
        private void initialize()
        {
            this.calibrateFileExistence();
            this.calibrateSettingsReader();
        }


        private FileInfo calibrateFileExistence()
        {
            if (!this.settingsFileOnDrive.Exists)
            {
                this.Settings.ID = RandomData.RandomString(20);
                this.Settings.BadgeId = RandomData.RandomString(15);
                this.Settings.IsSelected = false;
                this.SaveSettings();
            }
            else
            {
                using (StreamReader reader = new StreamReader(this.settingsFileOnDrive.FullName))
                {
                    string settingsFromFile = reader.ReadToEnd();
                    this.Settings = JsonConvert.DeserializeObject<LocalSettingsTObject>(settingsFromFile);
                    reader.Close();
                }
            }

            if (!this.IDFileOnDrive.Exists)
            {
                using(StreamWriter writer = new StreamWriter(this.IDFileOnDrive.FullName))
                {
                    writer.WriteLine(this.Settings.ID);
                    writer.WriteLine(this.Settings.BadgeId);
                    writer.Close();

                }
            }
            else
            {
                string idFileContent = File.ReadAllText(this.IDFileOnDrive.FullName).Split('\n')[0];
                if (idFileContent != this.Settings.ID)
                {
                    using (StreamWriter writer = new StreamWriter(this.IDFileOnDrive.FullName))
                    {
                        writer.Write(string.Format("{0}\n {1}", this.Settings.ID, this.Settings.BadgeId));
                        writer.Close();
                    }
                }
            }
            return this.settingsFileOnDrive;
        }

        private LocalSettingsTObject calibrateSettingsReader()
        {
            using(StreamReader reader = new StreamReader(this.settingsFileOnDrive.FullName))
            {
                string settingsFromFile = reader.ReadToEnd();
                this.Settings = JsonConvert.DeserializeObject<LocalSettingsTObject>(settingsFromFile);
                reader.Close();
            }
            return this.Settings;
        }

        public void SaveSettings(LocalSettingsTObject settings = null)
        {
            if (settings == null)
            {
                settings = this.Settings;
            }

            if (!File.Exists(this.settingsFileOnDrive.FullName))
                return;
            string settingsContent = JsonConvert.SerializeObject(settings);
            File.WriteAllText(this.settingsFileOnDrive.FullName, settingsContent);
        }

   
    }
}
