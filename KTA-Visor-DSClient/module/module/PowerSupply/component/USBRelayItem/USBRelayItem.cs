using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.dto;
using KTA_USB_Relay.kernel.sharedKernel.module.RelayDevice.events;
using KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.module.PowerSupply.component.USBRelayItem
{
    public partial class USBRelayItem : UserControl
    {
        public event EventHandler<OnTurnOnPowerEvent> OnTurnOnPower;
        public event EventHandler<OnTurnOffPowerEvent> OnTurnOffPower;
        public event EventHandler<OnCheckStateEvent> OnCheckState;

        public bool isON;
        public int PortNumber { get; set; }

        public USBRelayItem()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="portNumber"></param>
        public USBRelayItem(int portNumber)
        {
            InitializeComponent();
            this.PortNumber = portNumber;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void USBRelayItem_Load(object sender, EventArgs e)
        {
            this.actionBtn.OnClick += ActionBtn_OnClick;
            this.checkState();
        }

        /// <summary>
        /// Check the power state for the
        /// current item based on the received
        /// data from the COMConnector
        /// </summary>
        private void checkState()
        {
            Globals.Relay.OnReceivedPortStatusEvent += (delegate (object sender, OnReceivedPortStatusEvent evt)
            {
                USBRelayPortsToObject.Port port = evt.Ports.findByPortNumber(this.PortNumber);
                this.isON = evt.Ports.findByPortNumber(this.PortNumber).Status == 0 ? false : true;
                this.render();
            });

            Globals.Relay.isTurnedOn(this.PortNumber);
        }

        /// <summary>
        /// Handle turn on/off click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionBtn_OnClick(object sender, EventArgs e)
        {
           if (this.isON)
            {
                this.isON = false;
                this.OnTurnOffPower?.Invoke(sender, new OnTurnOffPowerEvent(this.PortNumber.ToString()));
                this.checkState();
                return;
            } else
            {
                this.isON = true;
                this.OnTurnOnPower?.Invoke(sender, new OnTurnOnPowerEvent(this.PortNumber.ToString()));
                this.checkState();
                return;
            }
        }

        /// <summary>
        /// Render item based on its power status
        /// </summary>
        private void render()
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                if (this.isON)
                {
                    this.actionBtn.Title = "Wyłączyć P" + this.PortNumber;
                    this.powerIcon.Image = Properties.Resources.usbPort_on;
                    return;
                }
                else
                {
                    this.actionBtn.Title = "Włączyć P" + this.PortNumber;
                    this.powerIcon.Image = Properties.Resources.usbPort_off;
                    return;
                }
            });
        }
    }
}
