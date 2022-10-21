using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool;
using KTA_Visor_DSClient.module.Management.module.Camera.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.reports.TransferedFiles;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.camera.service;
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

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer
{
    public class CameraFilesTransferingHandler : ICameraHandler
    {
        public event EventHandler<Exception> OnTransferingExceptionOccured;

        private event EventHandler<Exception> _onDiskIsFull;
        private event EventHandler<OnFilesTransferingFinishedEvent> _onCopyingFinished;

        private USBCameraDevice _cameraDevice;

        private readonly FileManagerService _fileManagerService;
        private readonly string _destination;
        private readonly KTALogger.Logger _logger;
        private readonly TransferedFilesReport _transferedFilesReport;
        private bool _canCopy = true;
        private List<FileInfo> _filesToBeCopied;

        public CameraFilesTransferingHandler(string destination, KTALogger.Logger logger)
        {
            this._destination = destination;
            this._logger = logger;
            this._fileManagerService = new FileManagerService();
            this._transferedFilesReport = new TransferedFilesReport(this._logger);
            this.hookEvents();
        }


        private void hookEvents()
        {
            this._onDiskIsFull += onDiskIsFull;
            this._onCopyingFinished += onCopyingFinished;
        }

 
        public void Handle(USBCameraDevice cameraDevice)
        {
            this._cameraDevice = cameraDevice;

            if (this._destination == null || this._destination == "") {
                return;
            }

            if (!Directory.Exists(this._destination)) {
                throw new Exception("Network drive location does not exists");
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = false;
            
            ThreadPoolManager.Run(new Action(() => {
                this.CopyFilesWithParalels(this._cameraDevice.Files);
            }));

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;

        }

        private void CopyFilesWithParalels(List<FileInfo> files)
        {
            if (!this._canCopy){
                return;
            }

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

                        if (File.Exists(destinationFile.FullName)) {
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
                catch(IOException exception)
                {
                    failedFiles.Add(fileToBeCopied);

                    if (this.isDiskFull(exception)){
                        this._canCopy = false;
                        this._onDiskIsFull?.Invoke(this, exception);
                    } else {
                        Globals.Logger.error(exception.Message, exception);
                    }
                    Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
                }
            });

            this._onCopyingFinished(this, new OnFilesTransferingFinishedEvent(
                this._cameraDevice,
                Globals.STATION, 
                copiedFiles, 
                duplicateFiles,
                failedFiles
            ));
        }

        /// <summary>
        /// Copy file based on FileStream
        /// Class, which is much faster than
        /// File.Copy method
        /// </summary>
        /// <param name="file"></param>
        /// <param name="destinationFile"></param>
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

        private void addTransferedFileToBackend(FileInfo originFile, FileInfo destFile)
        {
 
            string checkSum = FileChecksum.checkMD5(destFile.FullName);
            _ = this._fileManagerService.create(new CreateFileHistoryRequestTObject(
                Globals.STATION.data?.stationId,
                this._cameraDevice.ID,
                this._cameraDevice.BadgeId,
                originFile.Name,
                originFile.FullName,
                destFile.FullName,
                destFile.Length,
                checkSum
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



        private void onCopyingFinished(object sender, OnFilesTransferingFinishedEvent e)
        {
            this._transferedFilesReport.Report(e);
        }

        private void onDiskIsFull(object sender, Exception e)
        {
            this._logger.error("Unable to copy more files, DISK IS FULL");
        }
    }
}
