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


        public OfficerService()
        {
            this.officerRepository = new OfficerRepository();
        }

        public async Task<OfficersEntity> all()
        {
            HttpResponseMessage result = await this.officerRepository.all();
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficersEntity officers= JsonConvert.DeserializeObject<OfficersEntity>(responseBody);

            return officers;
        }

        public async Task<OfficerEntity> create(CreateOfficerRequestTObject request)
        {
            HttpResponseMessage result = await this.officerRepository.create(request);
            string responseBody = await result.Content.ReadAsStringAsync();
            OfficerEntity officers = JsonConvert.DeserializeObject<OfficerEntity>(responseBody);

            return officers;
        }
    }
}
