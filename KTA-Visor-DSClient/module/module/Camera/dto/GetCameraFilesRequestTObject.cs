using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.dto
{
    public class GetCameraFilesRequestTObject
    {
        private readonly string _cameraDrive;
        public GetCameraFilesRequestTObject(string cameraDrive)
        {
            this._cameraDrive = cameraDrive; 
        }

        public string CameraDrive
        {
            get { return this._cameraDrive; }
        }
    }
}
