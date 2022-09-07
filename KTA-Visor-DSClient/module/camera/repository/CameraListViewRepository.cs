using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.store;
using KTA_Visor_DSClient.module.dashboard.componnets.CameraItem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera.repository
{
    public class CameraListViewRepository
    {
        
        public CameraListViewRepository()
        {
             
        }


        public Dictionary<string, USBCameraDevice> CamerasDict
        {
            get
            {
                Dictionary<string, USBCameraDevice> dict = new Dictionary<string, USBCameraDevice>();

                foreach(CameraItem device in CamerasVirtualStorage.CameraItems)
                {
                    if (dict.ContainsKey(device.Camera.getDriveInfo().Name)) continue;
                    dict.Add(device.Camera.getDriveInfo().Name, device.Camera);
                }
                return dict;
            }
        }

        public Dictionary<string, FileInfo> CameraFiles
        {
            get
            {

                Dictionary<string, FileInfo> files = new Dictionary<string, FileInfo>();
                foreach (KeyValuePair<string, USBCameraDevice> camera in this.CamerasDict)
                {
                    foreach (FileInfo file in camera.Value.getFiles())
                    {
                        files.Add(file.FullName, file);
                    }

                }
                return files;
            }
        }
    }
}
