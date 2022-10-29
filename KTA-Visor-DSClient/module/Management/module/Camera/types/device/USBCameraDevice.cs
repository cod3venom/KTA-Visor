using KTA_Visor_DSClient.module.Management.module.Camera.Resource.Device.exception;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device.localSettings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device
{
    public class USBCameraDevice : USBCameraDeviceSettings
    {


        public USBCameraDevice(DriveInfo device):base(device)
        {
            this.ID = this.Settings.ID;
            this.MarkerId = this.Settings.MarkerId;
            this.CustomId = this.Settings.CustomId;
            this.Name = device.Name;
            this.Drive = device;
            this.BadgeId = this.Settings.BadgeId;
            this.CardId = this.Settings.CardId;
        }


        public DriveInfo Drive { get; set; }
        public int Index { get; set; }
        public int ID { get; set; }
        public string MarkerId { get; set; }
        public string CustomId { get; set; }
        public string BadgeId { get; set; }
        public string CardId { get; set; }
        public string Name { get; set; }
        public string DiskUsage 
        {
            get 
            {
                string totalSpaceGB = FileSizeHelper.convertSize(this.Drive.TotalSize);
                string usedSpaceGB = FileSizeHelper.convertSize(this.Drive.AvailableFreeSpace);

                return string.Format("{0}/{1}", usedSpaceGB.ToString(), totalSpaceGB.ToString());
            }
        }
        public int RelayPort { get; set; }
        public bool Active { get; set; }
        public List<FileInfo> Files
        {
            get
            {
                DirectoryInfo directory = new DirectoryInfo(this.Drive + @"\DCIM\100MEDIA\");
                if (!directory.Exists) return new List<FileInfo>() { };

                return directory.GetFiles().ToList();
            }
        }
         
        public void Blink(int interval = 10)
        {

        }
    }
}
