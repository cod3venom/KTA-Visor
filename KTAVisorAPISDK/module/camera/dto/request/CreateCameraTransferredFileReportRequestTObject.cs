using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class CreateCameraTransferredFileReportRequestTObject
    {

        public CreateCameraTransferredFileReportRequestTObject()
        {
            this.copied = new List<FileInfo> { };
            this.duplicates = new List<FileInfo> { };
            this.fails = new List<FileInfo> { };
        }

        public string cameraCustomId { get; set; }
        public string badgeId { get; set; }
        public string stationId { get; set; }
        public string path { get; set; }
        public List<FileInfo> copied { get; set; }
        public List<FileInfo> duplicates { get; set; }
        public List<FileInfo> fails { get; set; }
    }
}
