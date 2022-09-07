using KTA_Visor_DSClient.kernel.FalconBridge;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Camera.events;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera.service
{
    public class CameraDeviceServiceWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CameraConnectedEvent> OnCameraConnectedEvent;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CameraDisconnectedEvent> OnCameraDisconnectedEvent;

        /// <summary>
        /// 
        /// </summary>
        private readonly DeviceWatcher deviceWatcher;

        /// <summary>
        /// 
        /// </summary>
        private readonly FalconBridge _falconBridge;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly CameraDeviceService _deviceService;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly KTALogger.Logger logger;


        /// <summary>
        /// 
        /// </summary>
        public CameraDeviceServiceWrapper(DeviceWatcher deviceWatcher, KTALogger.Logger logger)
        {
            this.deviceWatcher = deviceWatcher;
            this.logger = logger;
            this._falconBridge = new FalconBridge(deviceWatcher, logger);
            this._deviceService = this._falconBridge.CameraDeviceService;
        }

        /// <summary>
        /// 
        /// </summary>
        public async void Start()
        {
            this._deviceService.OnCameraConnectedEvent += onCameraConnectedEvt;
            this._deviceService.OnCameraDisconnectedEvent += onCameraDisconnectedEvent;

            Thread thr = new Thread((ThreadStart)async delegate
            {
                while (true)
                {
                    await Task.Delay(2000);
                    this._deviceService.mountDevices();
                }
            });

            thr.IsBackground = true;
            thr.Start();
        }


        /// <summary>
        /// 
        /// </summary>
        public void mountDevices()
        {
            this._deviceService.mountDevices();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onCameraConnectedEvt(object sender, CameraConnectedEvent e)
        {
            this.OnCameraConnectedEvent?.Invoke(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onCameraDisconnectedEvent(object sender, CameraDisconnectedEvent e)
        {
            this.OnCameraDisconnectedEvent?.Invoke(sender, e);
        }
    }
}
