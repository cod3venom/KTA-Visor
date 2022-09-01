
using KTA_Visor_DSClient.install;
using KTA_Visor_DSClient.install.settings;
using KTA_Visor_DSClient.kernel.Hardware;
using KTA_Visor_DSClient.kernel.Hardware.USBDeviceRelay;
using KTA_Visor_DSClient.module.Management.module.Auth.service;
using KTA_Visor_DSClient.module.Management.module.Station.service;
using KTA_Visor_DSClient.module.Management.view;
using KTA_Visor_DSClient.module.Shared.Util;
using System;
using System.Windows.Forms;

namespace KTA_Visor_DSClient
{
    internal static class Program
    {

        public static USBDeviceRelay Relay;
 
        public static KTALogger.Logger logger = new KTALogger.Logger();
        public static AuthService AuthService = new AuthService();
        public static StationService StationService = new StationService();

        [STAThread]
        static void Main()
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
            
            StationService.StationBootLoader.load();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ManagementView(logger));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    
 
    }

}
