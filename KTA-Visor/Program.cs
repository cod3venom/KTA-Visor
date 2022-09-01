using KTA_Visor.install;
using KTA_Visor.install.settings;
using KTA_Visor.kernel.sharedKernel.bootstrap;
using KTA_Visor.kernel.sharedKernel.util;
using KTA_Visor.module.Management.tunnel;
using KTA_Visor.module.Managemnt.module.auth.view.SignInView;
using System;
using System.Windows.Forms;

namespace KTA_Visor
{

    internal static class Program
    {
        public static Tunnel Tunnel = new Tunnel();

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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInView());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
