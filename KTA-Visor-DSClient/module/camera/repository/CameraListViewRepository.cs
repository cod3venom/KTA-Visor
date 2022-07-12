using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
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
        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;

        public CameraListViewRepository(USBCameraDeviceList<USBCameraDevice> camerasList)
        {
            this.camerasList = camerasList;
        }


        public Dictionary<string, USBCameraDevice> CamerasDict
        {
            get
            {
                USBCameraDeviceList<USBCameraDevice> cams = this.camerasList;
                Dictionary<string, USBCameraDevice> dict = new Dictionary<string, USBCameraDevice>();

                cams.ForEach(camera => dict.Add(camera.getDriveInfo().Name, camera));
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
