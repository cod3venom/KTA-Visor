using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.fileManager.dto.request;
using KTAVisorAPISDK.module.fileManager.service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem
{
    public class FileSystem
    {
        public event EventHandler<OnTransferProgressChanged> OnTransferProgressChanged;
        public event EventHandler<OnFilesTransferingFinishedEvent> OnCopyingFinished;

        private USBCameraDevice _cameraDevice;
        private readonly FileManagerService _fileManagerService;

        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;

        private long _totalFilesSize = 0;
        private long _totalCopiedSize = 0;

        public FileSystem(Settings settings, KTALogger.Logger logger)
        {
            this._settings = settings;
            this._logger = logger;
            this._fileManagerService = new FileManagerService();
        }

        public void MoveFilesToStorage(USBCameraDevice cameraDevice)
        {
            this._cameraDevice = cameraDevice;

            //if (Directory.EnumerateDirectories(this._destination).Count == 0){
            //    throw new Exception("Network drive location does not exists");
            //}

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;
            this._totalFilesSize = this._cameraDevice.Files.Sum(file => Convert.ToInt32(file.Length));

            this.CopyFilesWithParalels(this._cameraDevice.Files);
            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
        }

        private void CopyFilesWithParalels(List<FileInfo> files)
        {

            List<FileInfo> copiedFiles = new List<FileInfo>();
            List<FileInfo> duplicateFiles = new List<FileInfo>();
            List<FileInfo> failedFiles = new List<FileInfo>();

            foreach(FileInfo file in files)
            {
                try
                {
                    FileInfo destinationFile = new FileInfo(String.Format(
                        "{0}\\{1}",
                        this._settings.SettingsObj?.app?.fileSystem?.recordingsPath,
                        file.Name
                    ));

                    if (!File.Exists(destinationFile.FullName))
                    {
                        this.copyFile(file, destinationFile);

                        if (File.Exists(destinationFile.FullName))
                        {
                            copiedFiles.Add(file);
                            this.addTransferedFileToBackend(file, destinationFile);
                            //file.Delete();
                        }
                    }
                    else
                    {
                        duplicateFiles.Add(file);
                    }

                }
                catch (IOException exception)
                {
                    failedFiles.Add(file);
                    Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
                }
            }
             

            this.OnCopyingFinished?.Invoke(this, new OnFilesTransferingFinishedEvent(
                this._cameraDevice,
                Globals.STATION,
                copiedFiles,
                duplicateFiles,
                failedFiles
            ));
        }


        private void copyFile(FileInfo file, FileInfo destinationFile)
        {
            int bufferSize = 1024 * 1024;

            using (FileStream fileStream = new FileStream(destinationFile.FullName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.ReadWrite);
                fileStream.SetLength(fs.Length);
                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                {
                    fileStream.Write(bytes, 0, bytesRead);
                    this._totalCopiedSize += bytesRead;

                    Thread progressThr = new Thread((ThreadStart) => {
                        this.OnTransferProgressChanged?.Invoke(this, new OnTransferProgressChanged(
                            file,
                            this._totalFilesSize,
                            this._totalCopiedSize
                        ));

                        Thread.Sleep(1000);
                    });
                    progressThr.IsBackground = true;
                    progressThr.Start();
                }

                file = new FileInfo(destinationFile.FullName);
                if (file.Exists)
                {
                    File.SetAttributes(file.FullName, FileAttributes.Hidden);
                }
                this._totalCopiedSize = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="originFile"></param>
        /// <param name="destFile"></param>
        protected void addTransferedFileToBackend(FileInfo originFile, FileInfo destFile)
        {
            _ = this._fileManagerService.create(new CreateFileHistoryRequestTObject(
                Globals.STATION.data?.stationId,
                this._cameraDevice.CustomId,
                this._cameraDevice.BadgeId,
                originFile.Name,
                originFile.FullName,
                destFile.FullName,
                destFile.Length,
                FileChecksum.checkMD5(destFile.FullName)
            ));
        }

        
        protected bool IsNetworkDriveExists()
        {
            string root = Directory.GetDirectoryRoot(this._settings.SettingsObj?.app?.fileSystem?.recordingsPath);
            DriveInfo drive = new DriveInfo(root);
            if (drive.DriveType == DriveType.Network)
            {
                return true;
            }
            return false;
        }
    }
}
