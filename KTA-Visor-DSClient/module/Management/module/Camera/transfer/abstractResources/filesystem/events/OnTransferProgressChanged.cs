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
    public class OnTransferProgressChanged : EventArgs
    {
        public OnTransferProgressChanged(FileInfo currentFile, double totalSize, double currentSize)
        {
            this.CurrentFile = currentFile;
            this.TotalSize = totalSize;
            this.CurrentSize = currentSize;
        }

        public FileInfo CurrentFile { get; private set; }
        public double TotalSize { get; private set; }   
        public double CurrentSize { get; private set; }
        public int Progress
        {
            set { this.Progress = value; }
            get
            {
               return (int)Math.Round((double)(100 * this.CurrentSize) / this.TotalSize);
            }
        }
    }
}
