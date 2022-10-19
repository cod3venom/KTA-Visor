using KTA_Visor_DSClient.module.Management.bootloader.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.bootloader.handlers
{
    public class AutoStartHandler : IBootLoaderHandler
    {
        public static string HandlerName = "AutoStartHandler";

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
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(this.AppName, this.AppLocation);
        }

        private string AppLocation
        {
            get
            {
                return System.Reflection.Assembly.GetEntryAssembly().Location.ToString();
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
