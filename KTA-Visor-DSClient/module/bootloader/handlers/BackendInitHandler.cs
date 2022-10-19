using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class BackendInitHandler : IBootLoaderHandler
    {
        public static string HandlerName = "BackendInitHandler";

        private readonly Settings _settings;
        public BackendInitHandler(Settings settings)
        {
            this._settings = settings;
        }

        public string GetName()
        {
            return BackendInitHandler.HandlerName;
        }

        public void Handle()
        {
            this.setupBackendSettings();
        }

        private void setupBackendSettings()
        {
            HttpClientUtil.initializeHttpClient(this._settings.SettingsObj.app.backend.api);
            HttpClientUtil.initializeSecuredClient(this._settings.SettingsObj.app.backend.api);
        }
    }
}
