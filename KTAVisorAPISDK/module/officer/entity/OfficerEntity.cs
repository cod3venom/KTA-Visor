using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.officer.entity
{
    public class OfficerEntity : DTOHelperStruct
    {
        public class Officer
        {
            public string badgeId { get; set; }
            public string camCustomId { get; set; }
            public string cardId { get; set; }
            public string id { get; set; }
            public string ownerId { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string createdAt { get; set; }
            public string updatedAt { get; set; }
        }

        public Officer data { get; set; }
        public List<Officer> datas { get; set; }

    }
}