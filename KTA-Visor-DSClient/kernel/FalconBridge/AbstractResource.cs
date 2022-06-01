using KTA_Visor_DSClient.kernel.FalconBridge.Resource.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge
{
    public abstract class AbstractResource
    {

        private readonly Falcon.FalconSdk sdk;

        public AbstractResource()
        {
            this.sdk = new Falcon.FalconSdk();
            this.sdk.ConnectToDevice();
        }
        public CameraService CameraService()
        { 
            return new CameraService(this.sdk);
        }
    }
}
