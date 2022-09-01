using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.Management.module.Camera.entity;
using KTA_Visor_DSClient.module.Management.module.Station.entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Shared.Globals
{
    public class Globals
    {
        public static bool IS_IN_SETTINGS_MODE = false; 
        
        public static StationEntity STATION = new StationEntity();
        public static List<CameraEntity> BACKEND_CURRENT_CAMERAS = new List<CameraEntity>();


        public static ObservableCollection<USBCameraDevice> CAMERAS_LIST = new ObservableCollection<USBCameraDevice>();
        public static bool IS_ALL_COPYING_PROCESS_ARE_END = true;
    }
}
