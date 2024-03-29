﻿using KTA_Visor.module.Managemnt.events;
using KTA_Visor.module.Managemnt.interfaces;
using KTA_Visor.module.Managemnt.module.fileManager;
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
            this.hookEvents();
        }

        private void hookEvents()
        {
            this.managementForm.SideBar.OnStationsClick += displayStationAsDefaultView;
            this.managementForm.SideBar.OnRecordingsClick += displayRecordingsAsDefaultView;
        }

        private void displayStationAsDefaultView(object sender, EventArgs e)
        {
            this.displayModule((StationModule)this.managementForm.Modules.Get(StationModule.ModuleName));
        }

        private void displayRecordingsAsDefaultView(object sender, EventArgs e)
        {
            this.displayModule((FileManagerModule)this.managementForm.Modules.Get(FileManagerModule.ModuleName));
        }

        private void displayModule(Control moduleView)
        {
            Thread uiThread = new Thread((ThreadStart)delegate
            {
                this.managementForm.Invoke((MethodInvoker)delegate
                {
                    
                    moduleView.Dock = DockStyle.Fill;
                    this.managementForm.ClientsManagerModule.Dock = DockStyle.Fill;
                    this.managementForm.Content.Controls.Add(moduleView);
                    this.managementForm.ClientsManagerPanel.Controls.Add(this.managementForm.ClientsManagerModule);
                });
            });

            uiThread.IsBackground = true;
            uiThread.Start();
       }

    }
}
