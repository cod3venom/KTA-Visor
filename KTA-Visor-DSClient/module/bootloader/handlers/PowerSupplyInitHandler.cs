using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class PowerSupplyInitHandler : IBootLoaderHandler
    {
        public static string HandlerName = "PowerSupplyInitHandler";

        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;
        private USBDeviceRelay _usbRelay;

        public PowerSupplyInitHandler(Settings settings, KTALogger.Logger logger)
        {
            this._settings = settings;
            this._logger = logger;
        }

        public string GetName()
        {
            return PowerSupplyInitHandler.HandlerName;
        }

        public void Handle()
        {
            this.turnOnAllPorts();
        }

        private void turnOnAllPorts()
        {
            this._usbRelay = new USBDeviceRelay(
                this._settings.SettingsObj.app.usbRelay.COMport,
               19200,
               System.IO.Ports.Parity.None,
               8,
               System.IO.Ports.StopBits.One,
               this._logger
            );

            
            this._usbRelay.Open();
            this._usbRelay.turnOnAll(50);
            Globals.Relay = this._usbRelay;
        }
    }
}
