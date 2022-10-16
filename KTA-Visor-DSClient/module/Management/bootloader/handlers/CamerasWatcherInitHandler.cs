using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class CamerasWatcherInitHandler : IBootLoaderHandler
    {
        public static string HandlerName = "CamerasWatcherInitHandler";
        private readonly CameraDeviceWatcher _cameraDeviceWatcher;

        public CamerasWatcherInitHandler(Settings settings)
        {
            this._cameraDeviceWatcher = new CameraDeviceWatcher(settings);
        }

        public string GetName()
        {
            return CamerasWatcherInitHandler.HandlerName;
        }

        public void Handle()
        {
            this.runWatcher();
        }

        private void runWatcher()
        {
            this._cameraDeviceWatcher.Start();
        }
    }
}
