
using KTA_Visor_DSClient.install;
using KTA_Visor_DSClient.module.Management;
using KTA_Visor_DSClient.module.Management.events;
using KTA_Visor_DSClient.module.Management.module.Station;
using KTA_Visor_DSClient.module.Shared.Globals;
using Sentry;
using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;


namespace KTA_Visor_DSClient
{
    internal static class Program
    {

        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {

            using (SentrySdk.Init(o =>
            {
                o.Dsn = "https://b63b785039d541b591df10fd1e118b22@o1412683.ingest.sentry.io/4504017862393856";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set traces_sample_rate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                o.TracesSampleRate = 1.0;
                // Enable Global Mode if running in a client app
                o.IsGlobalModeEnabled = true;
            }))
            {
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Installer installer = new Installer();
                installer.FullInstall();

                Globals.Logger = new KTALogger.Logger();

                EntryPoint entrypoint = new EntryPoint(Globals.Logger);
                entrypoint.OnExceptionOccured += Entrypoint_OnExceptionOccured;
                entrypoint.Run();
            }
  
        }

        private static void Entrypoint_OnExceptionOccured(object sender, OnExceptionOccuredEvent e)
        {
            Program.HandleException(e.Exception);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Program.HandleException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Program.HandleException((Exception)e.ExceptionObject);
        }


        private static void HandleException(Exception exception)
        {
            Globals.Logger.error("Global exception handler", exception);
            new StationInitializer(new install.settings.Settings()).init(false);

#if DEBUG
            Console.WriteLine(exception.ToString());
            Console.ReadKey();
#endif

#if !DEBUG
            Application.Restart();
#endif
        }

    }

}
