using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.camera.dto
{

    public class GetSelectedCameraFilesRequestTObject
    { 
        public GetSelectedCameraFilesRequestTObject(string badgeId)
        {
            this.BadgeId = badgeId;
        }         

        public string BadgeId { get; set; }
    }
}
