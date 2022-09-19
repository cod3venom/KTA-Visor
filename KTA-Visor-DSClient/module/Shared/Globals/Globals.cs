using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTAVisorAPISDK.module.camera.entity;
using KTAVisorAPISDK.module.station.entity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KTA_Visor_DSClient.module.Shared.Globals
{
    public class Globals
    {

        public static Settings settings;
        public static USBDeviceRelay Relay;
        public static KTALogger.Logger Logger;
        
        public static bool IS_IN_SETTINGS_MODE = false; 
        
        public static StationEntity STATION = new StationEntity();
        public static List<CameraEntity> ACTIVE_CAMERAS = new List<CameraEntity>();


        public static ObservableCollection<USBCameraDevice> CAMERAS_LIST = new ObservableCollection<USBCameraDevice>();
        public static bool IS_ALL_COPYING_PROCESS_ARE_END = true;

        public static bool IS_CONNECTED_TO_TUNNEL = false;

        public static bool ALLOW_LISTENING_FOR_POWER_SUPPLY = false;



    }
}
