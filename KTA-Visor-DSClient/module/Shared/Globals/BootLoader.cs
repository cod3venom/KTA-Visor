using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.module.Management.module.Camera.Resource.CameraDeviceService;
using KTA_Visor_DSClient.module.Management.module.Camera.service;
using KTA_Visor_DSClient.module.Management.module.clientTunnel;
using KTA_Visor_DSClient.module.Management.module.PowerSupply;
using KTA_Visor_DSClient.module.Management.module.Station;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Threading;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Shared.Globals
{
    public class BootLoader
    {
        public event EventHandler<EventArgs> OnBackendInitialized;
        public event EventHandler<EventArgs> OnUSBRelayInitialized;
        public event EventHandler<EventArgs> OnStationInitialized;
        public event EventHandler<EventArgs> OnClientTunnelInitialized;
        public event EventHandler<EventArgs> OnMarkedAsInActiveOnClosing;

        private readonly Settings settings;
        private readonly StationInitializer stationInitializer;
        private readonly PowerSupplyInitializer powerSupplyInitializer;
        private readonly CameraDeviceWatcher cameraDeviceWatcher;
        private readonly StationService stationService;
        private  ClientTunnel client;

        public BootLoader()
        {
            this.settings = new Settings();
            this.stationService = new StationService();
            this.cameraDeviceWatcher = new CameraDeviceWatcher();

            Globals.settings = this.settings;
            Globals.Logger = new KTALogger.Logger();

            this.stationInitializer = new StationInitializer();
            this.powerSupplyInitializer = new PowerSupplyInitializer();
        }

        public  void Load()
        {
            try
            {
                this.initializeBackendSettings();
                this.initializeStationOnBackend();

                this.initializePowerSupply();

                Thread initializeTunnelClient = new Thread(this.initializeClientTunnel);
                initializeTunnelClient.Start();
                
                
                this.initializeCamerasWatcher();

            }
            catch (Exception ex) {
                                
            }
        }

        private  void initializeBackendSettings()
        {
            HttpClientUtil.initializeHttpClient(this.settings.SettingsObj.app.backend.api); 
            HttpClientUtil.initializeSecuredClient(this.settings.SettingsObj.app.backend.api);
        }

        private void initializeStationOnBackend()
        {
            _ = this.stationInitializer.Initialize();
        }

        private void initializePowerSupply()
        {
            this.powerSupplyInitializer.Initailize();
        }

        private void initializeCamerasWatcher()
        {
            this.cameraDeviceWatcher.Start();
        }

        private void initializeClientTunnel()
        {
            this.client = new ClientTunnel();
            this.client.Connect();
        }
    }
}
