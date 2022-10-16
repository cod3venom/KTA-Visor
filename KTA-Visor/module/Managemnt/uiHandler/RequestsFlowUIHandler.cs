using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Shared.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.module.Managemnt.uiHandler
{
    public class RequestsFlowUIHandler : IUIHandlerInterface
    {
        private readonly Management.view.Management managementForm;
        public RequestsFlowUIHandler(Management.view.Management managementForm)
        {
            this.managementForm = managementForm;
        }

        public void Handle()
        {
            Globals.Server.Start();
            Globals.Server.OnMessageReceivedFromClient += onRequestReceived;
        }

        private void onRequestReceived(object sender, OnMessageReceivedFromClient e)
        {
            this.managementForm.Modules.ForEach(module => module.Watch(e.Request));
        }

    }
}
