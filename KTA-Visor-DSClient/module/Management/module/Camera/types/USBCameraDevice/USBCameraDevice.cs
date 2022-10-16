using KTA_Visor_DSClient.module.Management.module.Camera.Resource.Device.exception;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice.localSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        private string getDiskUsage()
        {
            string totalSpaceGB = FileSizeHelper.convertSize(this.Drive.TotalSize);
            string usedSpaceGB = FileSizeHelper.convertSize(this.Drive.AvailableFreeSpace);

            return string.Format("{0}/{1}", usedSpaceGB.ToString(), totalSpaceGB.ToString());
        }

        public List<FileInfo> Files
        {
            get
            {
                DirectoryInfo directory = new DirectoryInfo(this.Drive + @"\DCIM\100MEDIA\");
                if (!directory.Exists) return new List<FileInfo>() { };

                return directory.GetFiles().ToList();
            }
        }
         
    }
}
