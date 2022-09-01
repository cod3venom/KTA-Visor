using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
using KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge
{
    public abstract class AbstractResource
    {

     
        private readonly DeviceWatcher deviceWatcher;

        private readonly KTALogger.Logger logger;


        public AbstractResource(DeviceWatcher deviceWatcher, KTALogger.Logger logger)
        {
            this.deviceWatcher = deviceWatcher;
            this.logger = logger;

            this.Sdk = new Falcon.FalconSdk();
            this.CameraDeviceService = new CameraDeviceService(this.Sdk, ref this.deviceWatcher, this.logger);
        }

        public Falcon.FalconSdk Sdk { get; set; }
        public CameraDeviceService CameraDeviceService { get; set; }
    }
}
