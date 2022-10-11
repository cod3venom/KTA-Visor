using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileManager.dto.request
{
    public class CreateFileHistoryRequestTObject
    {
        
        public CreateFileHistoryRequestTObject(
            string stationId,
            string cameraId,
            string badgeId,
            string fileName,
            string fileSourcePath,
            string fileDestPath,
            double fileSize
        )
        {
            this.stationId = stationId;
            this.cameraId = cameraId;
            this.badgeId = badgeId;
            this.fileName = fileName;
            this.fileSourcePath = fileSourcePath;
            this.fileDestPath = fileDestPath;
            this.fileSize = fileSize;
        }
        
        public string stationId { get; set; }
        public string cameraId { get; set; }
        public string badgeId { get; set; }
        public string fileName { get; set; }
        public string fileSourcePath { get; set; }
        public string fileDestPath { get; set; }
        public double fileSize { get; set; }

    }
}
