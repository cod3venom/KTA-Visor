using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.dashboard.componnets.CameraItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera.store
{
    public static class CamerasVirtualStorage
    {
        private static List<CameraItem> camerasList = new List<CameraItem>();

        private static CameraItem applyIDandName(CameraItem cameraItem)
        {
            cameraItem.Camera.Name = "Kamera " + (camerasList.Count + 1).ToString();
            cameraItem.Name = cameraItem.Camera.Name;

            return cameraItem;
        }
        public  static void Add(CameraItem cameraItem)
        {
            if (exists(cameraItem)) return;

            cameraItem = applyIDandName(cameraItem);
            camerasList.Add(cameraItem);
        }

        public static  void Remove(CameraItem cameraItem)
        {
            camerasList.Remove(cameraItem);
        }

        public static bool exists(CameraItem cameraItem)
        {
            foreach(CameraItem item in camerasList)
            {
                if (item.Camera.Drive.Name == cameraItem.Camera.Drive.Name)
                    return true;

                continue;
            }
            return false;
        }
        public static List<CameraItem> CameraItems
        {
            get { return camerasList; }
        }

        public static List<USBCameraDevice> Cameras
        {
            get
            {
                List<USBCameraDevice> cameras = new List<USBCameraDevice>();
                foreach (CameraItem cameraItem in camerasList)
                {
                    cameras.Add(cameraItem.Camera);
                }

                return cameras;
            }
        }

    }
}
