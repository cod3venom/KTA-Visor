using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.dto;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.views.CamerasView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.helpers;

namespace KTA_Visor_DSClient.module.camera.service
{
    public class CamerasListViewService
    {
        private readonly CamerasListView camerasListView;

        public CamerasListViewService(CamerasListView camerasListView)
        {
            this.camerasListView = camerasListView;
        }

        public DockingStationTObject getDockingStation()
        {
            DockingStationTObject station = new DockingStationTObject();
            station.IpAddress = Network.GetLocalIPAddress();
            station.Cameras = this.camerasListView.CamerasList.ToArray();

            return station;
        }

        public USBCameraDeviceList<USBCameraDevice> cameras()
        {
            return this.camerasListView.CamerasList;
        }
    }
}
