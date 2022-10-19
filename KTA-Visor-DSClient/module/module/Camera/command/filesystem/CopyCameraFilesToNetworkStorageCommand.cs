
using KTA_Visor_DSClient.module.Management.module.Camera.dto;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.fileManager.dto.request;
using KTAVisorAPISDK.module.fileManager.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.command.filesystem
{
    public class CopyCameraFilesToNetworkStorageCommand
    {
        public static Dictionary<string, CopiedCameraFileTObject> Execute(
            string stationCustomId,
            string cameraCustomId,
            string badgeId, 
            Dictionary<string, FileInfo> files, 
            string networkDriveLocation
        )
        {
            Dictionary<string, CopiedCameraFileTObject> copiedFiles = new Dictionary<string, CopiedCameraFileTObject>();

            if (networkDriveLocation == null || networkDriveLocation == "")
                return copiedFiles;

            DirectoryInfo directory = new DirectoryInfo(networkDriveLocation);
            if (!directory.Exists)
                throw new Exception("Network drive location does not exists");

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;
            foreach (KeyValuePair<string, FileInfo> kvp in files)
            {
                FileInfo file = kvp.Value;
                FileInfo destFile = new FileInfo(String.Format("{0}\\{1}", networkDriveLocation, file.Name));

                Console.WriteLine("Kopiowanie pliku: " + file.Name);
                Thread.Sleep(100);
                
                if (File.Exists(destFile.FullName))
                {
                    copiedFiles.Add(destFile.Name, new CopiedCameraFileTObject(destFile, false));
                }

               else
                {
                    file.CopyTo(destFile.FullName);
                }

                if (File.Exists(destFile.FullName) && destFile.Length == file.Length)
                {
                    file.Delete();

                    if (copiedFiles.ContainsKey(destFile.Name)){
                        continue;
                    }


                    copiedFiles.Add(destFile.Name, new CopiedCameraFileTObject(destFile, true));
                   // FileManagerService fileManagerService= new FileManagerService();

                    //_ = fileManagerService.create(new CreateFileHistoryRequestTObject(
                    //    stationCustomId,
                    //    cameraCustomId,
                    //    badgeId,
                    //    file.Name,
                    //    file.FullName,
                    //    destFile.FullName,
                    //    destFile.Length
                    //));

                    Globals.Logger.success(String.Format("Successfully copied File {0} from the {1} to the {2} folder", file.Name, file.DirectoryName, networkDriveLocation));
                }
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
            return copiedFiles;
        }
    }
}
