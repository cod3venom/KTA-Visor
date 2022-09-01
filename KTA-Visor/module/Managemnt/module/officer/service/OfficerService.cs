using KTA_Visor.module.Managemnt.module.officer.dto.request;
using KTA_Visor.module.Managemnt.module.officer.entity;
using KTA_Visor.module.Managemnt.module.officer.repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.officer.service
{
    public class OfficerService
    {
        private readonly OfficerRepository officerRepository;


        /// <summary>
        /// 
        /// </summary>
        public OfficerService()
        {
            this.officerRepository = new OfficerRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<OfficersEntity> all()
        {
            HttpResponseMessage result = await this.officerRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficersEntity officers= JsonConvert.DeserializeObject<OfficersEntity>(responseBody);

            return officers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OfficerEntity> findById(string id)
        {
            HttpResponseMessage result = await this.officerRepository.findById(id);
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficerEntity officers = JsonConvert.DeserializeObject<OfficerEntity>(responseBody);

            return officers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OfficerEntity> create(CreateOfficerRequestTObject request)
        {
            HttpResponseMessage result = await this.officerRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficerEntity officers = JsonConvert.DeserializeObject<OfficerEntity>(responseBody);

            return officers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OfficerEntity> edit(string id, EditOfficerRequestTObject request)
        {
            HttpResponseMessage result = await this.officerRepository.edit(id, request);
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficerEntity officers = JsonConvert.DeserializeObject<OfficerEntity>(responseBody);

            return officers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public async void delet(string id)
        {
            await this.officerRepository.delete(id);
        }
    }
}
