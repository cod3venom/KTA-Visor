using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.logger.dto
{
    public class GetLogsInRangeRequestTObject
    {
        public GetLogsInRangeRequestTObject(string dateFrom, string dateTo)
        {
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
        }

        public string dateFrom { get; set; }
        public string dateTo { get; set; }
    }
}
