using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTA_Visor_DSClient_Config_Manager.kernel.sharedKernel.hardware
{
    public class Hardware
    {
        public List<DriveInfo> allDrives()
        {
            ManagementObjectSearcher devices = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");
            try
            {
                await Task.Delay(2000);

                foreach (ManagementObject device in devices.Get())
                {
                    foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {

                            string deviceID = device.GetPropertyValue("DeviceID").ToString();
                            string pnpnDeviceID = device.GetPropertyValue("PNPDeviceID").ToString();
                            string volumeName = disk["VolumeName"].ToString();
                            string drive = disk["Name"].ToString();

                            this.FireDriveInserted(drive);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void getStation()
        {

        }
    }
}
