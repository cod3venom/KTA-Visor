using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_UI.component.basic.progressbar.events
{
    public class OnProgressChangedEvent: EventArgs
    {
        public OnProgressChangedEvent(int progress)
        {
            this.Progress = progress;
            this.ProgressText = string.Format("{0}%", progress);
        }

        public int Progress { get; set; }
        public string ProgressText { get; set; }
    }
}
