using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Managemnt.module.station;
using KTA_Visor.module.Shared.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor.module.Managemnt.uiHandler
{
    public class DefaultViewUIHandler : IUIHandlerInterface
    {
        private readonly Management.view.Management managementForm;
        public DefaultViewUIHandler(Management.view.Management managementForm)
        {
            this.managementForm = managementForm;
        }

        public void Handle()
        {
            this.initializeUI();
        }

       private void initializeUI()
       {
            Thread uiThread = new Thread((ThreadStart)delegate
            {
                this.managementForm.Invoke((MethodInvoker)delegate
                {
                    StationModule station = (StationModule)this.managementForm.Modules.Get(StationModule.ModuleName);
                    station.Dock = DockStyle.Fill;
                    this.managementForm.ClientsManagerModule.Dock = DockStyle.Fill;

                    this.managementForm.Content.Controls.Add(station);
                    this.managementForm.ClientsManagerPanel.Controls.Add(this.managementForm.ClientsManagerModule);
                });
            });

            uiThread.IsBackground = true;
            uiThread.Start();
       }

    }
}
