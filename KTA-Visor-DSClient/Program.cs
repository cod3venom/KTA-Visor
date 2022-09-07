
using KTA_Visor_DSClient.install;
using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTA_Visor_DSClient.module.Management.module.Station.bootloader;
using KTA_Visor_DSClient.module.Management.view;
using KTA_Visor_DSClient.module.Management.workers.Tunnel;
using KTA_Visor_DSClient.module.Shared.Globals;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using KTAVisorAPISDK.module.station.service;
using System;
using System.Windows.Forms;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.shared.entity;

namespace KTA_Visor_DSClient
{
    internal static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        public static USBDeviceRelay Relay;

        /// <summary>
        /// 
        /// </summary>
        public static TunnelBackgroundWrorker TunnelBackgroundWrorker;
        
        /// <summary>
        /// 
        /// </summary>
        public static KTALogger.Logger logger = new KTALogger.Logger();
        
        /// <summary>
        /// 
        /// </summary>
        public static StationService StationService = new StationService();

        [STAThread]
        static  void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Installer installer = new Installer();
            installer.FullInstall();

            Settings settings = new Settings();
            Relay = new USBDeviceRelay (
                settings.SettingsObj.app.usbRelay.COMport,
                19200,
                System.IO.Ports.Parity.None,
                8,
                System.IO.Ports.StopBits.One,
                logger
            );

            Relay.Open();

            HttpClientUtil.initializeHttpClient("http://localhost:8000/api");
            HttpClientUtil.initializeSecuredClient("http://localhost:8000/api");
            
            StationBootLoader.load();

            AuthData tunnelAuthData = new AuthData();
            tunnelAuthData.Identificator = Globals.STATION.data.stationId;
            tunnelAuthData.AdditionalData.Add("station", Globals.STATION);

            Program.TunnelBackgroundWrorker = new TunnelBackgroundWrorker(
                new ClientConfigTObject(
                    settings.SettingsObj.app.management.serverIp,
                    settings.SettingsObj.app.management.serverPort,
                    tunnelAuthData        
                ),
                logger
            );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ManagementView(logger));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    
 
    }

}
