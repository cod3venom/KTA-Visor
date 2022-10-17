using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.response
{
    public class CameraHasCardDuplicatesResponseTObject
    {
        public class Data
        {
            public bool hasDuplicates { get; set; }
        }

        public Data data { get; set; }
        public List<Data> datas { get; set; }
    }
}
