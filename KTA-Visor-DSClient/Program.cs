
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
using System.Runtime.ExceptionServices;
using System.Windows.Forms;
using TCPTunnel.module.client.dto;
using TCPTunnel.module.shared.entity;

namespace KTA_Visor_DSClient
{
    internal static class Program
    {
        public static Settings settings;
        public static USBDeviceRelay Relay;
        public static TunnelBackgroundWrorker TunnelBackgroundWrorker;
        public static AuthData TunnelAuthData;
        public static ClientConfigTObject TunnelConnectionSettings;
        public static KTALogger.Logger logger = new KTALogger.Logger();    
        public static StationService StationService = new StationService();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static  void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += onAppWillBeClosed;

            try
            {

                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetProcessDPIAware();
                }

                // Install required files
                Installer installer = new Installer();
                installer.FullInstall();

                // Load settings from the stored json file
                Program.settings = new Settings();

                Program.initializeBackendSettings();
                Program.initializeUSBRelay();
                Program.initializeStation();
                Program.initializeClientTunnel();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ManagementView(logger));
            }
            catch (Exception ex)
            {
                Program.logger.error(String.Format("Catched exception in entry point: ", ex.ToString()));
                Program.markStationAsInActiveOnBackendOnClose();
            }
        }

        private static void onAppWillBeClosed(object sender, EventArgs e)
        {
            Program.markStationAsInActiveOnBackendOnClose();
        }


        /// <summary>
        /// This method is used
        /// to configure http client for
        /// the KTA-VISOR api usage
        /// </summary>
        private static void initializeBackendSettings()
        {
            HttpClientUtil.initializeHttpClient("http://localhost:8000/api");
            HttpClientUtil.initializeSecuredClient("http://localhost:8000/api");
        }

        /// <summary>
        /// Current method is used to
        /// connect and manipulate
        /// USB Relay board with
        /// 8 channels
        /// </summary>
        private static void initializeUSBRelay()
        {
            Program.Relay = new USBDeviceRelay(
               Program.settings.SettingsObj.app.usbRelay.COMport,
               19200, System.IO.Ports.Parity.None, 8,
               System.IO.Ports.StopBits.One, logger
           );

            Program.Relay.Open();
            Program.Relay.turnOnAll();
        }

        /// <summary>
        /// Current method is used to
        /// create new or update existed
        /// record about current station
        /// in the KTA-VISOR-API Database.
        /// </summary>
        private static void initializeStation()
        {
            StationBootLoader.load();

            Program.TunnelAuthData = new AuthData();
            Program.TunnelAuthData.Identificator = Globals.STATION.data.stationId;
            Program.TunnelAuthData.AdditionalData.Add("station", Globals.STATION);
        }


        /// <summary>
        /// This method is used to
        /// connect to the Tunnel
        /// trough TCP Client library
        /// and exanche some data
        /// </summary>
        private static void initializeClientTunnel()
        {
            Program.TunnelConnectionSettings = new ClientConfigTObject(
                   settings.SettingsObj.app.management.serverIp,
                   settings.SettingsObj.app.management.serverPort,
                   Program.TunnelAuthData
            );

            Program.TunnelBackgroundWrorker = new TunnelBackgroundWrorker(
                Program.TunnelConnectionSettings,
                logger
            );

            Program.TunnelBackgroundWrorker.Start();
        }

        private async static void markStationAsInActiveOnBackendOnClose()
        {
            await StationBootLoader.load(false);
            await StationService.deactivateAllCamerasFromTheStation(Globals.STATION?.data?.id);
        }
    }

}
