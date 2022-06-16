using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient.kernel.FalconBridge.Resource.CameraService.types.USBCameraDevice
{
    public class USBCameraDeviceHelper
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool GetVolumeInformation(string letter, StringBuilder name, uint nameSize, out uint serialNumber, out uint serialNumberLength, out uint flags, StringBuilder systemName, uint systemNameSize);

        public static string getVolumenSerialNumber(string volume)
        {
            int BufferLength = 256;
            var name = new StringBuilder(BufferLength);
            var systemName = new StringBuilder(BufferLength);
            var serialNumber = 0u;
            var serialNumberLength = 0u;
            var flags = 0u;

            volume = (volume ?? String.Empty).Trim();

            if (volume.Length == 1)
            {
                volume = $"{volume}:\\";
            }
            if (!volume.EndsWith(@"\"))
            {
                volume = $"{volume}\\";
            }

            if (GetVolumeInformation(volume, name, 256, out serialNumber, out serialNumberLength, out flags, systemName, 256))
            {
                return serialNumber.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
