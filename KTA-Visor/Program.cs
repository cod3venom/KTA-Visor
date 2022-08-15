using KTA_Visor.install;
using KTA_Visor.install.settings;
using KTA_Visor.kernel.sharedKernel;
using KTA_Visor.kernel.sharedKernel.bootstrap;
using KTA_Visor.kernel.sharedKernel.util;
using KTA_Visor.module.Authentication.view;
using KTA_Visor.module.Managemnt.module.auth.view.SignInView;
using KTA_Visor.module.Managemnt.module.auth.view.SignUpView;
using KTA_Visor.module.Station.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor
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

            Settings settings = new Settings();
            HttpClientUtil.initializeHttpClient("http://192.168.0.162:8000/api");
            HttpClientUtil.initializeSecuredClient("http://192.168.0.162:8000/api");

            new Bootstrap()._Watcher.unAuthorizedWatcher().Watch();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInView());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
