using Falcon_Protocol.interfaces;
using Sdk.Core.DevicesDetection;
using Sdk.Core.Enums;
using System;
using System.Management;
using System.Threading;

namespace Falcon_Protocol.modules.detector
{
    public class DeviceDetector : IModuleInterface
    {
        public static string ModuleName = "DeviceDetector";

        private ManagementEventWatcher _usbInsertedManagementEventWatcher;
        private ManagementEventWatcher _usbRemovedManagementEventWatcher;

        public event DeviceDetectionHandle OnDeviceDetected;

        public event DeviceDetectionHandle OnDeviceRemoved;

        public event DeviceDetectionHandle OnDeviceMounted;


        public void Run()
        {
            ManagementScope scope = new ManagementScope("root\\CIMV2")
            {
                Options = {
                     EnablePrivileges = true
                 }
            };
            try
            {
                this._usbInsertedManagementEventWatcher = new ManagementEventWatcher(scope, (EventQuery)new WqlEventQuery()
                {
                    EventClassName = "__InstanceDeletionEvent",
                    WithinInterval = new TimeSpan(0, 0, 0, 0, 500),
                    Condition = "TargetInstance ISA 'Win32_DiskDrive'"
                });
                this._usbInsertedManagementEventWatcher.EventArrived += new EventArrivedEventHandler(this.UsbUsbInsertedEventWatcherOnEventArrived);
                this._usbInsertedManagementEventWatcher.Start();

                this._usbRemovedManagementEventWatcher = new ManagementEventWatcher(scope, (EventQuery)new WqlEventQuery()
                {
                    EventClassName = "__InstanceDeletionEvent",
                    WithinInterval = new TimeSpan(0, 0, 0, 0, 500),
                    Condition = "TargetInstance ISA 'Win32_USBHub'"
                });
                this._usbRemovedManagementEventWatcher.EventArrived += new EventArrivedEventHandler(this.UsbRemovedEventWatcherOnEventArrived);
                this._usbRemovedManagementEventWatcher.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
         
        }

        private void UsbUsbInsertedEventWatcherOnEventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            if (!this.VerifyInsertedUsb(targetInstance))
                return;
            string volumeName;
            string driveName;
            if (this.GetDriveLetterFromDisk(targetInstance["DeviceID"]?.ToString(), out volumeName, out driveName))
            {
                string str = targetInstance["SerialNumber"]?.ToString();
                DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                {
                    DriveLetter = driveName,
                    DriveCaption = volumeName,
                    SerialNumber = str
                };
                DeviceDetectionHandle onDeviceMounted = this.OnDeviceMounted;
                if (onDeviceMounted == null)
                    return;
                onDeviceMounted(detectedInformation, VolumeChangeEventType.Mount);
            }
            else
            {
                string str1 = targetInstance["Caption"]?.ToString();
                string str2 = targetInstance["SerialNumber"]?.ToString();
                DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                {
                    DriveCaption = str1,
                    SerialNumber = str2
                };
                DeviceDetectionHandle onDeviceDetected = this.OnDeviceDetected;
                if (onDeviceDetected == null)
                    return;
                onDeviceDetected(detectedInformation, VolumeChangeEventType.Inserted);
            }
        }

        private void UsbRemovedEventWatcherOnEventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            if (!this.VerifyRemovedUsb(targetInstance))
                return;
            string volumeName;
            string driveName;
            if (this.GetDriveLetterFromDisk(targetInstance["DeviceID"]?.ToString(), out volumeName, out driveName))
            {
                DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                {
                    DriveCaption = volumeName,
                    DriveLetter = driveName,
                    SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
                };
                DeviceDetectionHandle onDeviceRemoved = this.OnDeviceRemoved;
                if (onDeviceRemoved == null)
                    return;
                onDeviceRemoved(detectedInformation, VolumeChangeEventType.Unmount);
            }
            else
            {
                DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                {
                    SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
                };
                DeviceDetectionHandle onDeviceRemoved = this.OnDeviceRemoved;
                if (onDeviceRemoved == null)
                    return;
                onDeviceRemoved(detectedInformation, VolumeChangeEventType.Removed);
            }
        }

        private bool GetDriveLetterFromDisk(
          string deviceId,
          out string volumeName,
          out string driveName)
        {
            volumeName = (string)null;
            driveName = (string)null;
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(new ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + deviceId + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition"));
            try
            {
                foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
                {
                    using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + managementBaseObject["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get().GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                        {
                            ManagementBaseObject current = enumerator.Current;
                            volumeName = current["VolumeName"]?.ToString();
                            driveName = current["Name"]?.ToString();
                            return true;
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool VerifyInsertedUsb(ManagementBaseObject targetInstance) => targetInstance != null && targetInstance["Status"]?.ToString() == "OK" ;

        private bool VerifyRemovedUsb(ManagementBaseObject targetInstance) => targetInstance != null && targetInstance["Status"]?.ToString() == "OK" ;

        private string GetDeviceSerialNumber(string deviceIdString)
        {
            int length = deviceIdString.Length - deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) - 1;
            return deviceIdString.Substring(deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) + 1, length);
        }

        public void LoadConnectedDevices()
        {
            try
            {
                foreach (ManagementObject device in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
                {
                    foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device.Properties["DeviceID"].Value + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
                    {
                        foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
                        {

                            string deviceID = device.GetPropertyValue("DeviceID").ToString();
                            string pnpnDeviceID = device.GetPropertyValue("PNPDeviceID").ToString();
                            string volumeName = disk["VolumeName"].ToString();
                            string driveName = disk["Name"].ToString();

                            DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                            {
                                DriveCaption = volumeName,
                                DriveLetter = driveName,
                                SerialNumber = this.GetDeviceSerialNumber(pnpnDeviceID)
                            };

                            this.OnDeviceMounted?.Invoke(detectedInformation, VolumeChangeEventType.Unmount);
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }
       

        public string GetModuleName()
        {
            return DeviceDetector.ModuleName;
        }
    }
}
