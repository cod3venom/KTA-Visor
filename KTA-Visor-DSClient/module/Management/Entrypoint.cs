using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.bootloader;
using KTA_Visor_DSClient.module.Management.events;
using KTA_Visor_DSClient.module.Management.view;
using KTA_Visor_DSClient.module.Shared;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Threading;

namespace KTA_Visor_DSClient.module.Management
{
    internal class EntryPoint
    {
        public event EventHandler<OnExceptionOccuredEvent> OnExceptionOccured;

        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;
        private readonly Bootloader _bootLoader;
        private readonly SettingsManager settingsManagerView;

        public EntryPoint(KTALogger.Logger logger)
        {
            this._settings = new Settings();
            this._logger = logger;

            this._bootLoader = new Bootloader(this._settings, this._logger);
            this.settingsManagerView = new SettingsManager(this._logger, this._settings);
        }

        public void Run()
        {
            if (!this._settings.SettingsObj.app.installed && !this._settings.SettingsObj.app.configured)
            {
                this.settingsManagerView.ShowDialog();
                return;
            }

            this._bootLoader.Load();
        }

   
    }
}
