using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.officer.events
{
    public class OnSaveNewOfficerEvent: EventArgs
    {
        public OnSaveNewOfficerEvent(string firstName, string lastName, string cameraId, string cardId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CameraId = cameraId;
            this.CardId = cardId;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CameraId { get; set; }
        public string CardId { get; set; }
    }
}
