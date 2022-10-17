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

        public event DeviceDetectionHandle OnDeviceDetected;
        public event DeviceDetectionHandle OnDeviceRemoved;
        public event DeviceDetectionHandle OnDeviceMounted;
        public event EventHandler<Exception> OnExceptionOccured;

        private ManagementEventWatcher _insertWatcher;
        private ManagementEventWatcher _removeWatcher;

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
             
            try
            {
                ManagementScope scope = new ManagementScope("root\\CIMV2")
                {
                    Options = { EnablePrivileges = true }
                };

                WqlEventQuery insertQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");

                this._insertWatcher = new ManagementEventWatcher(insertQuery);
                this._insertWatcher.EventArrived += new EventArrivedEventHandler(UsbInsertEventWatcher_EventArrived);
                this._insertWatcher.Start();

                WqlEventQuery removeQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_USBHub'");
                this._removeWatcher = new ManagementEventWatcher(removeQuery);
                this._removeWatcher.EventArrived += new EventArrivedEventHandler(UsbRemoveEventWatcher_EventArrived);
                this._removeWatcher.Start();

                Thread.Sleep(2000);
            }
            catch (Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
            }
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

                            this.OnDeviceMounted?.Invoke(detectedInformation, VolumeChangeEventType.Mount);
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                this.OnExceptionOccured?.Invoke(this, e);
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsbInsertEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            try
            {
                ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
                if (!this.VerifyInsertedUsb(targetInstance))
                    return;
                string volumeName;
                string driveName;
                if (this.GetDriveLetterFromDisk(targetInstance["DeviceID"]?.ToString(), out volumeName, out driveName))
                {

                    DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                    {
                        DriveLetter = driveName,
                        DriveCaption = volumeName,
                        SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
                    };

                    DeviceDetectionHandle onDeviceMounted = this.OnDeviceMounted;
                    if (onDeviceMounted == null)
                        return;
                    onDeviceMounted(detectedInformation, VolumeChangeEventType.Mount);
                }
                else
                {
                    DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                    {
                        DriveCaption = targetInstance["Caption"]?.ToString(),
                        SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
                    };
                    DeviceDetectionHandle onDeviceDetected = this.OnDeviceDetected;
                    if (onDeviceDetected == null)
                        return;
                    onDeviceDetected(detectedInformation, VolumeChangeEventType.Inserted);
                }
            }
            catch(Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void UsbRemoveEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
           try
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
                    this.OnDeviceRemoved?.Invoke(detectedInformation, VolumeChangeEventType.Unmount);
                }
                else
                {
                    DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                    {
                        SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
                    };

                    this.OnDeviceRemoved?.Invoke(detectedInformation, VolumeChangeEventType.Removed);
                }
            }
            catch(Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetInstance"></param>
        /// <returns></returns>
        private bool VerifyInsertedUsb(ManagementBaseObject targetInstance)
        {
            return targetInstance != null && targetInstance["Status"]?.ToString() == "OK";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetInstance"></param>
        /// <returns></returns>
        private bool VerifyRemovedUsb(ManagementBaseObject targetInstance)
        {
            return targetInstance != null && targetInstance["Status"]?.ToString() == "OK";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceIdString"></param>
        /// <returns></returns>
        private string GetDeviceSerialNumber(string deviceIdString)
        {
            int length = deviceIdString.Length - deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) - 1;
            deviceIdString = deviceIdString.Substring(deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) + 1, length);
            deviceIdString = deviceIdString.Replace("&0", "");
            return deviceIdString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="volumeName"></param>
        /// <param name="driveName"></param>
        /// <returns></returns>
        private bool GetDriveLetterFromDisk(string deviceId, out string volumeName, out string driveName)
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
            catch(Exception exception)
            {
                this.OnExceptionOccured?.Invoke(this, exception);
                return false;
            }
        }
        
        public string GetModuleName()
        {
            return DeviceDetector.ModuleName;
        }
    }
}
