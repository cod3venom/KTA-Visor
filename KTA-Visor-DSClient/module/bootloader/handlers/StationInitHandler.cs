using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using KTA_Visor_DSClient.module.Management.module.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class StationInitHandler : IBootLoaderHandler
    {
        public static string HandlerName = "StationInitHandler";

        private readonly StationInitializer _stationInitializer;
        public StationInitHandler(Settings settings)
        {
            this._stationInitializer = new StationInitializer(settings);
        }
        public string GetName()
        {
            return StationInitHandler.HandlerName;
        }

        public void Handle()
        {
            this.initializeStation();
        }

        
        private void initializeStation()
        {
            _ = this._stationInitializer.Initialize();
        }
    }
}
