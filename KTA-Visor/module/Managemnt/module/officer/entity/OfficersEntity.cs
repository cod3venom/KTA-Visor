using KTA_Visor.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.officer.entity
{
    public class OfficersEntity : DTOHelperStruct
    {
        public Data[] data { get; set; }

        public class Camera
        {
            public string customId { get; set; }
            public string drive { get; set; }
            public string id { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
        }

        public class Data
        {
            public Camera camera { get; set; }
            public string id { get; set; }
            public string ownerId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string cardId { get; set; }
            public string camId { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
        }

    }
}