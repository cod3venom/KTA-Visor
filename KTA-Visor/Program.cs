using KTA_Visor.install;
using KTA_Visor.install.settings;
using KTA_Visor.kernel.sharedKernel.bootstrap;
using KTA_Visor.module.Managemnt.module.auth.view.SignInView;
using KTA_Visor.module.Managemnt.workers.tunnel;
using KTA_Visor.module.Shared.Global;
using KTAVisorAPISDK.kernel.sharedKernel.util;
using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;
using TCPTunnel.module.server.dto;

namespace KTA_Visor
{

    internal static class Program
    {
        public static KTALogger.Logger Logger;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(Form_UIThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Installer installer = new Installer();
            installer.FullInstall();

            Logger = new KTALogger.Logger();

            Settings settings = new Settings();
            HttpClientUtil.initializeHttpClient("http://localhost:8000/api");
            HttpClientUtil.initializeSecuredClient("http://localhost:8000/api");
            new Bootstrap()._Watcher.unAuthorizedWatcher().Watch();

            Globals.ServerTunnelBackgroundWorker = new ServerTunnelBackgroundWorker(new ServerConfigTObject(
                    "Management",
                     settings.SettingsObj?.app?.tunnel?.serverIp,
                     settings.SettingsObj.app.tunnel.serverPort
                ), 
                Program.Logger
            );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInView());
        }

        private static void Form_UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Program.Logger.error(String.Format("Catched exception in entry point: ", e.Exception.ToString()));
            MessageBox.Show(e.Exception.Message.ToString());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Program.Logger.error(String.Format("Catched exception in entry point: ", e.ExceptionObject.ToString()));
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
