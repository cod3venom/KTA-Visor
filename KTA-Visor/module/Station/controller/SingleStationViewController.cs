using KTA_Visor.module.Station.service;
using KTA_Visor.module.Station.view;
using KTA_Visor.module.Station.view.StationVIew;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;
using TCPTunnel.kernel.extensions.router.events;

namespace KTA_Visor.module.Station.controller
{
    public class SingleStationViewController
    {

        private readonly SingleStationView singleStationView;

        private readonly SingleStationViewService singleStationViewService;


        public SingleStationViewController(SingleStationView singleStationView, SingleStationViewService singleStationViewService)
        {
            this.singleStationView = singleStationView;
            this.singleStationViewService = singleStationViewService;
        }

        public  void StartWatching(Request request)
        {
            switch (request.Endpoint)
            {
                case "response://station/cameras": this.onReceiveCamerasList(request); break;
                case "response://station/camera/files": this.onReceiveCamerasList(request); break;
                case "response://station/camera/selectedCamera/files": this.onReceiveSelectedCameraFiles(request); break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public void onReceiveCamerasList(Request request)
        {
            this.singleStationViewService.onReceivedCamerasList(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public void onReceiveCameraFiles(Request request)
        {
            this.singleStationViewService.onReceiveCameraFiles(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public void onReceiveSelectedCameraFiles(Request request)
        {
            this.singleStationViewService.onReceiveSelectedCameraFiles(request);
        }
    }
}
