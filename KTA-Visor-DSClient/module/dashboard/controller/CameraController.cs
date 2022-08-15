using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.dto;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using KTA_Visor_DSClient.module.camera.dto;
using KTA_Visor_DSClient.module.camera.service;
using KTA_Visor_DSClient.module.camera.store;
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
        
        /// <summary>
        /// 
        /// </summary>
        private readonly SingleCameraService camerasListViewService;

        /// <summary>
        /// 
        /// </summary>
        private readonly tunnel.Tunnel tunnel;

        /// <summary>
        /// 
        /// </summary>
        private readonly KTALogger.Logger logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tunnel"></param>
        /// <param name="logger"></param>
        public CameraController(tunnel.Tunnel tunnel, KTALogger.Logger logger)
        {
            this.tunnel = tunnel;
            this.logger = logger;
            this.camerasListViewService = new SingleCameraService();
        }

        public void StartWatching(Request request)
        {
            this.logger.info(String.Format("Received request on endpoint {0}", request.Endpoint));
            this.logger.info(String.Format("With body \n {0}", request.Body));
            switch (request.Endpoint)
            {
                case "command://station/authenticate": this.onActionAuthenticate(request); break;
                case "command://station/cameras": this.onActionSendCamerasList(request); break;
                case "command://station/camera/files": this.onActionSendSelectedCameraFiles(request); break;
                case "command://station/camera/selected/files": this.onActionSendSelectedCameraFiles(request); break;
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
                    CamerasVirtualStorage.Cameras.ToArray()
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
            GetSelectedCameraFilesRequestTObject body = JsonConvert.DeserializeObject<GetSelectedCameraFilesRequestTObject>(request.Body);
            string json = JsonConvert.SerializeObject(this.camerasListViewService.CameraDriveByBadgeId(body.BadgeId));
            request.Client.Send(new Request(
                "response://station/camera/selected/files",
                json
            ));
        }

    }
}
