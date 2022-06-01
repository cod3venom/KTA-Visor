using Falcon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FalconSdk sdk = new FalconSdk();
            sdk.ConnectToDevice();
            sdk.Mount();

            string deviceID = @"F:\";//sdk.CurrentDeviceId.ToString();

            IEnumerable<DriveInfo> driveInfos = ((IEnumerable<DriveInfo>)DriveInfo.GetDrives()).Where<DriveInfo>((Func<DriveInfo, bool>)(d => d.DriveType == DriveType.Removable));

            foreach (DriveInfo driveInfo in driveInfos) {
                Console.WriteLine(driveInfo.Name);

                if (driveInfo.Name == deviceID) {

                    DirectoryInfo directoryInfo = new DirectoryInfo(deviceID + @"DCIM\100MEDIA\");
                    FileInfo[] files = directoryInfo.GetFiles();

                    foreach (FileInfo file in files) { 
                        Console.WriteLine(file.FullName);
                    }
                }
            }
            Console.WriteLine(sdk.CurrentDeviceId.ToString());

            Console.ReadLine();
        }
    }
}
