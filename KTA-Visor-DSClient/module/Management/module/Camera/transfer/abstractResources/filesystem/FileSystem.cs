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
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem
{
    public class FileSystem
    {
        public event EventHandler<OnFilesTransferingFinishedEvent> OnCopyingFinished;

        private USBCameraDevice _cameraDevice;
        private readonly FileManagerService _fileManagerService;
        private List<FileInfo> _filesToBeCopied;
        private bool _canCopy = true;

        private readonly string _destination;
        private readonly KTALogger.Logger _logger;

        public FileSystem(string destination, KTALogger.Logger logger)
        {
            this._destination = destination;
            this._logger = logger;
            this._fileManagerService = new FileManagerService();
        }


        public void MoveFilesToStorage(USBCameraDevice cameraDevice)
        {
            this._cameraDevice = cameraDevice;

            if (!Directory.Exists(this._destination)){
                throw new Exception("Network drive location does not exists");
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;

            this.CopyFilesWithParalels(this._cameraDevice.Files);
            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
        }

        private void CopyFilesWithParalels(List<FileInfo> files)
        {
            this._filesToBeCopied = files;

            List<FileInfo> copiedFiles = new List<FileInfo>();
            List<FileInfo> duplicateFiles = new List<FileInfo>();
            List<FileInfo> failedFiles = new List<FileInfo>();

            ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
            Parallel.ForEach(this._filesToBeCopied, options, fileToBeCopied => {

                try
                {
                    if (!this._canCopy){
                        return;
                    }

                    FileInfo destinationFile = new FileInfo(String.Format("{0}\\{1}", this._destination, fileToBeCopied.Name));

                    if (!File.Exists(destinationFile.FullName))
                    {
                        this._logger.info(string.Format("Transfering {0} >> to >> {1}", fileToBeCopied.Name, destinationFile.FullName));
                        this.copyFile(fileToBeCopied, destinationFile);

                        if (File.Exists(destinationFile.FullName))
                        {
                            copiedFiles.Add(fileToBeCopied);
                            this.addTransferedFileToBackend(fileToBeCopied, destinationFile);

                            //file.Delete();
                        }
                    }
                    else
                    {
                        duplicateFiles.Add(fileToBeCopied);
                    }

                }
                catch (IOException exception)
                {
                    failedFiles.Add(fileToBeCopied);
                    Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;                
                }
            });

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
                }
            }
        }



        protected void addTransferedFileToBackend(FileInfo originFile, FileInfo destFile)
        {
            _ = this._fileManagerService.create(new CreateFileHistoryRequestTObject(
                Globals.STATION.data?.stationId,
                this._cameraDevice.ID,
                this._cameraDevice.BadgeId,
                originFile.Name,
                originFile.FullName,
                destFile.FullName,
                destFile.Length,
                FileChecksum.checkMD5(destFile.FullName)
            ));
        }

        /// <summary>
        /// Current method checks if there is enought
        /// space on disk to copy file
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private bool isDiskFull(Exception ex)
        {
            const int ERROR_HANDLE_DISK_FULL = 0x27;
            const int ERROR_DISK_FULL = 0x70;

            int win32ErrorCode = Marshal.GetHRForException(ex) & 0xFFFF;
            return win32ErrorCode == ERROR_HANDLE_DISK_FULL || win32ErrorCode == ERROR_DISK_FULL;
        }
    }
}
