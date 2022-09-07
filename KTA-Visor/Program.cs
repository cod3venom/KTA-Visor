using KTA_Visor.install;
using KTA_Visor.install.settings;
using KTA_Visor.kernel.sharedKernel.bootstrap;
using KTA_Visor.module.Management.tunnel;
using KTA_Visor.module.Managemnt.module.auth.view.SignInView;
using KTA_Visor.module.Managemnt.workers.tunnel;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using System;
using System.Windows.Forms;

namespace KTA_Visor
{

    internal static class Program
    {
        public static KTALogger.Logger Logger = new KTALogger.Logger();

        public static Tunnel Tunnel = new Tunnel();
        public static TunnelBackgroundWorker TunnelBackgroundWorker;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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
            HttpClientUtil.initializeHttpClient("http://localhost:8000/api");
            HttpClientUtil.initializeSecuredClient("http://localhost:8000/api");

            new Bootstrap()._Watcher.unAuthorizedWatcher().Watch();

            Program.TunnelBackgroundWorker = new TunnelBackgroundWorker(Program.Tunnel);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInView());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
