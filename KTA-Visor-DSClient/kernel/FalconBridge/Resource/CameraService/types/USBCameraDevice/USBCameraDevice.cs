using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device.exception;
using KTA_Visor_DSClient.kernel.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice
{
    public class USBCameraDevice
    {
        private DriveInfo device;

        private string serialNumber = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        public USBCameraDevice(DriveInfo device, string serialNumber = "")
        {
            this.device = device;
            this.serialNumber = serialNumber;
        }

        public USBCameraDevice(string serialNumber)
        {
            this.serialNumber = serialNumber;
            this.device = new DriveInfo("c");
        }
 
        public DriveInfo Drive
        {
            get { return device; }
            set { device = value; }
        }

        public FileInfo[] Files
        {
            get { return this.getFiles(); }
        }
        
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

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

            FileInfo[] directoryFiles = directory.GetFiles();
            FileInfo[] files = new FileInfo[directoryFiles.Length];
 
            for(int i = 0; i < directoryFiles.Length; i++)
            {
                string fullPath = String.Format(@"{0}\\DCIM\100MEDIA\{1}", this.device, directoryFiles[i].Name);
                FileInfo newFIle = new FileInfo(fullPath);
                files[i] = newFIle;
            }
            return files;
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
