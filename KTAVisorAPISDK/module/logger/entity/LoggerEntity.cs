using KTAVisorAPISDK.kernel.sharedKernel.helper.DTOHelper.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.logger.entity
{
    public class LoggerEntity : DTOHelperStruct
    {
        public class LogFile
        {
            public string logFile { get; set; }
            public string fileName { get; set; }
        }

        public LogFile data { get; set; }
        public List<LogFile> datas { get; set; }

    }
}
