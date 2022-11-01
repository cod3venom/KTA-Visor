using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.entity
{
    public class CameraSettingsEntity
    {
       
        public class Settings
        {
            public string cameraCustomId { get; set; }
            public string badgeId { get; set; }
            public string cardId { get; set; }

            public int resolution { get; set; }
            public int quality { get; set; }
            public int codecFormat { get; set; }
            public bool preRecording { get; set; }
            public int timeZone { get; set; }
            public object dateAndTime { get; set; }
            public int wifi { get; set; }
            public int gps { get; set; }
            public int silentMode { get; set; }
            public int loopRecording { get; set; }
            public int aesEncryption { get; set; }
            public string id { get; set; }
            public string updatedAt { get; set; }
            public string createdAt { get; set; }
            public bool __isInitialized__ { get; set; }
        }

    }
}
