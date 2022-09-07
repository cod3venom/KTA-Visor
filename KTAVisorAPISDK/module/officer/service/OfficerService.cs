using KTAVisorAPISDK.module.officer.dto.request;
using KTAVisorAPISDK.module.officer.entity;
using KTAVisorAPISDK.officer.repository;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.officer.service
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
        public async Task<OfficerEntity> all()
        {
            HttpResponseMessage result = await this.officerRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficerEntity officers = JsonConvert.DeserializeObject<OfficerEntity>(responseBody);

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
