using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.module.Camera.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Dynamic;
using System.IO;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer
{
    public class FilesTransferManager : AbstractResource, ICameraHandler
    {
        public event EventHandler<Exception> OnTransferingExceptionOccured;

        private string _destination;
        private KTALogger.Logger _logger;

        public FilesTransferManager(Settings settings, string destination, KTALogger.Logger logger)
        {
            this._destination = destination;
            this._logger = logger;

            this._fileSystem = new abstractResources.filesystem.FileSystem(this._destination, this._logger);
            this._reporter = new abstractResources.reporter.Reporter(settings);
            this.hookEvents();
        }
 
        private void hookEvents()
        {
            this._fileSystem.OnTransferProgressChanged += onCopyingFilesProgressChanged;
            this._fileSystem.OnCopyingFinished += onFilesCopyingFinished;
        }
 

        public void Handle(USBCameraDevice camera)
        {
            this.copyFiles(camera);
        }

        private void copyFiles(USBCameraDevice camera)
        {
            this._fileSystem.MoveFilesToStorage(camera);
        }

        private void onCopyingFilesProgressChanged(object sender, OnTransferProgressChanged e)
        {
            dynamic response = new ExpandoObject();
            response.fileName = e.CurrentFile.FullName;
            response.progress = e.Progress;
            Globals.ClientTunnel.Emit(new Request(
                "response://camera/files/transfer/progress",
                 response
            ));

           this._logger.info(string.Format("COPYING: {0} => PROGRESS => {1}%", e.CurrentFile.FullName, e.Progress));     
        }

        private void onFilesCopyingFinished(object sender, OnFilesTransferingFinishedEvent e)
        {
            FileInfo reportFile = this._reporter.Report(e.Camera, e.Copied, e.Duplicates, e.Failed);
            Globals.ClientTunnel.Emit(new Request(
                "response://camera/transfer/report-created",
                reportFile
            ));
        }
    }
}
