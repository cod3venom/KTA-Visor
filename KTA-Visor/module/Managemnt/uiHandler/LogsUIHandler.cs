using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Shared.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.uiHandler
{
    public class LogsUIHandler : IUIHandlerInterface
    {
        private readonly Management.view.Management managementForm;
        public LogsUIHandler(Management.view.Management managementForm)
        {
            this.managementForm = managementForm;
        }

        public void Handle()
        {
            this.managementForm.LoggerView.ParentPanel = (Panel)this.managementForm.LoggerPanel;
            this.managementForm.LoggerView.Minimize();
            Globals.Logger.OnLogHasWritten += onLogHasWritten;
        }

        private void onLogHasWritten(object sender, Logger.dto.LoggerEvent e)
        {
            this.managementForm.LoggerView.append(e.Log, e.Color);
        }

    }
}
