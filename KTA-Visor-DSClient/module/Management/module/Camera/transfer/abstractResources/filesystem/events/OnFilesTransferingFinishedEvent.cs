using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService.types.device;
using KTAVisorAPISDK.module.station.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.transfer.abstractResources.filesystem.events
{
    public class OnFilesTransferingFinishedEvent : EventArgs
    {
        public OnFilesTransferingFinishedEvent(USBCameraDevice camera, StationEntity stationEntity, List<FileInfo> copied, List<FileInfo> duplicates, List<FileInfo> failed)
        {
            this.Camera = camera;
            this.StationEntity = stationEntity;
            this.Copied = copied;
            this.Duplicates = duplicates;
            this.Failed = failed;
        }

        public USBCameraDevice Camera { get; set; }
        public StationEntity StationEntity { get; set; }
        public List<FileInfo> Copied { get; set; }
        public List<FileInfo> Duplicates { get; set; }
        public List<FileInfo> Failed { get; set; }
    }
}
