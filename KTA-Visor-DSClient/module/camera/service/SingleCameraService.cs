using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.dto;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.command;
using KTA_Visor_DSClient.module.camera.dto;
using KTA_Visor_DSClient.module.camera.repository;
using KTA_Visor_DSClient.module.dashboard.componnets.CameraItem;
using KTA_Visor_DSClient.module.dashboard.view;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.helpers;

namespace KTA_Visor_DSClient.module.camera.service
{
    public class SingleCameraService
    {
        private readonly Settings settings;

        private readonly CameraListViewRepository cameraRepository;

        public SingleCameraService()
        {
            this.settings = new Settings();
            this.cameraRepository = new CameraListViewRepository();
        }
 

        public Dictionary<string, USBCameraDevice> CamerasDict
        {
           get { return this.cameraRepository.CamerasDict; }
        }

        public Dictionary<string, FileInfo> CameraFiles
        {
            get { return this.cameraRepository.CameraFiles; }
        }

        public Dictionary<string, FileInfo> FilesFromDrive(string driveName)
        {
             Dictionary<string, FileInfo> files = new Dictionary<string, FileInfo>();

            foreach(KeyValuePair<string, USBCameraDevice> camera in this.CamerasDict)
            {
                if (camera.Value.Drive.Name != driveName) continue; 

                foreach(FileInfo file in camera.Value.Files)
                {
                    files.Add(file.Name, file);
                }
            }
            return files;
            
        }


        public Dictionary<string, CopiedCameraFileTObject> copyFielsToNetworkStorage(string driveName)
        {
            Dictionary<string, FileInfo> files = this.FilesFromDrive(driveName);
            return CopyCameraFilesToNetworkStorageCommand.Execute(
                files,
                this.settings.SettingsObj.app?.fileSystem.networkStorage
            );
        }

        public float networkStorageUsedSpace
        {
            get
            {
                float size = 0;

                return 0;
            }
        }
    }
}
