using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;


namespace KTA_Visor_DSClient.module.Management.module.PowerSupply
{
    public class PowerSupplyInitializer
    {

        public event EventHandler<EventArgs> OnPowerSupplyInitialized;
        public event EventHandler<EventArgs> OnUnableToInitializePowerSupply;

        private USBDeviceRelay usbRelay;

        public PowerSupplyInitializer()
        {
        }

        public void Initailize()
        {
            this.usbRelay = new USBDeviceRelay(
               Globals.settings.SettingsObj.app.usbRelay.COMport,
               19200,
               System.IO.Ports.Parity.None,
               8,
               System.IO.Ports.StopBits.One,
               Globals.Logger
            );

            this.usbRelay.OnSuccessFullyConnected += onSuccessfullyConnected;
            this.usbRelay.OnUnableToConnect += onUnableToConnect;
            Globals.Relay = this.usbRelay;
            Globals.Relay.Open();
            Globals.Relay.turnOnAll(50);
        }

        private void onSuccessfullyConnected(object sender, EventArgs e)
        {
            this.OnPowerSupplyInitialized?.Invoke(sender, e);
        }

        private void onUnableToConnect(object sender, EventArgs e)
        {
            this.OnUnableToInitializePowerSupply?.Invoke(sender, e);
        }

    }
}
