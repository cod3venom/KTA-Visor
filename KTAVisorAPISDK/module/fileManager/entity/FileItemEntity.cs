using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KTAVisorAPISDK.module.fileManager.entity
{
    public class FileItemEntity : DTOHelperStruct
    {
   
        public class FileHistory
        {
            public string id { get; set; }
            public string stationId { get; set; }
            public string cameraCustomId { get; set; }
            public string badgeId { get; set; }
            public string fileName { get; set; }
            public string fileSourcePath { get; set; }
            public string fileDestPath { get; set; }
            public double fileSize { get; set; }
            public bool evidence { get; set; }
            public bool removableEvidence { get; set; }
            public string checkSum { get; set; }
            public bool isDeleted { get; set; }
            public string description{ get; set; }
            public string createdAt { get; set; }
            public string deletedAt { get; set; }
        }


        public FileHistory data { get; set; }
        public List<FileHistory> datas { get; set; }

    }
}
