using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.handler;
using KTA_Visor_DSClient.module.Management.module.Camera.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Management.module.Camera.transfer;
using KTA_Visor_DSClient.module.Management.module.Camera.types.device.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.observer
{
    public class CamerasListObserver : IObserverInterface
    {
        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;
        private readonly CameraBackendSyncHandler _cameraBackendSyncHandler;
        private readonly FilesTransferManager _cameraFilesTransferingHandler;
        public CamerasListObserver(Settings settings, KTALogger.Logger logger)
        {
            this._settings = settings;
            this._logger = logger;

            this._cameraBackendSyncHandler = new CameraBackendSyncHandler();
            this._cameraFilesTransferingHandler = new FilesTransferManager(
                this._settings,
                this._settings.SettingsObj?.app?.fileSystem?.filesPath,
                logger
            );
        }

        public void Observe()
        {
            Globals.CAMERAS_LIST.OnCameraAddedInMemory += onCameraAddedToTheMemory;
            Globals.CAMERAS_LIST.OnCameraRemovedFromMemory += onCameraRemovedFromTheMemory;
        }

       
        private void onCameraAddedToTheMemory(object sender, CameraAddedToTheMemoryEvent e)
        {
            this._cameraBackendSyncHandler.Handle(e.Camera);
            this._cameraFilesTransferingHandler?.Handle(e.Camera);
        }

        private void onCameraRemovedFromTheMemory(object sender, CameraRemovedFromTheMemoryEvent e)
        {
            this._cameraBackendSyncHandler.Handle(e.Camera);
        }
    }
}
