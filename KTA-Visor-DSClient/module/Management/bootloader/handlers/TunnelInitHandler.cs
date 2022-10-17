using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class TunnelInitHandler : IBootLoaderHandler
    {
        public static string HandlerName = "TunnelInitHandler";
        private readonly KTALogger.Logger _logger;
        private readonly ClientTunnel _clientTunnel;
        public TunnelInitHandler(Settings settings, KTALogger.Logger logger)
        {
            this._logger = logger;
            this._clientTunnel = new ClientTunnel(settings);
        }

        public string GetName()
        {
            return TunnelInitHandler.HandlerName;
        }

        public void Handle()
        {
            this.runWatcher();
        }

        private void runWatcher()
        {
            Globals.ClientTunnel = this._clientTunnel;
            // This logger is added here because
            // if it will be called from the main bootloader
            // loading process then it will be never logged
            // because ClientTunnel.Connect contains while loop
            // and logger never will be called
            this._logger.info(String.Format("Initialized : {0}", this.GetName()));

            new Thread(() => Globals.ClientTunnel.Connect()).Start();
        }
    }
}
