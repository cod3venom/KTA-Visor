using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.officer.dto.request
{
    public class CreateOfficerRequestTObject
    {

        public CreateOfficerRequestTObject(string firstName, string lastName, string cameraId, string cardId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.camId = cameraId;
            this.cardId = cardId;
        }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string camId { get; set; }
        public string cardId { get; set; }
    }
}
