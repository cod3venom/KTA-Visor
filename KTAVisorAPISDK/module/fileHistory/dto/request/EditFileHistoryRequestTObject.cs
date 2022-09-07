using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.fileHistory.dto.request
{
    public class EditFileHistoryRequestTObject
    {
        
        public EditFileHistoryRequestTObject(bool isEvidence, bool isRemovableEvidence = true)
        {
            this.isEvidence = isEvidence;
            this.isRemovableEvidence = isRemovableEvidence;
        }
        
        public bool isEvidence { get; set; }
        public bool isRemovableEvidence { get; set; }

    }
}
