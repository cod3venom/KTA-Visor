using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.dto.request;
using KTAVisorAPISDK.module.camera.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.observer
{
    public class CamerasAutoSyncObserver : IObserverInterface
    {
        private readonly CameraSyncService _cameraSyncService;
        public CamerasAutoSyncObserver()
        {
            this._cameraSyncService = new CameraSyncService();
        }

        public void Observe()
        {
            Thread autoSyncThread = new Thread(() => this.autoSync());
            autoSyncThread.IsBackground = true;
            autoSyncThread.Start();
        }

        private void autoSync()
        {
        }
    }
}
