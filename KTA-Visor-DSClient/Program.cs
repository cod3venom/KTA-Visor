using KTA_Visor_DSClient.install;
using KTA_Visor_DSClient.module.dashboard.view;
using KTA_Visor_DSClient.module.preloader.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient
{
    internal static class Program
    {
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

            KTALogger.Logger logger = new KTALogger.Logger();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PreLoaderView(new DashboardView(logger)));
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
