using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.officer.dto.request
{
    public class CreateOfficerRequestTObject
    {

        public CreateOfficerRequestTObject(
            string firstName,
            string lastName,
            string camCustomId,
            string cardCustomId,
            string badgeId
        )
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.camCustomId = camCustomId;
            this.cardCustomId = cardCustomId;
            this.badgeId = badgeId;
        }

        public string badgeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string camCustomId { get; set; }
        public string cardCustomId{ get; set; }
    }
}
