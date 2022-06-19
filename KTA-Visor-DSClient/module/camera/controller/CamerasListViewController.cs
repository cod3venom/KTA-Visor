using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.dto;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.service;
using KTA_Visor_DSClient.module.camera.views.CamerasView;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.extensions.router.interfaces;
using TCPTunnel.kernel.helpers;

namespace KTA_Visor_DSClient.module.camera.controller
{
    internal class CamerasListViewController : IRouteController
    {
        private readonly CamerasListView camerasListView;

        private readonly CamerasListViewService camerasListViewService;
        
        public CamerasListViewController(CamerasListView camerasListView)
        {
            this.camerasListView = camerasListView;
            this.camerasListViewService = new CamerasListViewService(this.camerasListView);
        }

        public void StartWatching(Request request)
        {
            switch (request.Endpoint)
            {
                
            }

            Thread.Sleep(5000);
        }

        public void onAuthenticate(USBCameraDevice[] cameras)
        {
          
            
            this.camerasListView.Tunnel.send(new Request(
                "/authenticate",
                new DockingStationTObject(
                    Network.GetLocalIPAddress(),
                    8,
                    "Online",
                    cameras
                )
            ));
        }

    }
}
