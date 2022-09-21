using KTA_Visor_DSClient.module.Management.module.Camera.Resource.Device.exception;
using KTA_Visor_DSClient.kernel.helper;
using Falcon;
using Falcon.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KTA_Visor_DSClient.kernel.generator;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice.localSettings;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice
{
    public class USBCameraDevice : USBCameraDeviceSettings
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public USBCameraDevice(DriveInfo device, string serialNumber, int index = 0):base(device)
        {
            this.Index = index;
            this.ID = this.Settings.ID;
            this.Name = device.Name;
            this.Drive = device;
            this.BadgeId = this.Settings.BadgeId;
            this.SerialNumber = serialNumber;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public USBCameraDevice(DriveInfo device,  int index = 0) : base(device)
        {
            this.Index = index;
            this.ID = this.Settings.ID;
            this.Name = device.Name;
            this.Drive = device;
            this.BadgeId = this.Settings.BadgeId;
            this.SerialNumber = "";
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Drive")]
        public DriveInfo Drive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Files")]
        public FileInfo[] Files
        {
            get { return this.getFiles(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string BadgeId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DiskUsage
        {
            get { return this.getDiskUsage();  }
        }

        public int RelayPort { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DriveInfo getDriveInfo()
        {
            return this.Drive;
        }
 

        public USBCameraDevice Select()
        {
            this.Settings.IsSelected = true;
            this.SaveSettings();
            return this;
        }

        public USBCameraDevice Deselect()
        {
            this.Settings.IsSelected = false;
            this.SaveSettings();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getDiskUsage()
        {
            string totalSpaceGB = FileSizeHelper.convertSize(this.Drive.TotalSize);
            string usedSpaceGB = FileSizeHelper.convertSize(this.Drive.AvailableFreeSpace);

            return string.Format("{0}/{1}", usedSpaceGB.ToString(), totalSpaceGB.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FileInfo[] getFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(this.Drive + @"\DCIM\100MEDIA\");
            if (!directory.Exists) return new FileInfo[] { };

            return directory.GetFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        /// <exception cref="CameraUSBDeviceDirectoryNotFoundException"></exception>
        public USBCameraDevice copyFilesTo(string destination)
        {
            if (!Directory.Exists(destination)) 
                throw new CameraUSBDeviceDirectoryNotFoundException("Destination folder not found");

            DirectoryInfo destinationDir = new DirectoryInfo(destination);

            foreach(FileInfo file in this.getFiles())
            {
                if (!file.Exists) continue;
                if (destinationDir.GetFiles().Contains(file)) continue;

                destination = String.Format("{0}{1}", destination, file.Name);
                File.Copy(file.FullName, destination);
            }
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            return new StringBuilder()
                .Append("<USBCameraDevice: ")
                .Append("SerialNumber: " + this.SerialNumber)
                .Append(", DriveLetter: " + this.Drive?.Name)
                .Append(", TotalFiles: " + this.getFiles().Length)
                .Append("/>")
                .ToString();
        }

         
    }
}
