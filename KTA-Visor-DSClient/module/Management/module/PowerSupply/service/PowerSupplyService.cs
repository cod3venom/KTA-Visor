using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.service
{
    public class PowerSupplyService
    {

        public void TurnOff()
        {
            Globals.Relay.turnOffAll();
        }

        public async void Restart()
        {
            Globals.Relay.turnOffAll();
            await Task.Delay(5000);
            Globals.Relay.turnOnAll();
        }

    }
}
