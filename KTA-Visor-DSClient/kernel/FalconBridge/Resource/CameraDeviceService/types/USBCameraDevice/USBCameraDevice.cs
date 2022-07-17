using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device.exception;
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

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice
{
    public class USBCameraDevice
    {
        /// <summary>
        /// 
        /// </summary>
        private DriveInfo device;

        /// <summary>
        /// 
        /// </summary>
        private string serialNumber = "";


        /// <summary>
        /// 
        /// </summary>
        private readonly FalconSdk sdk;

        /// <summary>
        /// 
        /// </summary>
        public USBCameraDevice() 
        {
            this.sdk = new FalconSdk();
        }

        /// <summary>
        /// 
        /// </summary>
        public FalconSdk SDK
        {
            get { return this.sdk; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public USBCameraDevice(DriveInfo device, string serialNumber = "", string name = "")
        {
            this.device = device;
            this.serialNumber = serialNumber;
            this.Name = name;
            this.sdk = new FalconSdk();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        public USBCameraDevice(string serialNumber)
        {
            this.serialNumber = serialNumber;
            this.device = new DriveInfo("c");
            this.sdk = new FalconSdk();
        }

         
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Drive")]
        public DriveInfo Drive
        {
            get { return device; }
            set { device = value; }
        }

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
        [JsonProperty("serialNumber")]
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DiskUsage
        {
            get { return this.getDiskUsage();  }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DriveInfo getDriveInfo()
        {
            return this.device;
        }
 

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string getDiskUsage()
        {
            string totalSpaceGB = FileSizeHelper.convertSize(this.device.TotalSize);
            string usedSpaceGB = FileSizeHelper.convertSize(this.device.AvailableFreeSpace);

            return string.Format("{0}/{1}", usedSpaceGB.ToString(), totalSpaceGB.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FileInfo[] getFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(this.device + @"\DCIM\100MEDIA\");
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
                .Append("SerialNumber: " + this.serialNumber)
                .Append(", DriveLetter: " + this.device?.Name)
                .Append(", TotalFiles: " + this.getFiles().Length)
                .Append("/>")
                .ToString();
        }

         
    }
}
