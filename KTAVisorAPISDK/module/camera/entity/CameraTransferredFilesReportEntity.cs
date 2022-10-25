using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.entity
{
    public class CameraTransferredFilesReportEntity
    {
        public class Record
        {
            public string cameraCustomId { get; set; }
            public string badgeId { get; set; }
            public string stationId { get; set; }
            public List<string> copied { get; set; }
            public List<string> duplicates { get; set; }
            public List<string> fails { get; set; }
            public string path { get; set; }
            public string id { get; set; }
            public string createdAt { get; set; }
        }

        public string type { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public Record data { get; set; }
        public List<Record> datas { get; set; }

    }
}
