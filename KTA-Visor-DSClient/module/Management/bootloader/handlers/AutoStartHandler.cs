using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class AutoStartHandler : IBootLoaderHandler
    {
        public static string HandlerName = "AutoStartHandler";
        private readonly KTALogger.Logger _logger;

        public AutoStartHandler(KTALogger.Logger  logger)
        {
            this._logger = logger;
        }
        
        public string GetName()
        {
            return AutoStartHandler.HandlerName;
        }

        public void Handle()
        {
            this.writeToRegistry();
        }


        private void writeToRegistry()
        {
            RegistryKey rk;
            try
            {
                rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                rk.SetValue(this.AppName, this.AppLocation);
                this._logger.success(String.Format("{0} from {1} added the startup in LOCAL_MACHINE", this.AppName, this.AppLocation));

                rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                rk.SetValue(this.AppName, this.AppLocation);
                this._logger.success(String.Format("{0} from {1} added the startup in CURRENT_USER", this.AppName, this.AppLocation));

            }
            catch (Exception exception)
            {
                this._logger.error(exception.ToString());
            }
        }

        private string AppLocation
        {
            get
            {
                return Application.ExecutablePath;
            }
        }

        private string AppName
        {
            get
            {
                return  System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
    }
}
