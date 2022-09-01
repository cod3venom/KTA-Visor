using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.dto
{
    public class CreateCameraRequestTObject
    {
        public CreateCameraRequestTObject(string camCustomId, string badgeId)
        {
            this.camCustomId = camCustomId;
            this.badgeId= badgeId;
        }

         public string camCustomId { get; set; }
         public string badgeId { get; set; }
    }
}
