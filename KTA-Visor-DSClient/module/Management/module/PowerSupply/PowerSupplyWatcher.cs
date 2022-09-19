using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply
{
    public class PowerSupplyWatcher
    {
        public void Start()
        {
            Globals.ALLOW_LISTENING_FOR_POWER_SUPPLY = true;
            while (Globals.ALLOW_LISTENING_FOR_POWER_SUPPLY)
            {

                if (!Globals.ALLOW_LISTENING_FOR_POWER_SUPPLY) break;

                Thread.Sleep(3000);

                Thread thr = new Thread((ThreadStart)delegate
                {
                    this.listenForStatuses();
                });
                thr.IsBackground = true;
                thr.Start();
            }

        }

        private void listenForStatuses()
        {
            Globals.Relay.OnReceivedPortStatusEvent += (delegate (object sender, OnReceivedPortStatusEvent e){
                
               /// Globals.Logger.info(String.Format("{0} status is {1}", e.Ports.))
            });
            Globals.Relay.getAllStatuses();
        }
    }
}
