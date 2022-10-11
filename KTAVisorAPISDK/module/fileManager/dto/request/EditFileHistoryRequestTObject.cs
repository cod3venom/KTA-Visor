using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileManager.dto.request
{
    public class EditFileHistoryRequestTObject
    {
        
        public EditFileHistoryRequestTObject(bool isEvidence, bool isRemovableEvidence = true, string description = "")
        {
            this.isEvidence = isEvidence;
            this.isRemovableEvidence = isRemovableEvidence;
            this.description = description;
        }
        
        public bool isEvidence { get; set; }
        public bool isRemovableEvidence { get; set; }
        public string description{ get; set; }

    }
}
