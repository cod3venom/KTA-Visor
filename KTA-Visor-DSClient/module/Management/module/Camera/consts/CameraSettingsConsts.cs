using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.module.Management.module.Camera.consts
{
    public class CameraSettingsConsts
    {
        public static string[] Resolutins = new string[] {
            "800x480P30",
            "1280x720P30",
            "1920x1080P30",
            "2304x1296P30",
            "2560x1440P30"
        };
        
        public static string[] VideoLengths = new string[] {
            "5 MIN",
            "15 MIN",
            "30 MIN"
        };
        
        public static string[] VideoQualities = new string[] {
            "NAJLEPSZE JAKOŚĆ",
            "DOBRA JAKOŚĆ",
            "ŚREDNIA JAKOŚĆ"
        };

        public static string[] CodecFormats = new string[] {
            "H.264",
            "H.265"
        };
        public static string[] SoundVolumes = new string[] {
            "0", "03", "06", "09", "12"
        };
        public static string[] InfraRed = new string[] { 
            "AUTO", 
            "MANUAL" 
        };
        public static int[] TimeZones = new int[] {
            
        };
        public static Dictionary<string, string> Languages = new Dictionary<string, string>();


        public class GPSSettings
        {
            public bool Enabled { get; set; }
        }

        public class RecordWarningSettings
        {
            public bool Enabled { get; set;}
        }

        public class LoopRecordingSettings
        {
            public bool Enabled { get; set; }
        }

        public class PreRecordingSettings
        {
            public bool Enabled { get; set; }
        }
    }
}
