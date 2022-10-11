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
    public class FileManagerWatcherService
    {
        private readonly FileManagerWatcherRepository fileHistoryFileWatcherRepository;

        public FileManagerWatcherService()
        {
            this.fileHistoryFileWatcherRepository = new FileManagerWatcherRepository();
        }

        public async Task<FileItemEntity> all()
        {
            HttpResponseMessage result = await this.fileHistoryFileWatcherRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistories = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistories;
        }

        public async Task<FileItemEntity> findbyid(string id)
        {
            HttpResponseMessage result = await this.fileHistoryFileWatcherRepository.findByid(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistories = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistories;
        }
 
        public async Task<FileItemEntity> delete(string id)
        {
            HttpResponseMessage result = await this.fileHistoryFileWatcherRepository.delete(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            FileItemEntity fileHistory = JsonConvert.DeserializeObject<FileItemEntity>(responseBody);

            return fileHistory;
        }
    }
}
