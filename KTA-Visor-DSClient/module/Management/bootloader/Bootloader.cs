using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.interfaces;
using KTA_Visor_DSClient.module.Management.bootloader.handlers;
using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using KTA_Visor_DSClient.module.Management.module.Station.controller;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TCPTunnel.module.client.events;

namespace KTA_Visor_DSClient.module.Management.bootloader
{
    public class Bootloader
    {
        private List<IBootLoaderHandler> _handlers;

        private readonly Settings _settings;
        private readonly KTALogger.Logger _logger;

        public Bootloader(Settings settings, KTALogger.Logger logger)
        {
            this._settings = settings;
            this._logger = logger;
            this._handlers = new List<IBootLoaderHandler>()
            {
                new AutoStartHandler(this._logger),
                new BackendInitHandler(this._settings),
                new PowerSupplyInitHandler(this._settings, this._logger),
                new TunnelInitHandler(this._settings, this._logger),
                new StationInitHandler(this._settings),
                new CamerasWatcherInitHandler(this._settings, this._logger),
            };
        }


        public void Load()
        {
            this.keepAlive();

            this._handlers.ForEach((IBootLoaderHandler handler) =>
            {
                Thread handlerThread = new Thread(() => handler.Handle());
                handlerThread.IsBackground = true;
                handlerThread.Start();

                Thread.Sleep(1500);

                this._logger.info(String.Format("Initialized : {0}", handler.GetName()));
            });

        }

 
        private void keepAlive()
        {
            Thread lifeThread = new Thread((ThreadStart)delegate {
                while (true)
                {
                    Thread.Sleep(1000);
                }
            });
            lifeThread.IsBackground = true;
            lifeThread.Start();
        }
    }
}
