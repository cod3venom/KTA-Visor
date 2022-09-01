using KTA_USB_Relay.kernel.sharedKernel.module.COMConnector.events;
using KTA_USB_Relay.kernel.sharedKernel.module.commander;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events;
using KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem;
using KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem.events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.view.PowerSupplyPanelView
{
    public partial class PowerSupplyPanelView : UserControl
    {
      
        public PowerSupplyPanelView()
        {
            InitializeComponent();
        }

        private void PowerSupplyPanelView_Load(object sender, EventArgs e)
        {
            this.loadEightPorts();
        }

        private void loadEightPorts()
        {
            for(int i = 1; i < 9; i++)
            {
                USBRelayItem port = new USBRelayItem(i);
                port.OnTurnOnPower += onTurnOnPower;
                port.OnTurnOffPower += onTurnOffPower;
                this.itemsPanel.Controls.Add(port);
            }
        }

 

        private void onTurnOnPower(object sender, OnTurnOnPowerEvent e)
        {
            Program.Relay.sendStringCommand(e.Command);
        }

        private void onTurnOffPower(object sender, OnTurnOffPowerEvent e)
        {
            Program.Relay.sendStringCommand(e.Command);
        }
    }
}
