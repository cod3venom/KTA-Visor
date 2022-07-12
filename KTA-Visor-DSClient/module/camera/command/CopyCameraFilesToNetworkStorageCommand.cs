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
        public static DirectoryInfo Execute(Dictionary<string, FileInfo> files, string networkDriveLocation)
        {
            DirectoryInfo directory = new DirectoryInfo(networkDriveLocation);
            if (!directory.Exists)
                throw new Exception("Network drive location does not exists");

            foreach(KeyValuePair<string, FileInfo> kvp in files)
            {
                FileInfo file = kvp.Value;
                FileInfo destFile = new FileInfo(String.Format("{0}\\{1}", networkDriveLocation, file.Name));
                
                if (File.Exists(destFile.FullName)) continue;
                file.CopyTo(destFile.FullName);

                if (File.Exists(destFile.FullName) && destFile.Length == file.Length)
                {
                    file.Delete();
                }
            }

            return directory;
        }
    }
}
