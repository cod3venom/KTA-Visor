using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;

namespace KTA_Visor_DSClient.module.Shared.Globals
{
    public class Globals
    {

        public static Settings settings;
        public static USBDeviceRelay Relay;
        public static KTALogger.Logger Logger;
        public static ClientTunnel ClientTunnel;
        
        public static StationEntity STATION = new StationEntity();
        public static USBCameraDeviceList CAMERAS_LIST = new USBCameraDeviceList();

        public static bool IS_IN_SETTINGS_MODE = false;
        public static bool IS_ALL_COPYING_PROCESS_ARE_END = true;
        public static bool IS_CONNECTED_TO_TUNNEL = false;
        public static bool ALLOW_LISTENING_FOR_POWER_SUPPLY = false;
        public static bool ALLOW_FS_MOUNTING = true;
        public static bool ALLOW_ONLY_SELECTED_CAMERA = false;

    }
}
