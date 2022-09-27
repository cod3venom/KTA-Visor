using KTAVisorAPISDK.module.logger.dto;
using KTAVisorAPISDK.module.logger.entity;
using KTAVisorAPISDK.module.logger.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.logger.service
{
    public class LoggerService
    {
        private readonly LoggerRepository loggerRepository;

        public LoggerService()
        {
            this.loggerRepository = new LoggerRepository();
        }

        public async Task<LoggerEntity> findInRange(GetLogsInRangeRequestTObject request)
        {
            HttpResponseMessage result = await this.loggerRepository.findInRange(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            LoggerEntity fileHistories = JsonConvert.DeserializeObject<LoggerEntity>(responseBody);

            return fileHistories;
        }

    }
}
