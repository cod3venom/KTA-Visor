using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera_settings_manager
{
    public class CameraSettingsManager
    {
        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;

        private USBCameraDevice selectedCamera;

        public CameraSettingsManager(USBCameraDeviceList<USBCameraDevice> camerasList)
        {
            this.camerasList = camerasList;
        }

        public CameraSettingsManager select(string driveName)
        {
            foreach(var camera in camerasList)
            {
                if (camera.Drive.Name != driveName) continue;
                this.selectedCamera = camera;
            }
            return this;
        }

    }
}
