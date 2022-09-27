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
    public class FileHistoryFileWatcherService
    {
        private readonly FileHistoryFileWatcherRepository fileHistoryFileWatcherRepository;

        public FileHistoryFileWatcherService()
        {
            this.fileHistoryFileWatcherRepository = new FileHistoryFileWatcherRepository();
        }

        public async Task<FileHistoryEntity> all()
        {
            HttpResponseMessage result = await this.fileHistoryFileWatcherRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistories = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistories;
        }

        public async Task<FileHistoryEntity> findbyid(string id)
        {
            HttpResponseMessage result = await this.fileHistoryFileWatcherRepository.findByid(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistories = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistories;
        }
 
        public async Task<FileHistoryEntity> delete(string id)
        {
            HttpResponseMessage result = await this.fileHistoryFileWatcherRepository.delete(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileHistoryEntity fileHistory = JsonConvert.DeserializeObject<FileHistoryEntity>(responseBody);

            return fileHistory;
        }
    }
}
