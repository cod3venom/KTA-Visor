using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.dto;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.dto;
using KTA_Visor_DSClient.module.camera.service;
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

namespace KTA_Visor_DSClient.module.dashboard.controller
{
    internal class CameraController : IRouteController
    {
        private readonly USBCameraDeviceList<USBCameraDevice> camerasList;

        private readonly CameraService camerasListViewService;


        private readonly tunnel.Tunnel tunnel;

        public CameraController(
            USBCameraDeviceList<USBCameraDevice> camerasList,
            tunnel.Tunnel tunnel
        )
        {
            this.camerasList = camerasList;
            this.tunnel = tunnel;
        }

        public void StartWatching(Request request)
        {
            switch (request.Endpoint)
            {
                case "command://station/authenticate": this.onActionAuthenticate(request); break;
                case "command://station/cameras": this.onActionSendCamerasList(request); break;
                case "command://station/camera/files": this.onActionSendSelectedCameraFiles(request); break;
            }

            Thread.Sleep(5000);
        }

        public void onActionAuthenticate(Request request)
        {
            request.Client.Send(new Request(
                "response://station/authenticate",
                new DockingStationTObject(
                    Network.GetLocalIPAddress(),
                    8,
                    "Online",
                    this.camerasList.ToArray()
                )
            ));
        }

        private void onActionSendCamerasList(Request request)
        {
            string json = JsonConvert.SerializeObject(this.camerasListViewService.CamerasDict);
            request.Client.Send(new Request(
                "response://station/cameras",
                json
            ));
        }


        private void onActionSendSelectedCameraFiles(Request request)
        {
            GetCameraFilesRequestTObject body = JsonConvert.DeserializeObject<GetCameraFilesRequestTObject>(request.Body);
            string json = JsonConvert.SerializeObject(this.camerasListViewService.FilesFromDrive(body.CameraDrive));
            request.Client.Send(new Request(
                "response://station/camera/files",
                json
            ));
        }

    }
}
