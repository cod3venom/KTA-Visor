using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon_Protocol.enums
{
    public class Enums
    {
        public enum VideoResolutions
        {
            Resolution2688x1512P30,
            Resolution2560x1440P30,
            Resolution2304x1296P30,
            Resolution1920x1080P30,
            Resolution1280x720P30,
            Resolution848x480P30,
            Resolution1920x1080P20,
            Resolution1280X720P25,
            Resolution1280X720P20,
            Resolution848X480XP20,
        }

        public List<VideoResolutions> Resolutions 
        {
           get
            {
               return new List<VideoResolutions>()
               {
                  VideoResolutions.Resolution1920x1080P30,
                  VideoResolutions.Resolution1280x720P30,
                  VideoResolutions.Resolution1280X720P25
               };
            }
        }

        public enum Qualitys
        {
           	Super_Fine,
		    Fine,
		    Normal
        }

        public List<string> Qualities
        {
            get
            {
                return new List<string>() { "Najwyższa" };
            }
        }

        public enum CodecFormats
        {
            H264,
            H265
        }

        public enum PreRecording
        {
            OFF = 0,
            ON = 1
        }


        public enum TimeZones
        {
            Minus12,
            Minus11,
            Minus10,
            Minus9,
            Minus8,
            Minus7,
            Minus6,
            Minus5,
            Minus4,
            Minus3,
            Minus2,
            Minus1,
            Zero,
            Plus1,
            Plus2,
            Plus3,
            Plus4,
            Plus5,
            Plus6,
            Plus7,
            Plus8,
            Plus9,
            Plus10,
            Plus11,
            Plus12
        }

        public enum Wifi
        {
            OFF = 0,
            ON = 1
        }

        public enum AESEncryption
        {
            Defualt = 256
        }

    }
}
