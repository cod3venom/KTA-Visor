using KTAVisorAPISDK.module.fileManager.dto.request;
using KTAVisorAPISDK.module.fileManager.entity;
using KTAVisorAPISDK.module.fileManager.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileManager.service
{
    public class FileHistoryService
    {
        private readonly FileManagerRepository fileHistoryRepository;

        public FileHistoryService()
        {
            this.fileHistoryRepository = new FileManagerRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileItemEntity> all()
        {
            HttpResponseMessage result = await this.fileHistoryRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistories = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistories;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileItemEntity> findbyid(string id)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.findByid(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistories = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistories;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileItemEntity> create(CreateFileHistoryRequestTObject request)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistory = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistory;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileItemEntity> edit(string id, EditFileHistoryRequestTObject request)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistory = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<FileItemEntity> delete(string id)
        {
            HttpResponseMessage result = await this.fileHistoryRepository.delete(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistory = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistory;
        }
    }
}
