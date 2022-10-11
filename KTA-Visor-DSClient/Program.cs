
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Entrypoint());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
#if DEBUG
            Console.WriteLine(e);
            Console.ReadLine();
#endif
            _ = new StationInitializer().Initialize(false);
            Application.Restart();
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
#if DEBUG
            Console.WriteLine(e);
            Console.ReadLine();
#endif
            _ = new StationInitializer().Initialize(false);
            Application.Restart();   
        }

    }

}
