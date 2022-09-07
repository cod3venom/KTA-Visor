using KTAVisorAPISDK.module.fileHistory.dto.request;
using KTAVisorAPISDK.module.fileHistory.entity;
using KTAVisorAPISDK.module.fileHistory.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileHistory.service
{
    public class FileHistoryService
    {
        private readonly FileHistoryRepository fileHistoryRepository;

        public FileHistoryService()
        {
            this.fileHistoryRepository = new FileHistoryRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileHistoryEntity> all()
        {
            HttpResponseMessage result = await this.fileHistoryRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistories = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistories;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileHistoryEntity> findbyid(string id)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.findByid(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistories = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistories;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileHistoryEntity> create(CreateFileHistoryRequestTObject request)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistory = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileHistoryEntity> edit(string id, EditFileHistoryRequestTObject request)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistory = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistory;
        }
    }
}
