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
        public string title
        { get; set; }

        public Station station
        { get; set; }

        public USBRelay usbRelay
        { get; set; }

        public FileSystem fileSystem
        { get; set; }

        public Management management
        { get; set; }

        public Backend backend
        { get; set; }
    }


    public class Station
    {
        public string serialNumber { get; set; }
        public string ipAddress { get; set; }
    }

    public class USBRelay
    {
        public string COMport { get; set; }
    }

    public class FileSystem
    {
        public string networkStorage
        { get; set; }

        public bool autoCopy
        { get; set; }
    }

    public class Management
    {
        public string serverIp
        { get; set; }

        public int serverPort
        { get; set; }

        public bool autoReconnect
        { get; set; }
    }

    public class Backend
    {
        public string stationCustomId 
        { get; set; }
    }
}
