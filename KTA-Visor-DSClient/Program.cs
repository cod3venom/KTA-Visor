
using KTA_Visor_DSClient.install;
using KTA_Visor_DSClient.module.Management;
using KTA_Visor_DSClient.module.Management.events;
using KTA_Visor_DSClient.module.Shared.Globals;
using System;
using System.Runtime.ExceptionServices;
using System.Windows.Forms;


namespace KTA_Visor_DSClient
{
    internal static class Program
    {

        [STAThread]
        //[HandleProcessCorruptedStateExceptions]
        static void Main()
        {
           

            Installer installer = new Installer();
            installer.FullInstall();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Entrypoint());
        }

        private static void onExceptionOccured(object sender, OnExceptionOccuredEvent e)
        {
        }

    }

}
