using KTA_Visor.install;
using KTA_Visor.module.Managemnt.view;
using KTA_Visor.module.Shared.Global;
using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Windows.Forms;

namespace KTA_Visor
{

    internal static class Program
    {
    
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {

            Application.ThreadException += new ThreadExceptionEventHandler(Form_UIThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            if (Environment.OSVersion.Version.Major >= 6) {
                SetProcessDPIAware();
            }

            Installer installer = new Installer();
            installer.FullInstall();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KernelLoader());
        }

        private static void Form_UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Globals.Logger.error(String.Format("Catched exception in entry point: ", e.Exception.ToString()));
            MessageBox.Show(e.Exception.Message.ToString());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Globals.Logger.error(String.Format("Catched exception in entry point: ", e.ExceptionObject.ToString()));
            MessageBox.Show(e.ExceptionObject.ToString());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
