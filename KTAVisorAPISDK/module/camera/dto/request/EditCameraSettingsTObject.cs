using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTAVisorAPISDK.module.camera.dto.request
{
    public class EditCameraSettingsTObject
    {

        public EditCameraSettingsTObject(
          string camCustomId = "",
          string badgeId = "",
          string cardId = "",
          int videoResolution = 0,
          int quality = 0,
          int codecFormat = 0,
          int preRecording = 0,
          int timeZone = 0,
          int gps = 0,
          int wifi = 0,
          int aesEncryption = 0
      )
        {
            this.camCustomId = camCustomId;
            this.badgeId = badgeId;
            this.videoResolution = videoResolution;
            this.quality = quality;
            this.codecFormat = codecFormat;
            this.preRecording = preRecording;
            this.timeZone = timeZone;
            this.gps = gps;
            this.wifi = wifi;
            this.aesEncryption = aesEncryption;
        }

        public int index { get; set; }
        public string camCustomId { get; set; }
        public string badgeId { get; set; }
        public string cardId { get; set; }
        public string stationId { get; set; }


        ///////////////////////////////////
        ///         SETTINGS            ///
        ///////////////////////////////////

        public int videoResolution { get; set; }
        public int quality { get; set; }
        public int codecFormat { get; set; }
        public int preRecording { get; set; }
        public int timeZone { get; set; }
        public int gps { get; set; }
        public int wifi { get; set; }
        public int aesEncryption { get; set; }
    }
}
