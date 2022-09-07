using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.reques
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
