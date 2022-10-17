using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
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

namespace KTA_Visor_DSClient.module.Management.module.Camera.handler
{
    public class CameraFilesTransferingHandler
    {
        public event EventHandler<Exception> OnTransferingExceptionOccured;

        private USBCameraDevice _cameraDevice;
        private CameraEntity _cameraEntity;
        private CameraService _cameraService;

        private readonly FileManagerService _fileManagerService;
        private readonly string _destination;
        private bool _canCopy = true;

        public CameraFilesTransferingHandler(string destination)
        {
            this._destination = destination;
            this._cameraService = new CameraService();
            this._fileManagerService = new FileManagerService();
        }

        public void AssignValues(USBCameraDevice cameraDevice, CameraEntity cameraEntity)
        {
            this._cameraDevice = cameraDevice;
            this._cameraEntity = cameraEntity;
        }

        public void Transfer()
        {
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

        private  void CopyFilesWithParalels(List<FileInfo> files)
        {
            try
            {
                if (!this._canCopy){
                    return;
                }

                List<string> totalCopiedFiles = new List<string>();
                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 10 };
                Parallel.ForEach(files, options, file => {

                    try
                    {
                        if (!this._canCopy){
                            return;
                        }

                        string destPath = String.Format("{0}\\{1}", this._destination, file.Name);

                        if (!File.Exists(destPath))
                        {
                            Globals.Logger.info(string.Format("Transfering {0} >> to >> {1}", file.Name, destPath));
                            file.CopyTo(destPath);

                            if (File.Exists(destPath))
                            {
                                totalCopiedFiles.Add(destPath);
                                this.addTransferedFileToBackend(file.FullName, destPath);

                                //file.Delete();
                            }
                        }

                    }
                    catch(IOException exception)
                    {
                        if (this.isDiskFull(exception))
                        {
                            this._canCopy = false;
                            Globals.Logger.error("Unable to copy more files, DISK IS FULL");
                        } else
                        {
                            Globals.Logger.error(exception.Message, exception);
                        }
                        Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
                    }

                });

                Globals.Logger.info(String.Format("Transfering procedure has been finished for: {0}", this._cameraDevice?.Drive?.Name));
                Globals.Logger.info(String.Format("Successfully copied {0} of {1} files", totalCopiedFiles.Count.ToString(), files.Count.ToString()));
            }
            catch (Exception exception)
            {
                Globals.Logger.error(exception.Message, exception);
                Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;

                this.OnTransferingExceptionOccured?.Invoke(this, exception);
            }

            Globals.IS_ALL_COPYING_PROCESS_ARE_END = true;
        }

        private void addTransferedFileToBackend(string fileOriginPath, string fileDestPath)
        {
            FileInfo originFile = new FileInfo(fileOriginPath);
            FileInfo destFile = new FileInfo(fileDestPath);
            string checkSum = FileChecksum.checkMD5(destFile.FullName);
            _ = this._fileManagerService.create(new CreateFileHistoryRequestTObject(
                this._cameraEntity?.data?.stationId,
                this._cameraEntity?.data?.cameraCustomId,
                this._cameraEntity?.data?.badgeId,
                originFile.Name,
                originFile.FullName,
                destFile.FullName,
                destFile.Length,
                checkSum
            ));
        }

        private bool isDiskFull(Exception ex)
        {
            const int ERROR_HANDLE_DISK_FULL = 0x27;
            const int ERROR_DISK_FULL = 0x70;

            int win32ErrorCode = Marshal.GetHRForException(ex) & 0xFFFF;
            return win32ErrorCode == ERROR_HANDLE_DISK_FULL || win32ErrorCode == ERROR_DISK_FULL;
        }

    }
}
