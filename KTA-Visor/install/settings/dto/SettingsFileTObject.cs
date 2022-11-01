using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor.install.settings.dto
{
    public class SettingsFileTObject
    {
        public App app { get; set; }


        public class App
        {
            public string title { get; set; }
            public bool configured { get; set; }
            public string releaseName { get; set; }
            public API api { get; set; }        
            public Tunnel tunnel{ get; set; }
            public FileSystem fileSystem { get; set; }
            public CardMode cardMode { get; set; }
        }
         
        public class API
        {
            public string url { get; set; }
        }

        public class Tunnel
        {
            public string title { get; set; }

            public string serverIp { get; set; }

            public int serverPort { get; set; }

            public string serverMode { get; set; }

            public string[] modes { get; set; }
        }

        public class FileSystem
        {
            public string recordingsPath { get; set; }
            public string reportsPath { get; set; }

            public bool autoCopy { get; set; }
        }

        public class CardMode
        {
            public string password { get; set; }
        }
    }
}
