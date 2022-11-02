using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.install.settings.dto
{
    public class SettingsFileTObject
    {
        public App app
        { get; set; }
    }

    public class App
    {
        public string title { get; set; }
        public bool installed{ get; set; }
        public bool configured { get; set; }
        public string releaseName{ get; set; }
        public Station station { get; set; }
        public UsbRelay usbRelay { get; set; }
        public FileSystem fileSystem { get; set; }
        public Management management { get; set; }
        public Backend backend { get; set; }
        public RDP rdp { get; set; }
    }

    public class Backend
    {
        public string api { get; set; }
    }

    public class RDP
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class FileSystem
    {
        public string recordingsPath { get; set; }
        public string reportsPath { get; set; }
        public string firmwaresPath { get; set; }
        public bool autoCopy { get; set; }
    }

    public class Management
    {
        public string serverIp { get; set; }
        public int serverPort { get; set; }
        public bool autoReconnect { get; set; }
    }

    public class Station
    {
        public string stationId { get; set; }
        public string ipAddress { get; set; }
    }

    public class UsbRelay
    {
        public string COMport { get; set; }
    }


}
