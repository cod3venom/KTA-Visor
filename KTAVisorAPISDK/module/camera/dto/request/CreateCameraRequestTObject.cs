using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class CreateCameraRequestTObject
    {

        public CreateCameraRequestTObject(string camCustomId = "", string badgeId = "", string driveName = "")
        {
            this.camCustomId = camCustomId;
            this.badgeId = badgeId;
            this.driveName = driveName;
        }

        public string camCustomId { get; set; }
        public string badgeId { get; set; }
        public string driveName { get; set; }
    }
}
