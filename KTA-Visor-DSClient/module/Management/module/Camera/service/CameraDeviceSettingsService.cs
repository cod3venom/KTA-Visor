using Falcon_Protocol;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay.events;
using KTA_Visor_DSClient.module.Management.module.Camera;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.module.camera.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Falcon_Protocol.interop.FalconProtocolInteropService;

namespace KTA_Visor_DSClient.module.Management.module.Camera.service
{
    public class CameraDeviceSettingsService
    {
        private readonly FalconProtocol falconProtocol;
        private USBCameraDevice selectedCameraDevice;
        private int selectedCameraPortNumber = -1;

        public CameraDeviceSettingsService()
        {
            this.falconProtocol = new FalconProtocol();
        }


        private void onFoundPortNumberByBadgeId(object sender, OnFoundPortByBadgeId e)
        {
            this.selectedCameraDevice = e.Camera;
            this.selectedCameraPortNumber = e.PortNumber;

            Globals.Relay.turnOffAll();
            Globals.Relay.turnOnByPort(this.selectedCameraPortNumber);
        }
        
 

        public MENU_CONFIG GetMenuConfig( int index = -1)
        {
            this.falconProtocol.SetIndex(index);
            return this.falconProtocol.GetMenuConfig();
        }

        public void SetMenuConfig(CameraEntity.Camera camera)
        {
            if (!Globals.IS_ALL_COPYING_PROCESS_ARE_END)
                return;

            USBCameraDevice device = Globals.CAMERAS_LIST.ToList().Find((USBCameraDevice dev) => dev.Drive.Name.Contains(camera.driveName));
            if (device == null)
                return;

            Globals.ALLOW_FS_MOUNTING = false;
            int portNumber = Globals.Relay.findPortByBadgeId(device.BadgeId);

            if (portNumber == -1)
            {
                Globals.Logger.error(String.Format("Unable to find selected cameras port number: returned {0}", portNumber.ToString()));
                Globals.Relay.turnOnAll();
                return;
            }
            Globals.Relay.turnOffAll();

            Thread.Sleep(8000);
            Globals.Relay.turnOnByPort(portNumber);

            Thread.Sleep(8000);
            this.falconProtocol.Connect();
         
            var menuStruct = this.falconProtocol.GetMenuConfig(device.Index);
            var zfyInfo = this.falconProtocol.GetDeviceInfo(device.Index);

            menuStruct.video_res = Convert.ToByte(camera.settings.resolution);
            menuStruct.video_quality = Convert.ToByte(camera.settings.quality);
            menuStruct.video_format = Convert.ToByte(camera.settings.codecFormat);
            menuStruct.time_zone = Convert.ToByte(camera.settings.timeZone);
            menuStruct.wifi = Convert.ToByte(camera.settings.wifi);
            menuStruct.aes_crypto = Convert.ToByte(camera.settings.aesEncryption);
            menuStruct.gps = Convert.ToByte(camera.settings.gps);
            menuStruct.wifi = Convert.ToByte(camera.settings.wifi);
            menuStruct.rec_warning = Convert.ToByte(camera.settings.silentMode);

            zfyInfo.userNo = Encoding.ASCII.GetBytes(camera.badgeId);
            zfyInfo.cSerial = camera.cameraCustomId.ToCharArray();

            device.Settings.ID = camera.cameraCustomId;
            device.Settings.BadgeId = camera.badgeId;
            device.SaveSettings();

            this.falconProtocol.SetMenuConfig(menuStruct, device.Index);
            this.falconProtocol.SetDeviceInfo(zfyInfo, device.Index);

            Globals.ALLOW_FS_MOUNTING = true;
            Globals.Relay.turnOffAll();
            Thread.Sleep(10000);
            Globals.Relay.turnOnAll();
        }


    }
}
