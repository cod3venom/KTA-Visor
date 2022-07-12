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
                case "/station/cameras": this.onReceiveCamerasList(request); break;
                case "/station/camera/files": this.onReceiveCamerasList(request); break;
            }
        }


        public void onReceiveCamerasList(Request request)
        {
            this.singleStationViewService.onReceivedCamerasList(request);
        }

        public void onReceiveCameraFiles(Request request)
        {
            this.singleStationViewService.onReceiveCameraFiles(request);
        }
    }
}
