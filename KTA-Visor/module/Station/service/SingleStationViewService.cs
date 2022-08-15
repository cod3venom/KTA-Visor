using KTA_Visor.module.Station.dto;
using KTA_Visor.module.Station.events;
using KTA_Visor.module.Station.view.StationVIew;
using KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraDeviceService.types.USBCameraDevice;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPTunnel.kernel.extensions.router.dto;

namespace KTA_Visor.module.Station.service
{
    public class SingleStationViewService
    {
        public EventHandler<StationCamerasListReceivedEvent> onCamerasReceived;
        public EventHandler<StationCameraFilesReceivedEvent> onCameraFilesReceived;
        public EventHandler<StationCameraFilesReceivedEvent> onSelectedCameraFilesReceived;

        private readonly StationTObject station;

        private readonly SingleStationView singleStationView;


        public SingleStationViewService(StationTObject station, SingleStationView singleStationView)
        {
            this.station = station;
            this.singleStationView = singleStationView;
        }

        public void askForCameras()
        {
            this.station.Client?.Send(new Request(
                "command://station/cameras"
            ));
        }

        public void askForCameraFiles(string drive)
        {
            this.station.Client?.Send(new Request(
                "command://station/camera/files",
                new GetCameraFilesRequestTObject(drive)
            ));
        }

        public void askForFilesFromSelectedCamera(string cameraId)
        {
            this.station.Client?.Send(new Request(
                "command://station/camera/selected/files",
                new GetSelectedCameraFilesRequestTObject(cameraId)
            ));
        }

        public void onReceivedCamerasList(Request request)
        {
            Dictionary<string, USBCameraDevice> cameras = JsonConvert.DeserializeObject<Dictionary<string, USBCameraDevice>> (request.Body);

            this.onCamerasReceived?.Invoke(this, new StationCamerasListReceivedEvent(cameras));
        }

        public void onReceiveCameraFiles(Request request)
        {
            Dictionary<string, FileInfo> files = JsonConvert.DeserializeObject<Dictionary<string, FileInfo>>(request.Body);

            this.onCameraFilesReceived?.Invoke(this, new StationCameraFilesReceivedEvent(files));
        } 
        
        public void onReceiveSelectedCameraFiles(Request request)
        {
            Dictionary<string, FileInfo> files = JsonConvert.DeserializeObject<Dictionary<string, FileInfo>>(request.Body);

            this.onSelectedCameraFilesReceived?.Invoke(this, new StationCameraFilesReceivedEvent(files));
        }
    }
}
