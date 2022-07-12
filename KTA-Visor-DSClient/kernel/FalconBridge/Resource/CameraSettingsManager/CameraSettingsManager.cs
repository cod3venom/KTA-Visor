using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.SettingsManager
{
    public class CameraSettingsManager
    {
        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;

        private USBCameraDevice selectedCamera = null;

        public CameraSettingsManager(USBCameraDeviceList<USBCameraDevice> camerasList)
        {
            this.camerasList = camerasList;
        }

        public USBCameraDevice Select(string driveName)
        {
            this.selectedCamera = this.camerasList.Single(camera => camera.Drive.Name == driveName);
            return this.selectedCamera;
        }

        public void FreezeRestOfTheCameras()
        {

            foreach(USBCameraDevice camera in this.camerasList)
            {
                if (camera == this.selectedCamera) continue;
                
            }
        }
    }
}
