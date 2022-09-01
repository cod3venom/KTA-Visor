using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.module.camera.dto.request
{
    public class EditCameraRequestTObject
    {
        public EditCameraRequestTObject(string camCustomId)
        {
            this.camCustomId = camCustomId;
        }

        public string camCustomId { get; set; }
    }
}
