using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.dto;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.command;
using KTA_Visor_DSClient.module.camera.repository;
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
    public class CameraService
    {
        private readonly Settings settings;

        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;

        private readonly CameraListViewRepository cameraRepository;

        public CameraService(USBCameraDeviceList<USBCameraDevice> camerasList)
        {
            this.settings = new Settings();
            this.camerasList = camerasList;
            this.cameraRepository = new CameraListViewRepository(camerasList);
        }

        public DockingStationTObject getDockingStation()
        {
            DockingStationTObject station = new DockingStationTObject();
            station.IpAddress = Network.GetLocalIPAddress();
            station.Cameras = this.camerasList.ToArray();

            return station;
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


        public DirectoryInfo copyFielsToNetworkStorage(string driveName)
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
