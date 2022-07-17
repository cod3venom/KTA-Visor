using KTA_Visor_DSClient.module.camera.dto;
using KTA_Visor_DSClient.module.dashboard.view;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera.command
{
    public class CopyCameraFilesToNetworkStorageCommand
    {
        public static Dictionary<string, CopiedCameraFileTObject> Execute(Dictionary<string, FileInfo> files, string networkDriveLocation)
        {
            Dictionary<string, CopiedCameraFileTObject> copiedFiles = new Dictionary<string, CopiedCameraFileTObject>();

            if (networkDriveLocation == null)
                return copiedFiles;

            DirectoryInfo directory = new DirectoryInfo(networkDriveLocation);
            if (!directory.Exists)
                throw new Exception("Network drive location does not exists");

            foreach(KeyValuePair<string, FileInfo> kvp in files)
            {
                FileInfo file = kvp.Value;
                FileInfo destFile = new FileInfo(String.Format("{0}\\{1}", networkDriveLocation, file.Name));
                
                if (File.Exists(destFile.FullName))
                {
                    copiedFiles.Add(destFile.Name, new CopiedCameraFileTObject(destFile, false));
                    continue;
                }

                file.CopyTo(destFile.FullName);

                if (File.Exists(destFile.FullName) && destFile.Length == file.Length)
                {
                    file.Delete();

                    copiedFiles.Add(destFile.Name, new CopiedCameraFileTObject(destFile, true));
                }
            }

            return copiedFiles;
        }
    }
}
