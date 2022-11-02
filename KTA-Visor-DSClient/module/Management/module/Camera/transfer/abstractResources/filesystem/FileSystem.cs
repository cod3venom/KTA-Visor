using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.command;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.events;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.helper;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.fileManager.dto.request;
using KTAVisorAPISDK.module.fileManager.service;
using System;
using System.Collections.Generic;
using System.IO;


namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem
{
    public class FileSystem
    {
        public event EventHandler<OnTransferProgressChanged> OnTransferProgressChanged;
        public event EventHandler<OnFilesTransferingFinishedEvent> OnCopyingFinished;

        private USBCameraDevice _cameraDevice;
        private readonly FileManagerService _fileManagerService;
        private readonly RecordingsSegregator _recordingsSegregator;
        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;
 

        public FileSystem(Settings settings, KTALogger.Logger logger)
        {
            this._settings = settings;
            this._logger = logger;
            this._fileManagerService = new FileManagerService();
            this._recordingsSegregator = new RecordingsSegregator();
        }

        public void MoveFilesToStorage(USBCameraDevice cameraDevice)
        {
            this._cameraDevice = cameraDevice;
            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;
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
                        CopyFilesCommand.Execute(file, destinationFile);

                        if (File.Exists(destinationFile.FullName))
                        {
                            copiedFiles.Add(file);
                            this.addTransferedFileToBackend(file, destinationFile);
                            file.Delete();
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
                finally
                {
                    //this.segergateRecordings();
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


        
        private void segergateRecordings()
        {
            this._recordingsSegregator.Segregate(this._cameraDevice.Gallery);
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
    }
}
