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
            Resolution1280x720P30,
            Resolution1280x720P25,
        }

        public List<string> ResolutionValues ()
        {
            List<string> values = new List<string> ();
            foreach (var resolution in Enum.GetValues(typeof(VideoResolutions))) {
                values.Add(resolution.ToString().Replace("Resolution", ""));
            }
            return values;
        }

        public enum Qualitys
        {
            BEST
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
