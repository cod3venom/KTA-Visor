using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.officer.events
{
    public class OnOfficerCRUDEvent: EventArgs
    {
        public OnOfficerCRUDEvent(
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

        
        public OnOfficerCRUDEvent(
            string id,
            string firstName,
            string lastName,
            string camCustomId,
            string cardCustomId,
            string badgeId
        )
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.camCustomId = camCustomId;
            this.cardCustomId = cardCustomId;
            this.badgeId = badgeId;
        }

        public string id { get ; set; }
        public string badgeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string camCustomId { get; set; }
        public string cardCustomId { get; set; }
    }
}
