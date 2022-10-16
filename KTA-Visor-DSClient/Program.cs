
using KTA_Visor_DSClient.install;
using KTA_Visor_DSClient.module.Management;
using KTA_Visor_DSClient.module.Management.events;
using KTA_Visor_DSClient.module.Management.module.Station;
using KTA_Visor_DSClient.module.Shared.Globals;
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

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Installer installer = new Installer();
            installer.FullInstall();
            
            Globals.Logger = new KTALogger.Logger();

            EntryPoint entrypoint = new EntryPoint(Globals.Logger);
            entrypoint.OnExceptionOccured += Entrypoint_OnExceptionOccured;
            entrypoint.Run();
        }

        private static void Entrypoint_OnExceptionOccured(object sender, OnExceptionOccuredEvent e)
        {
            Program.HandleException(e);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Program.HandleException(e);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Program.HandleException(e);
        }


        private static void HandleException(dynamic exception)
        {
            Globals.Logger.error("Global exception handler", exception);
            _ = new StationInitializer(new install.settings.Settings()).Initialize(false);

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
