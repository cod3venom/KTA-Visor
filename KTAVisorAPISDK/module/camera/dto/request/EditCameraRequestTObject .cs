using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.reques
{
    public class EditCameraRequestTObject
    {
        public EditCameraRequestTObject(
           int index = 0,
           string camCustomId = "",
           string badgeId = "",
           string cardId = "",
           string stationId = "",
           string driveName = "",
           bool active = false
       )
        {
            this.index = index;
            this.camCustomId = camCustomId;
            this.badgeId = badgeId;
            this.cardId = cardId;
            this.stationId = stationId;
            this.driveName = driveName;
            this.active = active;
        }

        public int index { get; set; }
        public string camCustomId { get; set; }
        public string badgeId { get; set; }
        public string cardId { get; set; }
        public string stationId { get; set; }
        public string driveName { get; set; }
        public bool active { get; set; }
    }
}
