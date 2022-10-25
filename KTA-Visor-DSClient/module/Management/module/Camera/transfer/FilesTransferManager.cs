using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.helper;
using KTA_Visor_DSClient.kernel.sharedKernel.ThreadPool;
using KTA_Visor_DSClient.module.Management.module.Camera.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.reports.TransferedFiles;
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
