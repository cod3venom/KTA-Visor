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
        /// <summary>
        /// 
        /// </summary>
        private readonly DriveInfo driveInfo;

        /// <summary>
        /// 
        /// </summary>
        private readonly FileInfo settingsFileOnDrive;

        private readonly FileInfo IDFileOnDrive;

        /// <summary>
        /// 
        /// </summary>
        protected string cameraId = "";

        /// <summary>
        /// 
        /// </summary>
        protected string cameraBadgeId = "";
        
        
        /// <summary>
        /// 
        /// </summary>
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
                File.WriteAllText(this.settingsFileOnDrive.FullName, this.Settings.ID);
            }
            else
            {
                string idFileContent = File.ReadAllText(this.IDFileOnDrive.FullName).Replace(Environment.NewLine, "");
                if (idFileContent != this.Settings.ID)
                {
                    File.WriteAllText(this.IDFileOnDrive.FullName, idFileContent);
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

            string settingsContent = JsonConvert.SerializeObject(settings);
            File.WriteAllText(this.settingsFileOnDrive.FullName, settingsContent);
        }
    }
}
