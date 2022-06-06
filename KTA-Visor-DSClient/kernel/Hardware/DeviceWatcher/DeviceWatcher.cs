
using Sdk.Core.DevicesDetection;
using Sdk.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USBKitcs;
using USBKitcs.Main;

namespace KTA_Visor_DSClient.kernel.Hardware.DeviceWatcher
{
    public class DeviceWatcher
    {

        /// <summary>
        /// 
        /// </summary>
        private ManagementEventWatcher usbInsertEventWatcher;

        /// <summary>
        /// 
        /// </summary>
        private ManagementEventWatcher usbRemoveEventWatcher;

        /// <summary>
        /// 
        /// </summary>
        public event DeviceDetectionHandle OnDeviceDetected;

        /// <summary>
        /// 
        /// </summary>
        public event DeviceDetectionHandle OnDeviceRemoved;

        /// <summary>
        /// 
        /// </summary>
        public event DeviceDetectionHandle OnDeviceMounted;


        public DeviceWatcher()
        {
        }
         


        /// <summary>
        /// 
        /// </summary>
        public void startWatching()
        {
            ManagementScope scope = new ManagementScope("root\\CIMV2")
            {
                Options = { EnablePrivileges = true }
            };

            this.hookUsbInsertWatcher(scope);
            this.hookUsbRemovingWatcher(scope);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scope"></param>
        private void hookUsbInsertWatcher(ManagementScope scope)
        {
            try
            {
                // var query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");

                this.usbInsertEventWatcher = new ManagementEventWatcher(scope, (EventQuery)new WqlEventQuery()
                {
                    EventClassName = "__InstanceCreationEvent",
                    WithinInterval = new TimeSpan(0, 0, 0, 0, 500),
                    Condition = "TargetInstance ISA 'Win32_DiskDrive'"
                });
                this.usbInsertEventWatcher.EventArrived += UsbInsertEventWatcher_EventArrived;
                this.usbInsertEventWatcher.Start();
            }
            catch (Exception ex) {
                this.usbInsertEventWatcher?.Stop();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scope"></param>
        private void hookUsbRemovingWatcher(ManagementScope scope)
        {
            try
            {
                this.usbRemoveEventWatcher = new ManagementEventWatcher(scope, (EventQuery)new WqlEventQuery()
                {
                    EventClassName = "__InstanceDeletionEvent",
                    WithinInterval = new TimeSpan(0, 0, 0, 0, 500),
                    Condition = "TargetInstance ISA 'Win32_USBHub'"
                });
                this.usbRemoveEventWatcher.EventArrived += UsbRemoveEventWatcher_EventArrived;
                this.usbRemoveEventWatcher.Start();
            }
            catch (Exception ex) {
                this.usbRemoveEventWatcher.Stop();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsbInsertEventWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject targetInstance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            if (!this.VerifyInsertedUsb(targetInstance)) return;
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

                this.OnDeviceMounted?.Invoke(detectedInformation, VolumeChangeEventType.Unmount);
            }
            else
            {
                DeviceDetectedInformation detectedInformation = new DeviceDetectedInformation()
                {
                    SerialNumber = this.GetDeviceSerialNumber(targetInstance.Properties["PNPDeviceID"].Value.ToString())
                };

                this.OnDeviceDetected?.Invoke(detectedInformation, VolumeChangeEventType.Removed);
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
            return deviceIdString.Substring(deviceIdString.LastIndexOf("\\", StringComparison.Ordinal) + 1, length);
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
            catch
            {
                return false;
            }
        }
    }
}
