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
        private Thread deviceListenerThr;


        /// <summary>
        /// 
        /// </summary>
        public CameraDeviceServiceWrapper(KTALogger.Logger logger)
        {
            this.logger = logger;
            this._falconBridge = new FalconBridge();
            this._deviceService = this._falconBridge.CameraDeviceService(this.logger);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            this.initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        private void initialize()
        {

            this._deviceService.OnCameraConnectedEvent += onCameraConnectedEvt;
            this._deviceService.OnCameraDisconnectedEvent += onCameraDisconnectedEvent;

            this.deviceListenerThr = new Thread(() => this._deviceService.listenForConnection());
            this.deviceListenerThr.IsBackground = true;
            this.deviceListenerThr.Start();
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
